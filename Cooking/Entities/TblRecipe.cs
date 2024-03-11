using System;
using System.Collections.Generic;

namespace Cooking.Entities;

public partial class TblRecipe
{
    public long RecipeId { get; set; }

    public string Recipe { get; set; } = null!;

    public long IngredientId { get; set; }

    public string Quantity { get; set; } = null!;

    public string Instructions { get; set; } = null!;

    public decimal CookingTime { get; set; }

    public virtual TblIngredient Ingredient { get; set; } = null!;

    public virtual ICollection<TblUserRatingAndReview> TblUserRatingAndReviews { get; set; } = new List<TblUserRatingAndReview>();
}
