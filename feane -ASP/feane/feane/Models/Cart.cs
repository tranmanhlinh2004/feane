using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int? ProductId { get; set; }

    public int? Quanlity { get; set; }

    public decimal? Price { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Product? Product { get; set; }
}
