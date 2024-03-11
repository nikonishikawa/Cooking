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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService _ReviewsService;

        public ReviewsController(IReviewsService ReviewsService)
        {
            _ReviewsService = ReviewsService;
        }
        [HttpPost("InsertReviews")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertReviews(ReviewsDto dto)
        {
            try
            {
                var res = await _ReviewsService.InsertReviews(dto);
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
        [HttpGet("GetReviews/{reviewsId}")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblReview>>>> GetReviews(long reviewsId)
        {
            try
            {
                var res = await _ReviewsService.GetReviews(reviewsId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblReview>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateReviews")]
        public async Task<ApiResponseMessage<string>> UpdateReviews(ReviewsDto dto)
        {
            try
            {
                var res = await _ReviewsService.UpdateReviews(dto);
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
        public async Task<ApiResponseMessage<string>> DeleteReviews(ReviewsDto dto)
        {
            try
            {
                var res = await _ReviewsService.DeleteReviews(dto);
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
