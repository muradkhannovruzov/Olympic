using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicApp.Model
{
    public class Athlet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ImagePath { get; set; }
        public string FlagPath { get; set; }
        public int Weight { get; set; }
        public int Gold => Medals.Count(x => x.MedalType.Point == 3);
        public int Silver => Medals.Count(x => x.MedalType.Point == 2);
        public int Bronze => Medals.Count(x => x.MedalType.Point == 1);
        public int Score => Medals.Sum(x => x.MedalType.Point);
        virtual public DateTime BirthDay { get; set; }
        virtual public Sport Sport { get; set; }
        virtual public List<SportCathegory> SportCathegores { get; set; } = new List<SportCathegory>();
        virtual public Country Country { get; set; }
        virtual public List<Medal> Medals { get; set; } = new List<Medal>();
        virtual public Gender Gender { get; set; }
        virtual public List<RaceDegree> RaceDegree { get; set; }
        virtual public List<Stage> Stage { get; set; }
    }
}
