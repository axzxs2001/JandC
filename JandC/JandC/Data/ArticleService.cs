using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace JandC.Data
{
    public class ArticleService
    {
        private readonly string _connectionString;
        public ArticleService(IConfiguration configuration)
        {
            _connectionString = string.Format(configuration.GetConnectionString("DefaultConnection"), System.IO.Directory.GetCurrentDirectory());
        }
        SqliteConnection CreateConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();
            return connection;
        }
        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
           
            using (var con = CreateConnection())
            {
                return await con.QueryAsync<Article>("select * from articles");
            }
        }
    }
}
