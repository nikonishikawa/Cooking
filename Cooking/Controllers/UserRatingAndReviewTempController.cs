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
    public class UserRatingAndReviewTempController : ControllerBase
    {
        private readonly IUserRatingAndReviewTempService _UserRatingAndReviewTempService;

        public UserRatingAndReviewTempController(IUserRatingAndReviewTempService UserRatingAndReviewTempService)
        {
            _UserRatingAndReviewTempService = UserRatingAndReviewTempService;
        }

        [HttpPost("InsertUserRatingAndReviewTemp")]
        public async Task<ActionResult<ApiResponseMessage<TblUserRatingAndReviewTemp>>> InsertUserRatingAndReviewTemp(UserRatingAndReviewTempDto dto)
        {
            try
            {
                var res = await _UserRatingAndReviewTempService.InsertUserRatingAndReviewTemp(dto);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertName: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                var res = new ApiResponseMessage<TblUserRatingAndReviewTemp>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpGet("GetUserRatingAndReviewTemp/{UserRatingAndReviewTempId}")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblUserRatingAndReviewTemp>>>> GetUserRatingAndReviewTemp(long UserRatingAndReviewTempId)
        {
            try
            {
                var res = await _UserRatingAndReviewTempService.GetUserRatingAndReviewTemp(UserRatingAndReviewTempId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblUserRatingAndReviewTemp>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateUserRatingAndReviewTemp")]
        public async Task<ApiResponseMessage<string>> UpdateUserRatingAndReviewTemp(UserRatingAndReviewTempDto dto)
        {
            try
            {
                var res = await _UserRatingAndReviewTempService.UpdateUserRatingAndReviewTemp(dto);
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
        public async Task<ApiResponseMessage<string>> DeleteUserRatingAndReviewTemp(UserRatingAndReviewTempDto dto)
        {
            try
            {
                var res = await _UserRatingAndReviewTempService.DeleteUserRatingAndReviewTemp(dto);
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
