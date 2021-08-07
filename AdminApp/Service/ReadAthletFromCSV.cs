using OlympicApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.IO;
using AdminApp.Repository;
using System.Windows;

namespace AdminApp.Service
{
    class ReadAthletFromCSV : IFileReader<Athlet>
    {
        public IEnumerable<Athlet> ReadFile(string path)
        {
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(path)), true))
            {
                csvTable.Load(csvReader);
            }
            List<Athlet> searchParameters = new List<Athlet>();
            for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                searchParameters.Add(new Athlet
                {
                    Name = csvTable.Rows[i][0].ToString(),
                    SurName = csvTable.Rows[i][1].ToString(),
                    BirthDay = Convert.ToDateTime(csvTable.Rows[i][4]),
                    Weight = Convert.ToInt32(csvTable.Rows[i][3]),
                    Sport = new Sport() { Name = csvTable.Rows[i][5].ToString() },
                    ImagePath = csvTable.Rows[i][6].ToString()


                });

                var db = new ReadWithDapper();
                var genders = db.GetGenders().ToList();
                if (csvTable.Rows[i][2].ToString() == "Male") searchParameters[i].Gender = genders[0];
                else if (csvTable.Rows[i][2].ToString() == "Female") searchParameters[i].Gender = genders[1];
            }
            return searchParameters;
        }
    }
}
