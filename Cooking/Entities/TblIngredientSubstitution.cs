using System;
using System.Collections.Generic;

namespace Cooking.Entities;

public partial class TblIngredientSubstitution
{
    public long IngredientSubstitutionId { get; set; }

    public string Ingredient { get; set; } = null!;

    public long SubstituteIngredientId { get; set; }

    public virtual TblIngredient SubstituteIngredient { get; set; } = null!;
}
