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
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService RatingService)
        {
            _ratingService = RatingService;
        }
        [HttpPost("InsertRating")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertRating(RatingDto dto)
        {
            try
            {
                var res = await _ratingService.InsertRating(dto);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertName: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpGet("GetRating/{RatingId}")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblRating>>>> GetRating(long RatingId)
        {
            try
            {
                var res = await _ratingService.GetRating(RatingId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblRating>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateRating")]
        public async Task<ApiResponseMessage<string>> UpdateRating(RatingDto dto)
        {
            try
            {
                var res = await _ratingService.UpdateRating(dto);
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
        public async Task<ApiResponseMessage<string>> DeleteRating(RatingDto dto)
        {
            try
            {
                var res = await _ratingService.DeleteRating(dto);
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
