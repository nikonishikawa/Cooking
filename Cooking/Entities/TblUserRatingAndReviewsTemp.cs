using System;
using System.Collections.Generic;

namespace Cooking.Entities;

public partial class TblUserRatingAndReviewsTemp
{
    public long UserRatingAndReviewTempId { get; set; }

    public long UserId { get; set; }

    public long RecipeId { get; set; }

    public long ReviewsId { get; set; }

    public string Review { get; set; } = null!;

    public long RatingId { get; set; }

    public decimal Rating { get; set; }
}
