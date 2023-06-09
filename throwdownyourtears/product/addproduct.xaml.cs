﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public List<Shop> Shops { get; set; }

        public List<Provider> Providers { get; set; }
        public Provider SelectedProvider { get; set; }
        public List<Product> Products { get; set; }

        public addproduct()
        {
            InitializeComponent();
            Edit = new Product();
            Providers = Database.GetInstance().GetProvider();
            Products = Database.GetInstance().GetProduct();
            Shops = Database.GetInstance().GetShop();
            DataContext = this;
        }

        public addproduct(Product edit)
        {
            InitializeComponent();
            Edit = edit;
            Providers = Database.GetInstance().GetProvider();
            Products = Database.GetInstance().GetProduct();
            Shops = Database.GetInstance().GetShop();
            DataContext = this;
        }


        private void Save(object sender, RoutedEventArgs e)
        {


            var db = Database.GetInstance();
            int id = 0;
            if (Edit.Id == 0)
            {
                db.AddData(Edit);
                id = Edit.Id;
            }
            else
            {
                db.EditData(Edit);
            }

            Navigation.GetInstance().CurrentPage = new list.listproduct();

        }

    }
}

