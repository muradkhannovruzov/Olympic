using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using OlympicApp.Messages;
using OlympicApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicApp.ViewModel
{
    public class InfoAthletVM : ViewModelBase
    {
        private Athlet athlet;
        private Messenger messenger;

        public Athlet Athlet { get => athlet; set => Set(ref athlet, value); }


        public InfoAthletVM()
        {
            messenger = App.Container.GetInstance<Messenger>();

            messenger.Register<AthletMessage>(this, x =>
            {
                Athlet = x.CurrentAthlet;
            });
        }
    }
}
