using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using ToChurch.Interfaces;

namespace ToChurch.Repositories
{
    public class ChurchRepository : IChurchRepository
    {
        private readonly IDbConnection _db;

        public ChurchRepository(IOptions<ConnectionStrings> connectionString)
        {
            //_db = new MySqlConnection(connectionString.Value.ConnectionString);

            var conString =
                "host=52.57.145.179;user id=hrambelcatalog;password=WYaJNI7JuszNLguX;database=cataloghrambel;";
            _db = new MySqlConnection(conString);
        }

        public IEnumerable<Church> GetAllChurches()
        {
            throw new NotImplementedException();
        }

        public Church GetChurch(string churchName)
        {
            throw new NotImplementedException();
        }
    }

    public class ConnectionStrings
    {
        public string ConnectionString { get; set; }
    }
}
