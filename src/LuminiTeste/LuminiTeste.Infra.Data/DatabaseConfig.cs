﻿using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LuminiTeste.Infra.Data
{
    public class DatabaseConfig
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DatabaseConfig(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
