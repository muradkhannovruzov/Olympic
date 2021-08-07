using AdminApp.Repository;
using AdminApp.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using OlympicApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApp.ViewModel
{
    class RegisterVM : ViewModelBase
    {
        private List<Athlet> athlets;
        private RelayCommand saveCommand;
        private RelayCommand addImageCommand;
        private string shortName;
        private RelayCommand readCommand;
        private string imagePath;
        private IFileReader<Athlet> fileReader;
        private ICopyService copyService;
        private string countryName;

        public string ImagePath
        {
            get => imagePath;
            set
            {
                Set(ref imagePath, value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public string CountryName
        {
            get => countryName; set
            {
                Set(ref countryName, value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public List<Athlet> Athlets
        {
            get => athlets; set
            {
                Set(ref athlets, value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string ShortName
        {
            get => shortName;
            set
            {
                Set(ref shortName, value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public RegisterVM(IFileReader<Athlet> fileReader, ICopyService copyService)
        {
            this.copyService = copyService;
            this.fileReader = fileReader;
        }


        public RelayCommand ReadCommand => readCommand ?? (readCommand = new RelayCommand(() =>
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select a CSV file";
            fileDialog.Filter = "CSV FILE|*.csv";
            var result = fileDialog.ShowDialog();
            if (result == true)
            {
                Athlets = fileReader.ReadFile(fileDialog.FileName).ToList();
            }




        }));

        public RelayCommand AddImageCommand => addImageCommand ?? (addImageCommand = new RelayCommand(() =>
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select a image";
            fileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png;*.jfif|" +
                                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                "Portable Network Graphic (*.png)|*.png";
            var result = fileDialog.ShowDialog();
            if (result == true)
            {
                ImagePath = fileDialog.FileName;
            }
        }));


        public RelayCommand SaveCommand => saveCommand ?? (saveCommand = new RelayCommand(() =>
        {
            bool x = false;
            var dap = new ReadWithDapper();
            foreach (var item in dap.GetCountryName())
            {
                if (CountryName == item)
                {
                    x = true;
                    break;
                }
            }

            if (x) MessageBox.Show("Country name is already available");
            else
            {
                var country = new Country()
                {
                    Name = CountryName,
                    ShortName = ShortName,
                };

                var ex = Path.GetExtension(copyService.CreateNewFile(ImagePath, "Flags", CountryName));
                country.FlagPath = $@"Image\Flags\{CountryName}{ex}";

                using (var db = new OlympicDB())
                {

                    var genders = db.Gender.ToList();
                    var SportCat = db.SportCathegory.ToList();
                    foreach (var item in Athlets)
                    {
                        item.Country = country;
                        if (item.Gender.Id == 1) item.Gender = genders[0];
                        else if (item.Gender.Id == 2) item.Gender = genders[1];

                        item.Sport = db.Sport.FirstOrDefault(s => s.Name == item.Sport.Name);

                        if(item.Sport != null)
                        {
                            foreach (var sc in SportCat)
                            {
                                if(sc.Sport.Id == item.Sport.Id && sc.Gender.FemaleOrMale == item.Gender.FemaleOrMale)
                                {
                                    sc.Athlet.Add(item);
                                    item.SportCathegores.Add(sc);
                                }
                            }
                        }

                        if (item.ImagePath == "null" || string.IsNullOrWhiteSpace(item.ImagePath)) item.ImagePath = country.FlagPath;
                        else
                        {
                            var gid = Guid.NewGuid().ToString();
                            var extention = Path.GetExtension(copyService.CreateNewFile(ImagePath, "AthlethImage", gid));
                            item.ImagePath = $@"Image\AthlethImage\{gid}{extention}";
                        }
                        item.FlagPath = country.FlagPath;
                    }

                    country.Athlets.AddRange(Athlets);

                    db.Country.Add(country);
                    db.Athlet.AddRange(athlets);
                    db.SaveChanges();
                }

                CountryName = string.Empty;
                ShortName = string.Empty;
                ImagePath = string.Empty;
                Athlets = null;
            }
        }, () => !string.IsNullOrWhiteSpace(CountryName)
         && !string.IsNullOrWhiteSpace(ShortName)
         && !string.IsNullOrWhiteSpace(ImagePath)
         && Athlets != null));
    }
}
