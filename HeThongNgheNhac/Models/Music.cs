using System;
using System.Collections.Generic;

namespace HeThongNgheNhac.Models;

public partial class Music
{
    public int IdMusic { get; set; }

    public int? IdMusictype { get; set; }

    public int? IdAdmin { get; set; }

    public int? IdSinger { get; set; }

    public int? IdAuthor { get; set; }

    public string? Name { get; set; }

    public DateTime? PublishDate { get; set; }

    public string? Thumbnail { get; set; }

    public string? File { get; set; }

    public string? Lyric { get; set; }

    public int? CountListened { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual ICollection<AdminPlayListDetail> AdminPlayListDetails { get; set; } = new List<AdminPlayListDetail>();

    public virtual Admin? IdAdminNavigation { get; set; }

    public virtual Author? IdAuthorNavigation { get; set; }

    public virtual MusicType? IdMusictypeNavigation { get; set; }

    public virtual Singer? IdSingerNavigation { get; set; }

    public virtual ICollection<UserPlayListDetail> UserPlayListDetails { get; set; } = new List<UserPlayListDetail>();
}
