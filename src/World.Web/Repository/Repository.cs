using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using World.Web.Models;

namespace World.Web.Repository
{
    public class Repository
    {
        private string connectionString;
        public Repository(IConfiguration configuration)
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

            var list = Connection.Query<City>("SELECT * FROM city ORDER BY name ASC");
            return list;

        }

        public IEnumerable<City> Cities()
        {
            var list = Connection.Query<City>("SELECT id, name FROM city ORDER BY name ASC");
            return list;
        }

        public IEnumerable<FilterList> Filter()
        {
            var list = Connection.Query<FilterList>("select co.continent, co.name AS country, ci.name AS city from country co left join city ci on co.code = ci.countrycode order by co.continent, co.name, ci.name");
            return list;
        }
        public IEnumerable<LifeExp> LifeExp()
        {
            var list = Connection.Query<LifeExp>("select co.name AS country, MAX(co.lifeexpectancy) AS lifeexpectancy from country co group by co.name, co.lifeexpectancy order by co.lifeexpectancy DESC");
            return list;
        }

    }
}
