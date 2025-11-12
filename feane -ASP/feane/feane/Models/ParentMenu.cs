using System;
using System.Collections.Generic;

namespace feane.Models;

public partial class ParentMenu
{
    public int ParentMenuId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? Levels { get; set; }

    public int? Position { get; set; }

    public virtual ICollection<SubMenu> SubMenus { get; set; } = new List<SubMenu>();
}
