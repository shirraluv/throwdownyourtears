using System;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;

namespace throwdownyourtears
{
    public partial class Provider
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Telegramid { get; set; }

        public virtual Product? Product { get; set; }

        public virtual ICollection<Productsprovider> Productsproviders { get; } = new List<Productsprovider>();
    }
}
