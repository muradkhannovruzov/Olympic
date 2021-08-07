using GalaSoft.MvvmLight.Messaging;
using OlympicApp.Repository;
using OlympicApp.ViewModel;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OlympicApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            //using (var db = new OlympicDB())
            //{
            //    //db.Team.FirstOrDefault(x => x.Id == 2).Athlet.Add(db.Athlet.FirstOrDefault(x => x.Id == 10));
            //    //db.Team.FirstOrDefault(x => x.Id == 2).Athlet.Add(db.Athlet.FirstOrDefault(x => x.Id == 20));
            //    //db.Team.FirstOrDefault(x => x.Id == 2).Athlet.Add(db.Athlet.FirstOrDefault(x => x.Id == 30));

            //    //db.Team.FirstOrDefault(x => x.Id == 4).Athlet.Add(db.Athlet.FirstOrDefault(x => x.Id == 40));
            //    //db.Team.FirstOrDefault(x => x.Id == 4).Athlet.Add(db.Athlet.FirstOrDefault(x => x.Id == 50));
            //    //db.Team.FirstOrDefault(x => x.Id == 4).Athlet.Add(db.Athlet.FirstOrDefault(x => x.Id == 60));

            //    //int i = 0;

            //    string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
            //       .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
            //       + "\\OlympicApp\\";

            //    //foreach (var item in db.Country.ToList())
            //    //{
            //    //    item.FlagPath = $@"Image\Flags\{item.Name}.png";
            //    //}

            //    //foreach (var item in db.Athlet.ToList())
            //    //{
            //    //    if (i < 10) item.ImagePath = @"Image\AthlethImage\Huntington.jfif";
            //    //    if (i < 20) item.ImagePath = @"Image\AthlethImage\Ches.jfif";
            //    //    if (i < 40) item.ImagePath = @"Image\AthlethImage\Oneida.jfif";
            //    //    if (i < 50) item.ImagePath = @"Image\AthlethImage\Michaelina.jfif";
            //    //    if (i < 30) item.ImagePath = @"Image\AthlethImage\Domeniga.jfif";
            //    //    if (i > 60) item.ImagePath = @"Image\AthlethImage\Anonim.jfif";
            //    //    item.FlagPath = item.Country.FlagPath;
            //    //    i++;
            //    //}
            //    foreach (var item in db.Team.ToList())
            //    {
            //        item.FlagPath =directory + item.Country.FlagPath;
            //    }



            //    db.SaveChanges();


            //}



            //using (var db = new OlympicDB())
            //{


            //    foreach (var at in db.Athlet.ToList())
            //    {
            //        foreach (var cat in db.SportCathegory.ToList())
            //        {
            //            if (at.Sport.Id == cat.Sport.Id && cat.Gender.Id == at.Gender.Id)
            //            {
            //                at.SportCathegores.Add(cat);
            //                cat.Athlet.Add(at);
            //            }
            //        }
            //    }
            //    db.SaveChanges();
            //}

            //var i = 0;
            //using (var db = new OlympicDB())
            //{
            //    foreach (var item in db.Athlet.ToList())
            //    {
            //        if (i < 5) item.ImagePath = @"Image\AthlethImage\1.jfif";
            //        else if (i < 10) item.ImagePath = @"Image\AthlethImage\2.jfif";
            //        else if (i < 15) item.ImagePath = @"Image\AthlethImage\3.jpg";
            //        else if (i < 20) item.ImagePath = @"Image\AthlethImage\4.jpg";
            //        else if (i < 25) item.ImagePath = @"Image\AthlethImage\5.webp";
            //        else if (i < 30) item.ImagePath = @"Image\AthlethImage\6.jpg";
            //        else if (i < 35) item.ImagePath = @"Image\AthlethImage\7.jpg";
            //        else if (i < 40) item.ImagePath = @"Image\AthlethImage\8.jpg";
            //        else if (i < 45) item.ImagePath = @"Image\AthlethImage\9.webp";
            //        else if (i < 50) item.ImagePath = @"Image\AthlethImage\10.jpg";
            //        else if (i < 55) item.ImagePath = @"Image\AthlethImage\11.jpg";
            //        else if (i < 60) item.ImagePath = @"Image\AthlethImage\12.jpg";
            //        else if (i < 65) item.ImagePath = @"Image\AthlethImage\13.jpg";
            //        else if (i < 70) item.ImagePath = @"Image\AthlethImage\14.jpg";
            //        else if (i < 75) item.ImagePath = @"Image\AthlethImage\15.jpg";
            //        else if (i < 80) item.ImagePath = @"Image\AthlethImage\16.jpg";
            //        else if (i < 85) item.ImagePath = @"Image\AthlethImage\17.jpg";
            //        else if (i < 90) item.ImagePath = @"Image\AthlethImage\18.jpg";
            //        else if (i < 95) item.ImagePath = @"Image\AthlethImage\19.jpg";
            //        else if (i < 100) item.ImagePath = @"Image\AthlethImage\20.jpg";
            //        i++;
            //    }
            //    db.SaveChanges();
            //}



            //////////
            Container = new Container();

            Container.RegisterSingleton<Messenger>();
            Container.RegisterSingleton<SportsVM>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<ResultVM>();
            Container.RegisterSingleton<TeamNocVM>();
            Container.RegisterSingleton<AthletsVM>();
            Container.RegisterSingleton<BestOfVM>();
            Container.RegisterSingleton<InfoSportVM>();
            Container.RegisterSingleton<InfoCathegoryVM>();
            Container.RegisterSingleton<AllAthletsVM>();
            Container.RegisterSingleton<InfoAthletVM>();


            base.OnStartup(e);
        }
    }
}
