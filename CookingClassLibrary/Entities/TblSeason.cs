using System;
using System.Collections.Generic;

namespace CookingClassLibrary.Entities;

public partial class TblSeason
{
    public long SeasonId { get; set; }

    public string Season { get; set; } = null!;

    public virtual ICollection<TblSeasonalAvailability> TblSeasonalAvailabilities { get; set; } = new List<TblSeasonalAvailability>();
}
