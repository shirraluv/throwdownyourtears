using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
using throwdownyourtears.product;

namespace throwdownyourtears.list
{
    /// <summary>
    /// Логика взаимодействия для listproduct.xaml
    /// </summary>
#pragma warning disable CS8981 // Имя типа "listproduct" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    public partial class listproduct : Page
#pragma warning restore CS8981 // Имя типа "listproduct" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    {
        public List<Provider> Providers { get; set; }
        public List<Product> Data { get; set; }
        public Product SelectedData { get; set; }
        public List<Productsprovider> productsprovider { get; set; } 

        public listproduct()
        {
            InitializeComponent();
            Providers = Database.GetInstance().GetProvider();
            Data = Database.GetInstance().GetProduct();
            DataContext = this;

        }

        private void productadd(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new product.addproduct();
        }

        private void productdelete(object sender, RoutedEventArgs e)
        {
            Database.GetInstance().DeleteProduct(SelectedData);
        }

        private void selectprovider(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new product.selectprovider(SelectedData);
        }

        private void productadd2(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new product.addproduct(SelectedData);
        }

        private void purchaseproducts(object sender, RoutedEventArgs e)
        {
            if(SelectedData!= null) 
            {
                var db = Database.GetInstance();
                SelectedData.Quantity++;
                db.AddData3(SelectedData);
                xyi.ItemsSource = Database.GetInstance().GetProduct();
            }
            else
            {
                MessageBox.Show("Выберите товар");
            }
        }
    }
}
