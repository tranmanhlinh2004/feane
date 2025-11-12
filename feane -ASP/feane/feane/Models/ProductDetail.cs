using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class ProductDetail
{
    public int ProductDetailId { get; set; }

    public int? ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public decimal? Price { get; set; }

    public int? Sold { get; set; }

    public int? Star { get; set; }

    public virtual Product? Product { get; set; }
}
