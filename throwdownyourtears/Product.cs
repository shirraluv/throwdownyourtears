using System;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;

namespace throwdownyourtears
{

    public partial class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Price { get; set; }

        public string? Minimum { get; set; }

        public int Quantity { get; set; }

        public string? PurchasePrice { get; set; }

        public int Productsales { get; set; }

        public int Productbuys { get; set; }

        public int Productgain2 { get; set; }

        public int Productgain { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Provider> Providers { get; set; } = new List<Provider>();
        public List<Shop> Shops { get; set; } = new List<Shop>();

        public virtual ICollection<Productshop> Productshops { get; } = new List<Productshop>();

        public virtual ICollection<Productsprovider> Productsproviders { get; } = new List<Productsprovider>();
    }
}
