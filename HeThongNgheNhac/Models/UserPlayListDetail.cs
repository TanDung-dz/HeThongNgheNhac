using System;
using System.Collections.Generic;

namespace HeThongNgheNhac.Models;

public partial class UserPlayListDetail
{
    public int IdMusic { get; set; }

    public int IdPlayListUser { get; set; }

    public DateTime? Date { get; set; }

    public string? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual Music IdMusicNavigation { get; set; } = null!;

    public virtual UserPlayList IdPlayListUserNavigation { get; set; } = null!;
}
