using CookingClassLibrary.APIResponse;
using CookingClassLibrary.Dto;
using CookingClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CookingClassLibrary.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly CookingDbContext _dbContext;

        public ReviewsService(CookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertReviews(ReviewsDto dto)
        {
            try
            {
                var _insertReviews = new TblReview
                {
                    Review = dto.Review
                };

                await _dbContext.TblReviews.AddAsync(_insertReviews);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Reviews Data",
                    IsSuccess = true,
                    Message = ""
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<IList<TblReview>>> GetReviews(long reviewsId)
        {
            try
            {
                var _data = await _dbContext.TblReviews
                    .Where(x => x.ReviewsId == reviewsId)
                    .Select(x => new TblReview
                    {
                        ReviewsId = x.ReviewsId,
                        Review = x.Review
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblReview>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblReview>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateReviews(ReviewsDto dto)
        {
            try
            {

                var ReviewsToUpdate = await _dbContext.TblReviews.FirstOrDefaultAsync(x => x.ReviewsId == dto.ReviewsId);

                if (ReviewsToUpdate != null)
                {

                    ReviewsToUpdate.Review = dto.Review;

                    _dbContext.TblReviews.Update(ReviewsToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Updated Successfully madafaka",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }
                else
                {
                    var res = new ApiResponseMessage<string>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"Reviews with ID {dto.ReviewsId} not found"
                    };

                    return res;
                }
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

        public async Task<ApiResponseMessage<string>> DeleteReviews(ReviewsDto dto)
        {
            try
            {

                var ReviewsToDelete = await _dbContext.TblReviews.FirstOrDefaultAsync(x => x.ReviewsId == dto.ReviewsId);

                if (ReviewsToDelete != null)
                {

                    ReviewsToDelete.Review = dto.Review;

                    _dbContext.TblReviews.Remove(ReviewsToDelete);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Deleted Successfully madafaka",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }
                else
                {
                    var res = new ApiResponseMessage<string>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"Reviews with ID {dto.ReviewsId} not found"
                    };

                    return res;
                }
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
