using System;
using System.Collections.Generic;

namespace CookingClassLibrary.Entities;

public partial class TblAllergen
{
    public long AllergenId { get; set; }

    public long IngredientId { get; set; }

    public string AllergenType { get; set; } = null!;

    public virtual TblIngredient Ingredient { get; set; } = null!;
}
