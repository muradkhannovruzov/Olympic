using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OlympicApp.Messages;
using OlympicApp.Model;
using OlympicApp.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OlympicApp.ViewModel
{
    public class SportsVM : ViewModelBase
    {
        private List<Sport> sports;
        private Messenger messenger;
        private RelayCommand selectCommand;
        private Sport selectedSport;
        private RelayCommand searchCommand;
        private string searchText;

        private string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
                   .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
                   + "\\OlympicApp\\";
        public string SearchText 
        { get => searchText; 
            set
            { 
                Set(ref searchText, value);
                Sports = Sports.Where(x => x.Name.ToLower().IndexOf(SearchText).ToString() == "0").ToList();
                if (value.Length < 1)
                {
                    var db = new OlympicDB();
                    Sports = db.Sport.ToList().OrderBy(x => x.Name).ToList();
                    foreach (var item in Sports)
                    {
                        item.ImagePath = directory + item.ImagePath;
                    }

                }

            }
        }

        public RelayCommand SearchCommand => searchCommand ?? (searchCommand = new RelayCommand(() =>
        {
            if (SearchText != null)
            {
                Sports = Sports.Where(x => x.Name.ToLower().IndexOf(SearchText).ToString() == "0").ToList();
                if (SearchText.Length < 1)
                {
                    var db = new OlympicDB();
                    Sports = db.Sport.ToList().OrderBy(x => x.Name).ToList();
                    foreach (var item in Sports)
                    {
                        item.ImagePath = directory + item.ImagePath;
                    }

                }
            }
        }));

        public Sport SelectedSport
        {
            get => selectedSport;
            set
            {
                Set(ref selectedSport, value);
            }
        }

        public List<Sport> Sports { get => sports; set => Set(ref sports, value); }
        public RelayCommand SelectCommand => selectCommand ?? (selectCommand = new RelayCommand(() =>
        {
            messenger.Send(new SportMessage() { Sport = SelectedSport });
            messenger.Send(new ViewChange() { ViewModel = App.Container.GetInstance<InfoSportVM>() });
        }));

        public SportsVM()
        {
            messenger = App.Container.GetInstance<Messenger>();
            var db = new OlympicDB();
            Sports = db.Sport.OrderBy(x => x.Name).ToList();
            foreach (var item in Sports)
            {
                item.ImagePath = directory + item.ImagePath;
            }
        }

    }
}
