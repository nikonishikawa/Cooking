using System;
using System.Collections.Generic;

namespace CookingClassLibrary.Entities;

public partial class TblSeasonalAvailability
{
    public long SeasonalAvailabilityId { get; set; }

    public long ProduceId { get; set; }

    public long SeasonId { get; set; }

    public virtual TblProduce Produce { get; set; } = null!;

    public virtual TblSeason Season { get; set; } = null!;
}
