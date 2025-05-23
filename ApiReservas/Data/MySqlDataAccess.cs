using ApiReservas.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace ApiReservas.Data
{
    public class MySqlDataAccess
    {
        private readonly string _connectionString;

        // Constructor para inyectar IConfiguration
        public MySqlDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlConnection");
        }

        public List<Reserva> GetReservas()
        {
            var reservas = new List<Reserva>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Reservas"; // O usar Stored Procedures
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservas.Add(new Reserva
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                DNI = reader["DNI"].ToString(),
                                Email = reader["Email"].ToString(),
                                NumeroInvitados = Convert.ToInt32(reader["NumeroInvitados"]),
                                Fecha = reader.GetDateTime("Fecha")
                            });
                        }
                    }
                }
            }
            return reservas;
        }

        public List<Reserva> GetReservasToday()
        {
            var reservas = new List<Reserva>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Reservas WHERE Fecha = CURDATE()";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservas.Add(new Reserva
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                DNI = reader["DNI"].ToString(),
                                Email = reader["Email"].ToString(),
                                NumeroInvitados = Convert.ToInt32(reader["NumeroInvitados"]),
                                Fecha = reader.GetDateTime("Fecha")
                            });
                        }
                    }
                }
            }
            return reservas;
        }

        public void PostReserva(Reserva nuevaReserva)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Reservas 
                        (Nombre, Apellido, DNI, Email, NumeroInvitados, Fecha) 
                        VALUES 
                        (@Nombre, @Apellido, @DNI, @Email, @NumeroInvitados, @Fecha)";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nuevaReserva.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", nuevaReserva.Apellido);
                    cmd.Parameters.AddWithValue("@DNI", nuevaReserva.DNI);
                    cmd.Parameters.AddWithValue("@Email", nuevaReserva.Email);
                    cmd.Parameters.AddWithValue("@NumeroInvitados", nuevaReserva.NumeroInvitados);
                    cmd.Parameters.AddWithValue("@Fecha", nuevaReserva.Fecha);

                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
