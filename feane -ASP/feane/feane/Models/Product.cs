using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int? CategoryId { get; set; }

    public string? ProductName { get; set; }

    public string? Image { get; set; }

    public decimal? Price { get; set; }

    public string? Detail { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ProductCategory? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
}
