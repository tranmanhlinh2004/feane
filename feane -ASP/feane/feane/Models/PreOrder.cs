using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class PreOrder
{
    public int OrderId { get; set; }

    public int AccountId { get; set; }

    public string? Address { get; set; }

    public string? OrderStatus { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
