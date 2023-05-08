using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public List<Product> Data { get; set; }
        public Product SelectedData { get; set; }

        public listproduct()
        {
            InitializeComponent();
            Data = DB.GetInstance().GetProduct();
            DataContext = this;

        }

        private void productadd(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new product.addproduct();
        }

        private void productdelete(object sender, RoutedEventArgs e)
        {

        }
    }
}
