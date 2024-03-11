using System;
using System.Collections.Generic;

namespace Cooking.Entities;

public partial class TblCuisine
{
    public long CuisineId { get; set; }

    public string Cuisine { get; set; } = null!;
}
