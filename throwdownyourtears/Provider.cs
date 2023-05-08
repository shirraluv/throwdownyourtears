using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Provider
{
    public int Id1 { get; set; }

    public string? Name1 { get; set; }

    public string? Telegramid { get; set; }

    public virtual Product? Product { get; set; }
}
