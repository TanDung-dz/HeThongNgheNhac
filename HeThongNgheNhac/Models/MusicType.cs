using System;
using System.Collections.Generic;

namespace HeThongNgheNhac.Models;

public partial class MusicType
{
    public int IdMusicType { get; set; }

    public string? Name { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual ICollection<Music> Musics { get; set; } = new List<Music>();
}
