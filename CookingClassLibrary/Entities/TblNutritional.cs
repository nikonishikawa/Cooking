using System;
using System.Collections.Generic;

namespace CookingClassLibrary.Entities;

public partial class TblNutritional
{
    public long NutritionalId { get; set; }

    public long IngredientId { get; set; }

    public decimal Calories { get; set; }

    public decimal Protein { get; set; }

    public decimal Fats { get; set; }

    public decimal Carbohydrates { get; set; }

    public virtual TblIngredient Ingredient { get; set; } = null!;
}
