using GalaSoft.MvvmLight;
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
    class TeamNocVM : ViewModelBase
    {
        private RelayCommand alphabetic;
        private List<Country> countries;
        private RelayCommand medal;
        private RelayCommand selectCommand;

        private string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
                   .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
                   + "\\OlympicApp\\";
        public List<Country> Countries
        {
            get => countries; set
            {
                Set(ref countries, value);
            }
        }
        public TeamNocVM()
        {
            //Countries = ReadWithDapper.GetCountry().OrderByDescending(x => x.Medals.Count).ToList();
            var db = new OlympicDB();
            Countries = db.Country.OrderByDescending(x => x.Medals.Count).ToList();
            foreach (var item in Countries)
            {
                if (item.FlagPath != null &&item.FlagPath.IndexOf(directory) == -1)
                {
                    item.FlagPath = directory + item.FlagPath;
                }
            }
        }
        public RelayCommand Alphabetic => alphabetic ?? (alphabetic = new RelayCommand(() =>
        {
            Countries = Countries.OrderBy(x => x.Name).ToList();
            
        }));

        public RelayCommand Medal => medal ?? (medal = new RelayCommand(() =>
        {
            
            Countries = Countries.OrderByDescending(x => x.Medals.Count()).ToList();
            
        }));
        public Country Index { get; set; }
        public RelayCommand SelectCommand => selectCommand ?? (selectCommand = new RelayCommand(() =>
        {
            CountryInfo NewA = new CountryInfo(Index);
            NewA.Show();
        }));
    }
}
