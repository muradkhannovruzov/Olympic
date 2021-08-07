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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace OlympicApp.ViewModel
{
    class AthletInfoVM
    {
        private List<Athlet> athlets;
        private RelayCommand selectCommand;

        private string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
                   .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
                   + "\\OlympicApp\\";
        private Athlet index;
        public string BackGround { get; set; }
        public Athlet Index { get => index; set => index = value; }
        public int GoldMedals { get; set; }
        public int SilverMedals { get; set; }
        public int BronzeMedals { get; set; }
        public Country Country { get; set; }
        public Athlet Athlet { get; set; }
        public List<Athlet> Athlets { get => athlets; set => athlets = value; }
        public AthletInfoVM(int athlet)
        {
           
            OlympicDB a = new OlympicDB();
            Athlet = a.Athlet.ToList().Where(x => x.Id == athlet).FirstOrDefault();
            BackGround = GetImagePathes.GetBackGround("Athlet");
            GoldMedals = Athlet.Medals.Where(x => x.MedalType.Type == "Gold").Count();
            BronzeMedals = Athlet.Medals.Where(x => x.MedalType.Type == "Bronze").Count();
            SilverMedals = Athlet.Medals.Where(x => x.MedalType.Type == "Silver").Count();
            Athlets = a.Athlet.Where(x => x.Country.Name == Athlet.Country.Name).OrderByDescending(x => x.Medals.Count).ToList();
            Athlet.FlagPath = directory + Athlet.FlagPath;
            foreach (var item in Athlets)
            {
                item.ImagePath = directory + item.ImagePath;
                item.Country.FlagPath = directory + item.Country.FlagPath;
            }
            // Athlet.Weight
        }
        public RelayCommand SelectCommand => selectCommand ?? (selectCommand = new RelayCommand(() =>
        {
            AthletInfo NewA = new AthletInfo(Index.Id);
            NewA.Show();
        }));
    }
}
