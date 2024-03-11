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
    public class UserRatingAndReviewService : IUserRatingAndReviewService
    {
        private readonly CookingDbContext _dbContext;

        public UserRatingAndReviewService(CookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertUserRatingAndReview(UserRatingAndReviewDto dto)
        {
            try
            {
                var _insertUserRatingAndReview = new TblUserRatingAndReview
                {
                    UserRatingAndReviewId = dto.UserRatingAndReviewId,
                    UserId = dto.UserId,
                    RecipeId = dto.RecipeId,
                    ReviewsId = dto.ReviewsId,
                    RatingId = dto.RatingId,
                };

                var _insertUserRatingAndReviewTemp = await _dbContext.TblUserRatingAndReviewsTemps.Where(x => x.UserRatingAndReviewTempId == dto.RatingId).Select( x => new TblUserRatingAndReview
                {
                    UserId = x.UserId,
                    RecipeId = x.RecipeId,
                    RatingId = x.RatingId,
                    ReviewsId = x.ReviewsId
                }).ToListAsync();

                await _dbContext.TblUserRatingAndReviews.AddAsync(_insertUserRatingAndReview);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved UserRatingAndReview Data",
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

        public async Task<ApiResponseMessage<IList<TblUserRatingAndReview>>> GetUserRatingAndReview(long UserRatingAndReviewId)
        {
            try
            {
                var _data = await _dbContext.TblUserRatingAndReviews
                    .Where(x => x.UserRatingAndReviewId == UserRatingAndReviewId)
                    .Select(x => new TblUserRatingAndReview
                    {
                        UserRatingAndReviewId = x.UserRatingAndReviewId,
                        UserId = x.UserId,
                        RecipeId = x.RecipeId,
                        ReviewsId = x.ReviewsId,
                        RatingId = x.RatingId,
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblUserRatingAndReview>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "UserRatingAndReview Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblUserRatingAndReview>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateUserRatingAndReview(UserRatingAndReviewDto dto)
        {
            try
            {

                var UserRatingAndReviewToUpdate = await _dbContext.TblUserRatingAndReviews.FirstOrDefaultAsync(x => x.UserRatingAndReviewId == dto.UserRatingAndReviewId);

                if (UserRatingAndReviewToUpdate != null)
                {
                    UserRatingAndReviewToUpdate.UserRatingAndReviewId = dto.UserRatingAndReviewId;
                    UserRatingAndReviewToUpdate.RecipeId = dto.RecipeId;
                    UserRatingAndReviewToUpdate.UserId = dto.UserId;
                    UserRatingAndReviewToUpdate.ReviewsId = dto.ReviewsId;
                    UserRatingAndReviewToUpdate.RatingId = dto.RatingId;

                    _dbContext.TblUserRatingAndReviews.Update(UserRatingAndReviewToUpdate);
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
                        Message = $"UserRatingAndReview with ID {dto.UserRatingAndReviewId} not found"
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

        public async Task<ApiResponseMessage<string>> DeleteUserRatingAndReview(UserRatingAndReviewDto dto)
        {
            try
            {

                var UserRatingAndReviewToDelete = await _dbContext.TblUserRatingAndReviews.FirstOrDefaultAsync(x => x.UserRatingAndReviewId == dto.UserRatingAndReviewId);

                if (UserRatingAndReviewToDelete != null)
                {

                    UserRatingAndReviewToDelete.UserRatingAndReviewId = dto.UserRatingAndReviewId;
                    UserRatingAndReviewToDelete.RecipeId = dto.RecipeId;
                    UserRatingAndReviewToDelete.UserId = dto.UserId;
                    UserRatingAndReviewToDelete.ReviewsId = dto.ReviewsId;
                    UserRatingAndReviewToDelete.RatingId = dto.RatingId;

                    _dbContext.TblUserRatingAndReviews.Remove(UserRatingAndReviewToDelete);
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
                        Message = $"UserRatingAndReview with ID {dto.UserRatingAndReviewId} not found"
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
