using System;
using System.Collections.Generic;

namespace CookingClassLibrary.Entities;

public partial class TblProduce
{
    public long ProduceId { get; set; }

    public string Produce { get; set; } = null!;

    public virtual ICollection<TblSeasonalAvailability> TblSeasonalAvailabilities { get; set; } = new List<TblSeasonalAvailability>();
}
