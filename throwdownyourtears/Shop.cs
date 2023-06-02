using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Shop
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual Product? Product { get; set; }
    public virtual ICollection<Productshop> Productshops { get; } = new List<Productshop>();
}
