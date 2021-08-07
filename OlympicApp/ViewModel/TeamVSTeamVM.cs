using GalaSoft.MvvmLight.Command;
using OlympicApp.Model;
using OlympicApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OlympicApp.ViewModel
{
    class TeamVSTeamVM
    {
        public string Back { get; set; }
        public OppositeTeams OppositeTeams { get; set; }
        private string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
               .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
               + "\\OlympicApp\\";
        public TeamVSTeamVM(OppositeTeams a)
        {
            OppositeTeams = a;
            Back = GetImagePathes.GetBackGround("Back");
            foreach (var item in OppositeTeams.Team1.Athlet)
            {
                if (item.FlagPath.IndexOf(directory) == -1)
                {
                    item.ImagePath = directory + item.ImagePath;
                    item.FlagPath = directory + item.FlagPath;
                }

            }
            
            foreach (var item in OppositeTeams.Team2.Athlet)
            {
                if (item.FlagPath.IndexOf(directory) == -1)
                {
                    item.ImagePath = directory + item.ImagePath;
                    item.FlagPath = directory + item.FlagPath;
                }

            }

        }
    }
}
