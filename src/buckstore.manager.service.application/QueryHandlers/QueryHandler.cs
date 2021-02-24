using System;
using Npgsql;
using System.Data;

namespace buckstore.manager.service.application.QueryHandlers
{
    public abstract class QueryHandler
    {
        private readonly string _connectionString = Environment.GetEnvironmentVariable("ConnectionString");

        internal IDbConnection DbConnection { get { return new NpgsqlConnection(_connectionString); } }

    }
}