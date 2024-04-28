using System;
using System.Collections.Generic;

namespace HeThongNgheNhac.Models;

public partial class AdminPlayList
{
    public int IdPlayListAdmin { get; set; }

    public int? IdAdmin { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual ICollection<AdminPlayListDetail> AdminPlayListDetails { get; set; } = new List<AdminPlayListDetail>();

    public virtual Admin? IdAdminNavigation { get; set; }
}
