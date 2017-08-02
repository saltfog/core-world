using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using World.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
		[FormatFilter]
		[HttpGet]
		[HttpGet("/api/[controller].{format}")]
		public IEnumerable<City> GetAll()
        {

            var list = Connection.Query<City>("SELECT * FROM city");
            return list;

        }

        public IEnumerable<City> Cities()
        {
            var list = Connection.Query<City>("SELECT id, name, countrycode, district, population FROM city order by name");
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

        public IEnumerable <Country> SearchCountry(string search)
        {
            if (search != null)
                search = search.TrimStart('0').ToUpper();
            var query = @"select code, name, continent, region, population, lifeexpectancy from country WHERE UPPER(name) LIKE '%" + @search + "%' order by name";


            return (Connection.Query<Country>(query, new { search = search })).ToList();
        }
        public IEnumerable<SummaryPage> GetSummary()
		{
            var list = Connection.Query<SummaryPage>("select ci.name as cities, co.name AS countries, ci.population AS poulation from city ci join country co on ci.countrycode = co.code order by co.name, ci.name limit '20'");
            return list.ToList();
		}
    }
}
