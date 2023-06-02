using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace throwdownyourtears.menu
{
    /// <summary>
    /// Логика взаимодействия для salemenu.xaml
    /// </summary>
#pragma warning disable CS8981 // Имя типа "salemenu" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    public partial class salemenu : Page
#pragma warning restore CS8981 // Имя типа "salemenu" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    {
        public Product AddData { get; set; }
        public List<Generalsales> Generalsale { get; set; }
        public List<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        public Shop SelectedShop { get; set; }
        public salemenu()
        {
            InitializeComponent();
            AddData = new Product();
            Products = Database.GetInstance().GetProduct();
            DataContext = this;
        }

        public salemenu(Product addData)
        {
            InitializeComponent();
            AddData = addData;
            Products = Database.GetInstance().GetProduct();
            DataContext = this;
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new list.listsales();
        }

        private void sale(object sender, RoutedEventArgs e)
        {

        }

    }


}
