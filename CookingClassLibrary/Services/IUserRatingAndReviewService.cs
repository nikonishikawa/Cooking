using CookingClassLibrary.APIResponse;
using CookingClassLibrary.Dto;
using CookingClassLibrary.Entities;

namespace CookingClassLibrary.Services
{
    public interface IUserRatingAndReviewService
    {
        Task<ApiResponseMessage<string>> DeleteUserRatingAndReview(UserRatingAndReviewDto dto);
        Task<ApiResponseMessage<IList<TblUserRatingAndReview>>> GetUserRatingAndReview(long UserRatingAndReviewId);
        Task<ApiResponseMessage<string>> InsertUserRatingAndReview(UserRatingAndReviewDto dto);
        Task<ApiResponseMessage<string>> UpdateUserRatingAndReview(UserRatingAndReviewDto dto);
    }
}