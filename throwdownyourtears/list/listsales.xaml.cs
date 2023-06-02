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

namespace throwdownyourtears.list
{
    /// <summary>
    /// Логика взаимодействия для listsales.xaml
    /// </summary>
#pragma warning disable CS8981 // Имя типа "listsales" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    public partial class listsales : Page
#pragma warning restore CS8981 // Имя типа "listsales" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    {
        public List<Product> Data { get; set; }
        public Product SelectedData { get; set; }

        public listsales()
        {
            InitializeComponent();
            Data = Database.GetInstance().GetProduct();
            DataContext = this;
        }

        private void opensale(object sender, RoutedEventArgs e)
        {
            if (SelectedData != null)
            {
                if (SelectedData.Quantity > 0)
                {
                    var db = Database.GetInstance();
                    SelectedData.Productgain++;
                    SelectedData.Productsales++;
                    SelectedData.Quantity--;
                    db.AddData2(SelectedData);
                    xyi2.ItemsSource = Database.GetInstance().GetProduct();
                }
                else
                {
                    MessageBox.Show("Товар закончился");
                }
            }
            else
            {
                MessageBox.Show("Выберите товар");
            }

        }
    }
}
