﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace throwdownyourtears.list
{
    /// <summary>
    /// Логика взаимодействия для listreport.xaml
    /// </summary>
#pragma warning disable CS8981 // Имя типа "listreport" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    public partial class listreport : Page
#pragma warning restore CS8981 // Имя типа "listreport" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    {
        public listreport()
        {
            InitializeComponent();
        }

        private void clickOpenmainwindow(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentWindow = new MainWindow();
        }


        private void sendmessage(object sender, RoutedEventArgs e)
        {

        }
    }
}
