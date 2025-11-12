using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class BlogDetail
{
    public int BlogDetailId { get; set; }

    public int? BlogId { get; set; }

    public int? CommentId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? EditedDate { get; set; }

    public string? EditedBy { get; set; }

    public virtual Blog? Blog { get; set; }

    public virtual Comment? Comment { get; set; }
}
