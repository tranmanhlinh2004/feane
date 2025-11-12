using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quanlity { get; set; }

    public decimal? Price { get; set; }

    public virtual PreOrder? Order { get; set; }

    public virtual Product? Product { get; set; }
}
