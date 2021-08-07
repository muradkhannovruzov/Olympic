using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using OlympicApp.Model;
using System.Data.SqlClient;
using System.Windows;

namespace OlympicApp.Service
{
    public static class ReadWithDapper
    {
        public static string Constr { get; set; } = @"Data Source=DESKTOP-USAFUUD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=Olympic;";
        public static List<Athlet> GetAthlets()
        {
            using (var con = new SqlConnection(Constr))
            {
                con.Open();
                var reader = con.Query<Athlet>("SELECT * FROM Athlets;");
                foreach (var item in reader.ToList())
                {
                    var medalreader = con.Query<Medal>($@"select *from medals  where Athlet_Id={item.Id.ToString()};");
                    item.Medals = medalreader.ToList();

                }
                return reader.ToList();
            }
        }
        public static List<Country> GetCountry()
        {
            using (var con = new SqlConnection(Constr))
            {
                con.Open();
                var reader = con.Query<Country>("SELECT * FROM Countries;");
                foreach (var item in reader.ToList())
                {
                    var medalreader = con.Query<Medal>($@"select *from medals  where Athlet_Id={item.Id.ToString()};");
                    item.Medals = medalreader.ToList();

                }
                return reader.ToList();
            }
        }
    }
}
