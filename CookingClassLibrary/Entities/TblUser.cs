using System;
using System.Collections.Generic;

namespace CookingClassLibrary.Entities;

public partial class TblUser
{
    public long UserId { get; set; }

    public string Username { get; set; } = null!;

    public long CredentialsId { get; set; }

    public virtual TblCredential Credentials { get; set; } = null!;

    public virtual ICollection<TblUserRatingAndReview> TblUserRatingAndReviews { get; set; } = new List<TblUserRatingAndReview>();
}
