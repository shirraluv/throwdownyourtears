using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Quantityofsale
{
    public int Id { get; set; }

    public string? Gain { get; set; }

    public string? Quantity2 { get; set; }

    public virtual Shop? Shop { get; set; }
}
