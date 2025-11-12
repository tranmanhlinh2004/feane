using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class SubMenu
{
    public int SubMenuId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? Levels { get; set; }

    public int? Position { get; set; }

    public int? ParentMenuId { get; set; }

    public virtual ParentMenu? ParentMenu { get; set; }
}
