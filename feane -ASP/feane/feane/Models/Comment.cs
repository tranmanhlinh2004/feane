using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? AccountId { get; set; }

    public string? Content { get; set; }

    public DateTime? CommentDate { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<BlogDetail> BlogDetails { get; set; } = new List<BlogDetail>();
}
