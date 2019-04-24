using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;

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

        public async Task<Article> GetArticleAsync(int id)
        {
            using (var con = CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Article>("select * from articles where id=@id", new { id });
            }
        }
        public async Task<int> EditAsync(Article article)
        {
            using (var con = CreateConnection())
            {
                return await con.ExecuteAsync("update articles set title=@Title,content=@Content where id=@ID", article);
            }
        }
    }
}
