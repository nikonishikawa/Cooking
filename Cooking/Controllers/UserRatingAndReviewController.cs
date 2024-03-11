using CookingClassLibrary.APIResponse;
using CookingClassLibrary.Dto;
using CookingClassLibrary.Entities;
using CookingClassLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cooking.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserRatingAndReviewController : ControllerBase
    {
        private readonly IUserRatingAndReviewService _UserRatingAndReviewService;

        public UserRatingAndReviewController(IUserRatingAndReviewService UserRatingAndReviewService)
        {
            _UserRatingAndReviewService = UserRatingAndReviewService;
        }

        //[HttpPost("InsertUserRatingAndReview")]
        //public async Task<ActionResult<ApiResponseMessage<string>>> InsertUserRatingAndReview(UserRatingAndReviewTempDto dto)
        //{
        //    try
        //    {
        //        var res = await _userRatingAndReviewTempService.InsertUserRatingAndReviewTemp(dto);
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in InsertName: {ex.Message}");
        //        Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
        //        Console.WriteLine($"Stack Trace: {ex.StackTrace}");

        //        var res = new ApiResponseMessage<string>
        //        {
        //            Data = "",
        //            IsSuccess = false,
        //            Message = ex.Message
        //        };

        //        return res;
        //    }
        //}

        [HttpGet("GetUserRatingAndReview/{UserRatingAndReviewId}")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblUserRatingAndReview>>>> GetUserRatingAndReview(long UserRatingAndReviewId)
        {
            try
            {
                var res = await _UserRatingAndReviewService.GetUserRatingAndReview(UserRatingAndReviewId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblUserRatingAndReview>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateUserRatingAndReview")]
        public async Task<ApiResponseMessage<string>> UpdateUserRatingAndReview(UserRatingAndReviewDto dto)
        {
            try
            {
                var res = await _UserRatingAndReviewService.UpdateUserRatingAndReview(dto);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpDelete("DeleteCredential")]
        public async Task<ApiResponseMessage<string>> DeleteUserRatingAndReview(UserRatingAndReviewDto dto)
        {
            try
            {
                var res = await _UserRatingAndReviewService.DeleteUserRatingAndReview(dto);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
    }
}
