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

        public Address GetAddressByHramId(int hramId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAddresses()
        {
            if (_db == null)
                throw new NullReferenceException();

            var addresses = _db.Query<Address>("SELECT * FROM address").ToArray();

            return addresses;
        }

        public IEnumerable<Address> GetAddressesByCityName(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
                return Enumerable.Empty<Address>();

            var citySql = "SELECT * FROM city WHERE city_name = @CityName";
            var cityId = _db.QuerySingleOrDefault<City>(citySql, new { CityName = cityName})?.City_Id;

            var addressSql = "SELECT * FROM address WHERE a_city_id =@CityID";
            var addresses = _db.Query<Address>(addressSql, new { CityId = cityId}).ToArray();
            return addresses;
        }

        public IEnumerable<Address> GetAddressesByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAddressesByRange()
        {
            throw new NotImplementedException();
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
