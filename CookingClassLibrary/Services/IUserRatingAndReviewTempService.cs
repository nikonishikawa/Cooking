using CookingClassLibrary.APIResponse;
using CookingClassLibrary.Dto;
using CookingClassLibrary.Entities;

namespace CookingClassLibrary.Services
{
    public interface IUserRatingAndReviewTempService
    {
        Task<ApiResponseMessage<string>> DeleteUserRatingAndReviewTemp(UserRatingAndReviewTempDto dto);
        Task<ApiResponseMessage<IList<TblUserRatingAndReviewTemp>>> GetUserRatingAndReviewTemp(long UserRatingAndReviewTempId);
        Task<ApiResponseMessage<TblUserRatingAndReviewTemp>> InsertUserRatingAndReviewTemp(UserRatingAndReviewTempDto dto);
        Task<ApiResponseMessage<string>> UpdateUserRatingAndReviewTemp(UserRatingAndReviewTempDto dto);
    }
}