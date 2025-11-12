using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<BookTable> BookTables { get; set; } = new List<BookTable>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<PreOrder> PreOrders { get; set; } = new List<PreOrder>();

    public virtual Role? Role { get; set; }
}
