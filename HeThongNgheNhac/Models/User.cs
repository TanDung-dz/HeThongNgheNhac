using System;
using System.Collections.Generic;

namespace HeThongNgheNhac.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool? Hide { get; set; }

    public string? Link { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<UserPlayList> UserPlayLists { get; set; } = new List<UserPlayList>();
}
