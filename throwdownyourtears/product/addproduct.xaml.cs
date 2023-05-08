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
    /// Логика взаимодействия для addproduct.xaml
    /// </summary>
    public partial class addproduct : Page
    {
        public Product Edit { get; set; }

        public List<Provider> Providers { get; set; }

        public addproduct()
        {
            InitializeComponent();
            Edit = new Product();
            DataContext = this;
            Providers = DB.GetInstance().GetProvider();
        }

        public addproduct(Product edit)
        {
            InitializeComponent();
            Edit = edit;
            DataContext = this;
            Providers = DB.GetInstance().GetProvider();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var db = DB.GetInstance();
            int id = 0;
            if (Edit.Id == 0)
            {
                id = db.GetNextID("products");
                id = db.GetNextID("provider");
                DB.GetInstance().AddData(Edit);
            }
            else
            {
                id = Edit.Id;
                DB.GetInstance().EditData(Edit);
            }
            Navigation.GetInstance().CurrentPage = new list.listproduct();
        }



    }
}

