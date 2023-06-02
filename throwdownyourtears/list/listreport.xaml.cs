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
    /// Логика взаимодействия для listreport.xaml
    /// </summary>
#pragma warning disable CS8981 // Имя типа "listreport" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    public partial class listreport : Page
#pragma warning restore CS8981 // Имя типа "listreport" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    {
        public List<Generalsales> Generalsales { get; set; }
        public List<buywant> buywant { get; set; }
        public Product Product { get; set; }
        


        public listreport()
        {
            InitializeComponent();
            using (ThrowdownyourtearsContext db = new ThrowdownyourtearsContext())
            {
                int generalquantity1 = db.Products.Sum(u => u.Productsales);
                int generalgain1 = db.Products.Sum(u => u.Productgain);
            } 
            buywant = Database.GetInstance().Getbuywant();
            Generalsales = Database.GetInstance().GetGeneralsales();

            //Generalsales = Database.GetInstance().GetGeneralsales();
            DataContext = this;

        }

        private void productbuy(object sender, RoutedEventArgs e)
        {

        }
    }
}
