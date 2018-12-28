using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using ToChurch.Interfaces;
using ToChurch.Models;

namespace ToChurch.Repositories
{
    public class ChurchRepository : IChurchRepository
    {
        private readonly IDbConnection _db;

        public ChurchRepository(IOptions<ConnectionStrings> connectionString)
        {
            //_db = new MySqlConnection(connectionString.Value.ConnectionString);

            var conString =
                "host=localhost;port=3306;user id=root;password=123321;database=cataloghrambel;";
            _db = new MySqlConnection(conString);
        }

        public IEnumerable<Address> GetAddresses()
        {
            if (_db == null)
                throw new NullReferenceException();

            var addresses = _db.Query<Address>("SELECT * FROM address").ToArray();

            return addresses;
        }

        public IEnumerable<Church> GetAllChurches()
        {
            if (_db == null)
            throw new NullReferenceException();

            var churches = _db.Query<Church>("SELECT * FROM 5_hram").ToArray();

            return churches;
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
