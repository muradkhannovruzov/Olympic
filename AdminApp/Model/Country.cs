using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicApp.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string FlagPath { get; set; }
        virtual public List<Medal> Medals { get; set; } = new List<Medal>();
        virtual public List<Athlet> Athlets { get; set; } = new List<Athlet>();
    }
}
