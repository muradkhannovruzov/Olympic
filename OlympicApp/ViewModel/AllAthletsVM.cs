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


namespace OlympicApp.ViewModel
{
    public class AllAthletsVM : ViewModelBase
    {
        private Messenger messenger;
        private List<Athlet> athlets;
        private Athlet selectedAthlet;
        private string searchText;
        private RelayCommand searchCommand;
        private RelayCommand selectCommand;
        private SportCathegory currentCat;

        public string SearchText
        {
            get => searchText;
            set
            {
                Set(ref searchText, value);
                Athlets = Athlets.Where(x => x.Name.ToLower().IndexOf(SearchText).ToString() == "0").ToList();
                if (value.Length < 1)
                {
                    Athlets = currentCat.Athlet.OrderBy(y => y.Score).ToList();
                }
            }
        }
        public List<Athlet> Athlets { get => athlets; set => Set(ref athlets, value); }
        public Athlet SelectedAthlet { get => selectedAthlet; set => Set(ref selectedAthlet, value); }

        public AllAthletsVM()
        {
            messenger = App.Container.GetInstance<Messenger>();

            messenger.Register<CathegoryMessage>(this, x =>
            {

                Athlets = x.CurrentCathegory.Athlet.OrderByDescending(y => y.Score).ToList();
                currentCat = x.CurrentCathegory;
            });

            

        }


        public RelayCommand SelectCommand => selectCommand ?? (selectCommand = new RelayCommand(() =>
        {
            messenger.Send(new AthletMessage() { CurrentAthlet = SelectedAthlet });
            messenger.Send(new ViewChange() { ViewModel = App.Container.GetInstance<InfoAthletVM>() });
        }));
        public RelayCommand SearchCommand => searchCommand ?? (searchCommand = new RelayCommand(() =>
        {
            if (SearchText != null)
            {
                Athlets = Athlets.Where(x => x.Name.ToLower().IndexOf(SearchText).ToString() == "0").ToList();
                if (SearchText.Length < 1)
                {
                    Athlets = currentCat.Athlet.OrderBy(y => y.Score).ToList();
                }
            }
        }));

    }
}
