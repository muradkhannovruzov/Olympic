using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
    class AthletsVM : ViewModelBase
    {
        private Athlet index;
        private string text;
        private List<Athlet> athlet;
        private RelayCommand selectCommand;

        private string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
                   .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
                   + "\\OlympicApp\\";
        public Athlet Index
        {
            get => index; set
            {
                Set(ref index, value);
            }
        }
        public List<Athlet> Athlet
        {
            get => athlet; set
            {
                Set(ref athlet, value);
            }
        }
        public OlympicDB OlympicDB { get; set; } = new OlympicDB();
        public AthletsVM()
        {
            Athlet = ReadWithDapper.GetAthlets().OrderByDescending(x => x.Medals.Count()).ToList();
            foreach (var item in Athlet)
            {
                if (item.FlagPath != null && item.FlagPath.IndexOf(directory) == -1)
                {
                    item.ImagePath = directory + item.ImagePath;
                    item.FlagPath = directory + item.FlagPath;
                }
                    
            }
        }
        public string Text
        {
            get => text; set
            {
                Set(ref text, value);
                Athlet = Athlet.Where(x => x.Name.ToLower().IndexOf(value.ToLower()).ToString() == "0").ToList();
                if (value.Length < 1)
                {
                    Athlet = OlympicDB.Athlet.ToList().OrderByDescending(x => x.Medals.Count).ToList();
                    foreach (var item in Athlet)
                    {
                        if (item?.FlagPath?.IndexOf(directory) == -1)
                        {
                            item.ImagePath = directory + item.ImagePath;
                            item.FlagPath = directory + item.FlagPath;
                        }

                    }
                }
            }
        }
        public RelayCommand SelectCommand => selectCommand ?? (selectCommand = new RelayCommand(() =>
        {
            AthletInfo NewA = new AthletInfo(Index.Id);
            NewA.Show();
        }));
    }
}
