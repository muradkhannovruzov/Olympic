using GalaSoft.MvvmLight.Command;
using OlympicApp.Model;
using OlympicApp.Repository;
using OlympicApp.Service;
using OlympicApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OlympicApp.View
{
    /// <summary>
    /// Interaction logic for AthletInfo.xaml
    /// </summary>
    public partial class AthletInfo : Window
    {
       
        public AthletInfo(int athlet)
        {
            InitializeComponent();
            DataContext = new AthletInfoVM(athlet);
           
        }
       
    }
}
