using System;
using System.Collections.Generic;

namespace CookingClassLibrary.Entities;

public partial class TblRating
{
    public long RatingId { get; set; }

    public decimal Rating { get; set; }

    public virtual ICollection<TblUserRatingAndReview> TblUserRatingAndReviews { get; set; } = new List<TblUserRatingAndReview>();


    public ICollection<TblUserRatingAndReviewTemp> TblUserRatingAndReviewTemp { get; set; }
}
