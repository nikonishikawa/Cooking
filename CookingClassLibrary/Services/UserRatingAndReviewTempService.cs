    using CookingClassLibrary.APIResponse;
    using CookingClassLibrary.Dto;
    using CookingClassLibrary.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading.Tasks;

    namespace CookingClassLibrary.Services
    {
        public class UserRatingAndReviewTempService : IUserRatingAndReviewTempService
        {
            private readonly CookingDbContext _dbContext;

            public UserRatingAndReviewTempService(CookingDbContext dbContext)
            {
                _dbContext = dbContext;
            }

        public async Task<ApiResponseMessage<TblUserRatingAndReviewTemp>> InsertUserRatingAndReviewTemp(UserRatingAndReviewTempDto dto)
        {
            try
            {
                var rating = await _dbContext.TblRatings.FindAsync(dto.RatingId);
                if (rating == null)
                {
                    return new ApiResponseMessage<TblUserRatingAndReviewTemp>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"Rating with ID {dto.RatingId} not found."
                    };
                }

                var review = await _dbContext.TblReviews.FindAsync(dto.ReviewsId);
                if (review == null)
                {
                    return new ApiResponseMessage<TblUserRatingAndReviewTemp>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"Review with ID {dto.ReviewsId} not found."
                    };
                }

                // Create the association entity
                var userRatingAndReviewTemp = new TblUserRatingAndReviewTemp
                {
                    Rating = rating,
                    Reviews = review
                    // Assign other properties as needed
                };

                // Add the association entity to the DbContext
                await _dbContext.TblUserRatingAndReviewsTemps.AddAsync(userRatingAndReviewTemp);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<TblUserRatingAndReviewTemp>
                {
                    Data = userRatingAndReviewTemp,
                    IsSuccess = true,
                    Message = "Successfully added user rating and review"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<TblUserRatingAndReviewTemp>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }





        public async Task<ApiResponseMessage<IList<TblUserRatingAndReviewTemp>>> GetUserRatingAndReviewTemp(long UserRatingAndReviewTempId)
            {
                try
                {
                    var _data = await _dbContext.TblUserRatingAndReviewsTemps
                        .Where(x => x.UserRatingAndReviewTempId == UserRatingAndReviewTempId)
                        .Select(x => new TblUserRatingAndReviewTemp
                        {
                            UserRatingAndReviewTempId = x.UserRatingAndReviewTempId,
                            RecipeId = x.RecipeId,
                            ReviewsId = x.ReviewsId,
                            RatingId = x.RatingId,
                        })
                        .ToListAsync();
                    var res = new ApiResponseMessage<IList<TblUserRatingAndReviewTemp>>
                    {
                        Data = _data,
                        IsSuccess = false,
                        Message = "UserRatingAndReviewTemp Found"
                    };

                    return res;
                }
                catch (Exception ex)
                {
                    var res = new ApiResponseMessage<IList<TblUserRatingAndReviewTemp>>
                    {
                        Data = [],
                        IsSuccess = true,
                        Message = ex.Message
                    };

                    return res;
                }
            }

            public async Task<ApiResponseMessage<string>> UpdateUserRatingAndReviewTemp(UserRatingAndReviewTempDto dto)
            {
                try
                {

                    var UserRatingAndReviewTempToUpdate = await _dbContext.TblUserRatingAndReviewsTemps.FirstOrDefaultAsync(x => x.UserRatingAndReviewTempId == dto.UserRatingAndReviewTempId);

                    if (UserRatingAndReviewTempToUpdate != null)
                    {
                        UserRatingAndReviewTempToUpdate.UserRatingAndReviewTempId = dto.UserRatingAndReviewTempId;
                        UserRatingAndReviewTempToUpdate.RecipeId = dto.RecipeId;
                        UserRatingAndReviewTempToUpdate.ReviewsId = dto.ReviewsId;
                        UserRatingAndReviewTempToUpdate.RatingId = dto.RatingId;

                        _dbContext.TblUserRatingAndReviewsTemps.Update(UserRatingAndReviewTempToUpdate);
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
                            Message = $"UserRatingAndReviewTemp with ID {dto.UserRatingAndReviewTempId} not found"
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

            public async Task<ApiResponseMessage<string>> DeleteUserRatingAndReviewTemp(UserRatingAndReviewTempDto dto)
            {
                try
                {

                    var UserRatingAndReviewTempToDelete = await _dbContext.TblUserRatingAndReviewsTemps.FirstOrDefaultAsync(x => x.UserRatingAndReviewTempId == dto.UserRatingAndReviewTempId);

                    if (UserRatingAndReviewTempToDelete != null)
                    {

                        UserRatingAndReviewTempToDelete.UserRatingAndReviewTempId = dto.UserRatingAndReviewTempId;
                        UserRatingAndReviewTempToDelete.RecipeId = dto.RecipeId;
                        UserRatingAndReviewTempToDelete.ReviewsId = dto.ReviewsId;
                        UserRatingAndReviewTempToDelete.RatingId = dto.RatingId;

                        _dbContext.TblUserRatingAndReviewsTemps.Remove(UserRatingAndReviewTempToDelete);
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
                            Message = $"UserRatingAndReviewTemp with ID {dto.UserRatingAndReviewTempId} not found"
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
