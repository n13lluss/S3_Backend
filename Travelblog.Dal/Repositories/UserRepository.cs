using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string? _connectionString;
        private SqlConnection sqlConnection;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SchoolConnection");
            sqlConnection = new SqlConnection(_connectionString);
        }

        public User GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Assuming "User" is your table name
                string query = "SELECT * FROM [dbo].[User] WHERE Id = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToUser(reader);
                        }
                    }
                }
            }

            return null; // User with the specified ID not found
        }

        private User MapReaderToUser(SqlDataReader reader)
        {
            return new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                UserName = reader.GetString(reader.GetOrdinal("Username")),
                Password = reader.GetString(reader.GetOrdinal("Password")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Suspended = reader.GetBoolean(reader.GetOrdinal("Suspended")),
                Role = reader.GetString(reader.GetOrdinal("Role")),
                // Add other properties as needed
            };
        }
    }
}
