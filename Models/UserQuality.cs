using System;
using System.Collections.Generic;

namespace colol2.Models;

public partial class UserQuality
{
    public int IdUser { get; set; }

    public int IdQuality { get; set; }

    public virtual PersonalityQuality IdQualityNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
