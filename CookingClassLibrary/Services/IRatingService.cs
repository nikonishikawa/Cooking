using CookingClassLibrary.APIResponse;
using CookingClassLibrary.Dto;
using CookingClassLibrary.Entities;

namespace CookingClassLibrary.Services
{
    public interface IRatingService
    {
        Task<ApiResponseMessage<string>> DeleteRating(RatingDto dto);
        Task<ApiResponseMessage<IList<TblRating>>> GetRating(long RatingId);
        Task<ApiResponseMessage<string>> InsertRating(RatingDto dto);
        Task<ApiResponseMessage<string>> UpdateRating(RatingDto dto);
    }
}