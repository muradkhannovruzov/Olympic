using AdminApp.Repository;
using AdminApp.Service;
using AdminApp.ViewModel;
using OlympicApp.Model;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {

            
            Container = new Container();

            Container.RegisterSingleton<RegisterVM>();
            Container.RegisterSingleton<AddMedalVM>();


            Container.RegisterSingleton<IFileReader<Athlet>, ReadAthletFromCSV>();
            Container.RegisterSingleton<ICopyService, CopySercive>();


            base.OnStartup(e);
        }
    }
}
