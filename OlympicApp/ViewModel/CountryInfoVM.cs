using GalaSoft.MvvmLight.Command;
using OlympicApp.Model;
using OlympicApp.Repository;
using OlympicApp.Service;
using OlympicApp.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OlympicApp.ViewModel
{
    class CountryInfoVM
    {
        private List<Athlet> athlets;
        private RelayCommand selectCommand;
        private Athlet athlet;
        private string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
                  .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
                  + "\\OlympicApp\\";
        public Athlet Index { get => athlet; set => athlet = value; }
        public string BackGround { get; set; }
        public Country Country { get; set; }
        public int GoldMedals { get; set; }
        public int SilverMedals { get; set; }
        public int BronzeMedals { get; set; }
        public List<Athlet> Athlets { get => athlets; set => athlets = value; }
        public List<RaceDegree> RaceDegree { get; set; } = new List<RaceDegree>();
        public CountryInfoVM(Country country)
        {
            OlympicDB a = new OlympicDB();

            Country = a.Country.Where(x => x.Name == country.Name).FirstOrDefault();
            foreach (var item in Country.Athlets)
            {
                foreach (var item1 in item.RaceDegree)
                {
                    RaceDegree.Add(item1);
                }
                item.ImagePath = directory + item.ImagePath;
            }
            Country.FlagPath = directory + Country.FlagPath;
            BackGround = GetImagePathes.GetBackGround("a");
            GoldMedals = Country.Medals.Where(x => x.MedalType.Type == "Gold").Count();
            BronzeMedals = Country.Medals.Where(x => x.MedalType.Type == "Bronze").Count();
            SilverMedals = Country.Medals.Where(x => x.MedalType.Type == "Silver").Count();
            Athlets = a.Athlet.Where(x => x.Country.Name == Country.Name).OrderByDescending(x => x.Medals.Count).ToList();


        }
        public RelayCommand SelectCommand => selectCommand ?? (selectCommand = new RelayCommand(() =>
        {
            AthletInfo NewA = new AthletInfo(Index.Id);
            NewA.Show();
        }));
    }
}
