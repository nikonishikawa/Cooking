using System;
using System.Collections.Generic;

namespace Cooking.Entities;

public partial class TblIngredient
{
    public long IngredientId { get; set; }

    public string Ingredient { get; set; } = null!;

    public long CategoryId { get; set; }

    public string CommonUses { get; set; } = null!;

    public virtual TblCategory Category { get; set; } = null!;

    public virtual ICollection<TblAllergen> TblAllergens { get; set; } = new List<TblAllergen>();

    public virtual ICollection<TblIngredientSubstitution> TblIngredientSubstitutions { get; set; } = new List<TblIngredientSubstitution>();

    public virtual ICollection<TblNutritional> TblNutritionals { get; set; } = new List<TblNutritional>();

    public virtual ICollection<TblRecipe> TblRecipes { get; set; } = new List<TblRecipe>();
}
