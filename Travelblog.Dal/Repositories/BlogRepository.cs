using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Dal.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly string? _connectionString;
        private SqlConnection sqlConnection;

        public BlogRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SchoolConnection");
            sqlConnection = new SqlConnection(_connectionString);
        }

        public List<Blog> GetAll()
        {
            List<Blog> blogs = new List<Blog>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Assuming "Blog" is your table name
                string query = "SELECT * FROM [dbo].[Blog]";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Blog blog = new Blog
                        {
                            // Property names in the model match the column names in the database
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            User_Id = reader.GetInt32(reader.GetOrdinal("Creator_Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            StartDate = reader.GetDateTime(reader.GetOrdinal("Start_Date")),
                            Likes = reader.GetInt32(reader.GetOrdinal("Likes")),
                            IsPrive = reader.GetBoolean(reader.GetOrdinal("Prive")),
                            IsSuspended = reader.GetBoolean(reader.GetOrdinal("Suspended")),
                            IsDeleted = reader.GetBoolean(reader.GetOrdinal("Deleted")),
                            Trip_Id = 0
                        };

                        blogs.Add(blog);
                    }
                }
            }

            return blogs;
        }
    }
}
