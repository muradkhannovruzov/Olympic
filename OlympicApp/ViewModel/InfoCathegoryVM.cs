using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using OlympicApp.Model;
using OlympicApp.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.IO;

namespace OlympicApp.ViewModel
{
    class InfoCathegoryVM : ViewModelBase
    {
        private string header;
        private SportCathegory cathegory;
        private Messenger messenger;
        private List<Athlet> topAthlets;
        private RelayCommand allCommand;
        private List<Athlet> athlets;
        private RelayCommand selectCommand;
        private Athlet selectedAthlet;
        private string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
                  .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
                  + "\\OlympicApp\\";


        public List<Athlet> Athlets { get => athlets; set => Set(ref athlets, value); }
        public List<Athlet> TopAthlets { get => topAthlets; set => Set(ref topAthlets, value); }
        public Athlet SelectedAthlet { get => selectedAthlet; set => Set(ref selectedAthlet, value); }

        public int a { get; set; } = 0;

        public SportCathegory Cathegory { get => cathegory; set => Set(ref cathegory, value); }
        public string Header { get => header; set => Set(ref header, value); }
        public InfoCathegoryVM()
        {
            messenger = App.Container.GetInstance<Messenger>();


            messenger.Register<CathegoryMessage>(this, x =>
             {
                 Cathegory = x.CurrentCathegory;
                 Header = Cathegory.Sport.Name + " - " + Cathegory.Name + ' ' + Cathegory.Gender.FemaleOrMale;

                 Athlets = Cathegory.Athlet.OrderByDescending(y => y.Score).ToList();

                 
                 foreach (var item in Athlets)
                 {

                     if(item.FlagPath.IndexOf(directory) == -1)
                     {
                        item.FlagPath = directory + item.FlagPath;
                         item.ImagePath = directory + item.ImagePath;
                     }    
                 }
                 TopAthlets = Athlets.Take(6).ToList();


             });


        }

        public RelayCommand SelectCommand => selectCommand ?? (selectCommand = new RelayCommand(() =>
        {
            messenger.Send(new AthletMessage() { CurrentAthlet = SelectedAthlet });
            messenger.Send(new ViewChange() { ViewModel = App.Container.GetInstance<InfoAthletVM>() });
        }));

        public RelayCommand AllCommand => allCommand ?? (allCommand = new RelayCommand(() =>
        {
            messenger.Send(new ViewChange() { ViewModel = App.Container.GetInstance<AllAthletsVM>() });
        }));
    }

}
