using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public string? Minimum { get; set; }

    public string? Quantity { get; set; }

    public string? PurchasePrice { get; set; }

    public virtual Provider IdNavigation { get; set; } = null!;

    public virtual Shop? Shop { get; set; }
}
