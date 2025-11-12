using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? AccountId { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Account? Account { get; set; }
}
