using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.ViewModel
{
    class MainVM : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        private RelayCommand registerCommand;
        private RelayCommand addMedalCommand;

        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }

        public RelayCommand RegisterCommand => registerCommand ?? (registerCommand = new RelayCommand(() =>
        {
            CurrentViewModel = App.Container.GetInstance<RegisterVM>();
        }));

        public RelayCommand AddMedalCommand => addMedalCommand ?? (addMedalCommand = new RelayCommand(() =>
        {
            CurrentViewModel = App.Container.GetInstance<AddMedalVM>();
        }));

    }
}
