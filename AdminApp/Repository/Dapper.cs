using Dapper;
using OlympicApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Repository
{
    public class ReadWithDapper
    {
        public IEnumerable<Gender> GetGenders()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Olyimpic"].ToString()))
            {
                con.Open();
                return con.Query<Gender>("SELECT * FROM Genders");
            }
        }

        public IEnumerable<string> GetCountryName()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Olyimpic"].ToString()))
            {
                con.Open();
                return con.Query<string>("SELECT [Name] FROM Countries");
            }
        }

        public IEnumerable<string> GetSportName()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Olyimpic"].ToString()))
            {
                con.Open();
                return con.Query<string>("SELECT [Name] FROM Sports");
            }
        }


    }
}
