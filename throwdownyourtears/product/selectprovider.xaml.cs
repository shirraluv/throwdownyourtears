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

namespace throwdownyourtears.product
{
    /// <summary>
    /// Логика взаимодействия для selectprovider.xaml
    /// </summary>
    public partial class selectprovider : Page
    {
        public Product Edit { get; set; }
        public List<Shop> Shops { get; set; }

        public List<Provider> Providers { get; set; }
        public Provider SelectedProvider { get; set; }
        public List<Product> Products { get; set; }

        public selectprovider()
        {
            InitializeComponent();
            Edit = new Product();
            Providers = Database.GetInstance().GetProvider();
            Products = Database.GetInstance().GetProduct();
            DataContext = this;
        }

        public selectprovider(Product edit)
        {
            InitializeComponent();
            Edit = edit;
            Providers = Database.GetInstance().GetProvider();
            Products = Database.GetInstance().GetProduct();
            DataContext = this;
        }


        private void Save(object sender, RoutedEventArgs e)
        {

            List<int> b = new List<int>();
            foreach (var a in providers.SelectedItems)
                b.Add(((Provider)a).Id);

            var db = Database.GetInstance();
            int id = 0;
            if (Edit.Id == 0)
            {
                MessageBox.Show("Выберите товар");
            }
            else
            {
                id = Edit.Id;
                db.GetProductProvider(id, b);
            }
            
            Navigation.GetInstance().CurrentPage = new list.listproduct();

        }

        private void addprovider(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new product.addprovider();
        }
    }
}
