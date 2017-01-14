using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using World.Web.Models;

namespace World.Web.Repository
{
    public class CityRepository
    {
        private string connectionString;
        public CityRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public IEnumerable<City> GetAll()
        {
            
            return Connection.Query<City>("SELECT * FROM city ORDER BY name ASC");

        }
    }
}
