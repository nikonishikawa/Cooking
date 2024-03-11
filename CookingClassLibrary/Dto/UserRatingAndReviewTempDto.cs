using CookingClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingClassLibrary.Dto
{
    public class UserRatingAndReviewTempDto
    {
        public long UserRatingAndReviewTempId { get; set; }

        public long UserId { get; set; }

        public long RecipeId { get; set; }

        public long ReviewsId { get; set; }

        public long RatingId { get; set; }

        public virtual TblRating Rating { get; set; } = null!;

        public virtual TblRecipe? Recipe { get; set; } = null!;

        public virtual TblReview Reviews { get; set; } = null!;

        public virtual TblUser? User { get; set; } = null!;
    }
}
