using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Shop
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual Quantityofsale Id1 { get; set; } = null!;

    public virtual Product IdNavigation { get; set; } = null!;
}
