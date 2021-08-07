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
    class OwnRaceVM
    {
        private string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
                   .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
                   + "\\OlympicApp\\";
        public Race Race { get; set; }
        public Athlet Winner { get; set; }
        public Athlet Second { get; set; }
        public string Back { get; set; }
        public Athlet Third { get; set; }
        public OwnRaceVM(int id)
        {
            OlympicDB a = new OlympicDB();
            Race = a.Race.Where(x => x.Id == id).FirstOrDefault();
            Winner = Race.Winner;
            Second = Race.Second;
            Third = Race.Third;
            Back = GetImagePathes.GetBackGround("Race");
            foreach (var item in Race.Athlet)
            {
                foreach (var item1 in item.Athlet)
                {
                    if (item1.FlagPath.IndexOf(directory) == -1)
                    {
                        item1.ImagePath = directory + item1.ImagePath;
                        item1.FlagPath = directory + item1.FlagPath;
                    }
                        
                }
            }
            // Winner.CountryFlagImagePath
            //Race.Athlet;
        }
    }
}
