using GalaSoft.MvvmLight.Command;
using OlympicApp.Model;
using OlympicApp.Service;
using OlympicApp.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicApp.ViewModel
{
    class TeamStageVM
    {
        private RelayCommand selectCommand;



        public string Back { get; set; }
        public string Time { get; set; }
        public OppositeTeams OppositeTeam { get; set; }
        private string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
        .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
        + "\\OlympicApp\\";
        public List<OppositeTeams> OppositeTeams { get; set; }
        public TeamStageVM(StageForTeam a)
        {
            // MessageBox.Show(a.OppositeTeams[0].Team1.Id.ToString());
            OppositeTeams = a.OppositeTeams;
            Back = GetImagePathes.GetBackGround("Race");
            Time = a.Time.ToString();
            //foreach (var item in OppositeTeams)
            //{
            //    item.Team1.FlagPath = directory + item.Team1.FlagPath;
            //    item.Team2.FlagPath = directory + item.Team2.FlagPath;
            //}
        }
        public RelayCommand SelectCommand => selectCommand ?? (selectCommand = new RelayCommand(() =>
        {
            var a = new TeamVSTeam(OppositeTeam);
            a.Show();
        }));
    }
}
