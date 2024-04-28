using System;
using System.Collections.Generic;

namespace HeThongNgheNhac.Models;

public partial class AdminPlayListDetail
{
    public int IdPlayListAdmin { get; set; }

    public int IdMusic { get; set; }

    public DateTime? Date { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual Music IdMusicNavigation { get; set; } = null!;

    public virtual AdminPlayList IdPlayListAdminNavigation { get; set; } = null!;
}
