using System;
using System.Collections.Generic;

namespace HeThongNgheNhac.Models;

public partial class UserPlayList
{
    public int IdPlayListUser { get; set; }

    public int? IdUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Name { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<UserPlayListDetail> UserPlayListDetails { get; set; } = new List<UserPlayListDetail>();
}
