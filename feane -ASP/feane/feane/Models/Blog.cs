using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Image { get; set; }

    public string? Descipption { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? EditedDate { get; set; }

    public string? EditedBy { get; set; }

    public virtual ICollection<BlogDetail> BlogDetails { get; set; } = new List<BlogDetail>();
}
