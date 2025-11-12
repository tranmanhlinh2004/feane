using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class BookTable
{
    public int BookId { get; set; }

    public int? AccountId { get; set; }

    public DateTime? BookDate { get; set; }

    public int? MountOfPeople { get; set; }

    public string? Note { get; set; }

    public virtual Account? Account { get; set; }
}
