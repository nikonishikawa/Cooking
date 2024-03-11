using System;
using System.Collections.Generic;

namespace CookingClassLibrary.Entities;

public partial class TblUserRatingAndReview
{
    public long UserRatingAndReviewId { get; set; }

    public long UserId { get; set; }

    public long RecipeId { get; set; }

    public long ReviewsId { get; set; }

    public long RatingId { get; set; }

    public virtual TblRating Rating { get; set; } = null!;

    public virtual TblRecipe Recipe { get; set; } = null!;

    public virtual TblReview Reviews { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;

    public ICollection<TblUserRatingAndReviewTemp> TblUserRatingAndReviewTemp { get; set; }
}
