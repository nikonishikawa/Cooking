using System;
using System.Collections.Generic;

namespace Cooking.Entities;

public partial class TblCategory
{
    public long CategoryId { get; set; }

    public string Category { get; set; } = null!;

    public virtual ICollection<TblIngredient> TblIngredients { get; set; } = new List<TblIngredient>();
}
