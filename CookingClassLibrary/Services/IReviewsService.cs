using CookingClassLibrary.APIResponse;
using CookingClassLibrary.Dto;
using CookingClassLibrary.Entities;

namespace CookingClassLibrary.Services
{
    public interface IReviewsService
    {
        Task<ApiResponseMessage<IList<TblReview>>> GetReviews(long reviewsId);
        Task<ApiResponseMessage<string>> InsertReviews(ReviewsDto dto);
        Task<ApiResponseMessage<string>> UpdateReviews(ReviewsDto dto);
        Task<ApiResponseMessage<string>> DeleteReviews(ReviewsDto dto);
    }
}