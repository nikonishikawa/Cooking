using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingClassLibrary.Dto
{
    public class UserRatingAndReviewDto
    {
        public long UserRatingAndReviewId { get; set; }

        public long UserId { get; set; }

        public long RecipeId { get; set; }

        public long ReviewsId { get; set; }

        public long RatingId { get; set; }
    }
}
