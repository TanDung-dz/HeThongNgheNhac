using System;
using System.Collections.Generic;

namespace HeThongNgheNhac.Models;

public partial class SlideShow
{
    public int IdSlideShow { get; set; }

    public string? Img { get; set; }

    public string? Text { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public int? IdAdmin { get; set; }

    public virtual Admin? IdAdminNavigation { get; set; }
}
