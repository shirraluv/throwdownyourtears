using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using throwdownyourtears.list;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace throwdownyourtears
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = Navigation.GetInstance();
            InitializeComponent();

            //Database.GetInstance().TestConnection();
        }

        private void clickOpenlistproduct(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new listproduct();
        }

        private void clickOpenlistsales(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new listsales();
        }

        private void clickOpenlistreport(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new listreport();
        }
    }
}
