using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OlympicApp.Messages;
using OlympicApp.Model;
using OlympicApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OlympicApp.ViewModel
{
    public class InfoSportVM : ViewModelBase
    {
        private Messenger messenger;
        private Sport currentSport;
        private List<Gender> genders;
        private List<SportCathegory> menCathegories;
        private List<SportCathegory> womenCathegories;
        private List<SportCathegory> mixedCahegories;
        private RelayCommand selectCommand;
        private SportCathegory selectedCathegory;

        public SportCathegory SelectedCathegory { get => selectedCathegory; set => Set(ref selectedCathegory, value); }
        public List<SportCathegory> WomenCathegories { get => womenCathegories; set => Set(ref womenCathegories, value); }
        public List<SportCathegory> MenCathegories { get => menCathegories; set => Set(ref menCathegories, value); }
        public List<Gender> Genders { get => genders; set => Set(ref genders, value); }
        public List<SportCathegory> MixedCahegories { get => mixedCahegories; set => Set(ref mixedCahegories, value); }
        public Sport CurrentSport
        {
            get => currentSport;
            set
            {
                Set(ref currentSport, value);
            }
        }


        public InfoSportVM()
        {

            messenger = App.Container.GetInstance<Messenger>();

            using (var db = new OlympicDB())
            {
                Genders = db.Gender.ToList();
            }

            messenger.Register<SportMessage>(this, x =>
            {
                CurrentSport = x.Sport;
                WomenCathegories = CurrentSport.SportCathegory.Where(s => s.Gender.Id == Genders[1].Id).ToList();
                MenCathegories = CurrentSport.SportCathegory.Where(s => s.Gender.Id == Genders[0].Id).ToList();
                MixedCahegories = CurrentSport.SportCathegory.Where(s => s.Gender.Id == Genders[2].Id).ToList();

            });
        }

        public RelayCommand SelectCommand => selectCommand ?? (selectCommand = new RelayCommand(() =>
        {
            messenger.Send(new CathegoryMessage() { CurrentCathegory = SelectedCathegory });
            messenger.Send(new ViewChange() { ViewModel = App.Container.GetInstance<InfoCathegoryVM>() });
        }));
    }
}
