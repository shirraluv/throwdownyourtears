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
    /// Логика взаимодействия для addprovider.xaml
    /// </summary>
    public partial class addprovider : Page
    {
        public List<Provider> Providers = new List<Provider>();
        public Provider Edit { get; set; }
        public addprovider()
        {
            InitializeComponent();
            Edit = new Provider();
            DataContext = this;
        }
        public addprovider(Provider edit)
        {
            InitializeComponent();
            Edit = edit;
            DataContext = this;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var db = Database.GetInstance();
            if (Edit.Id == 0)
            {
                db.AddData(Edit);
            }
            else
            {
                db.EditData(Edit);
            }
            Navigation.GetInstance().CurrentPage = new list.listproduct();
        }
    }
}
