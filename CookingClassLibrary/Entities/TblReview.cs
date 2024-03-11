using System;
using System.Collections.Generic;

namespace CookingClassLibrary.Entities;

public partial class TblReview
{
    public long ReviewsId { get; set; }

    public string Review { get; set; } = null!;

    public virtual ICollection<TblUserRatingAndReview> TblUserRatingAndReviews { get; set; } = new List<TblUserRatingAndReview>();

    public ICollection<TblUserRatingAndReviewTemp> TblUserRatingAndReviewTemp { get; set; }
}
