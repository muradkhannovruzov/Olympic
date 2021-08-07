using AdminApp.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OlympicApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApp.ViewModel
{
    class AddMedalVM : ViewModelBase
    {
        private List<Sport> sports;
        private List<SportCathegory> sportCathegories;
        private List<Athlet> athlets;
        private DateTime date = DateTime.Now;
        private List<MedalType> medalTypes;
        private Sport selectedSport;
        private SportCathegory selectedCat;
        private Athlet selectedAthlet;
        private MedalType selectedMedal;
        private RelayCommand addCommand;

        public Medal Medal { get; set; }


        public List<Sport> Sports
        {
            get => sports;
            set
            {
                Set(ref sports, value);
            }
        }
        public Sport SelectedSport
        {
            get => selectedSport; set
            {
                Set(ref selectedSport, value);
                SportCathegories = SelectedSport.SportCathegory;
                AddCommand.RaiseCanExecuteChanged();
                Athlets = null;
                SelectedAthlet = null;
            }
        }

        public List<SportCathegory> SportCathegories
        {
            get => sportCathegories;
            set
            {
                Set(ref sportCathegories, value);
            }
        }

        public SportCathegory SelectedCat
        {
            get => selectedCat; set
            {
                Set(ref selectedCat, value);
                if (selectedCat != null) Athlets = SelectedCat.Athlet;
                else Athlets = null;
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public AddMedalVM()
        {
            var db = new OlympicDB();
            Sports = db.Sport.ToList();
            MedalTypes = db.MedalType.ToList();
        }

        public List<Athlet> Athlets
        {
            get => athlets;
            set
            {
                Set(ref athlets, value);
            }
        }
        public Athlet SelectedAthlet
        {
            get => selectedAthlet; set
            {
                Set(ref selectedAthlet, value);
                AddCommand.RaiseCanExecuteChanged();

            }
        }

        public List<MedalType> MedalTypes { get => medalTypes; set => Set(ref medalTypes, value); }
        public MedalType SelectedMedal { 
            get => selectedMedal;
            set
            {
                Set(ref selectedMedal, value);
                AddCommand.RaiseCanExecuteChanged();
            }

        }

        public DateTime Date
        {
            get => date; set
            {
                Set(ref date, value);
            }
        }

        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(() =>
        {
            using (var db = new OlympicDB())
            {
                Medal = new Medal()
                {
                    MedalType = db.MedalType.FirstOrDefault(x => x.Id == selectedMedal.Id),
                    TimeOfWon = Date,
                    SportCathegory = db.SportCathegory.FirstOrDefault(x => x.Id == SelectedCat.Id),
                };

                db.Athlet.FirstOrDefault(x => x.Id == SelectedAthlet.Id).Medals.Add(Medal);
                db.Country.FirstOrDefault(x => x.Id == SelectedAthlet.Country.Id).Medals.Add(Medal);


                db.SaveChanges();
                MessageBox.Show("Medal was added");
                SelectedAthlet = null;
            }
        },() =>
            SelectedSport != null
            && SelectedCat != null
            && SelectedAthlet != null
            && SelectedMedal != null));
    }

}
