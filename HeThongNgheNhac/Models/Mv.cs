using System;
using System.Collections.Generic;

namespace HeThongNgheNhac.Models;

public partial class Mv
{
    public int IdMv { get; set; }

    public int? IdSinger { get; set; }

    public string? Name { get; set; }

    public DateTime? PublishDate { get; set; }

    public int? CountView { get; set; }

    public virtual Singer? IdSingerNavigation { get; set; }
}
