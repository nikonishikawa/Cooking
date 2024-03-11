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
    public class RatingService : IRatingService
    {
        private readonly CookingDbContext _dbContext;

        public RatingService(CookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertRating(RatingDto dto)
        {
            try
            {
                var _insertRating = new TblRating
                {
                    Rating = dto.Rating
                };

                await _dbContext.TblRatings.AddAsync(_insertRating);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Rating Data",
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

        public async Task<ApiResponseMessage<IList<TblRating>>> GetRating(long RatingId)
        {
            try
            {
                var _data = await _dbContext.TblRatings
                    .Where(x => x.RatingId == RatingId)
                    .Select(x => new TblRating
                    {
                        RatingId = x.RatingId,
                        Rating = x.Rating
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblRating>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblRating>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateRating(RatingDto dto)
        {
            try
            {

                var RatingToUpdate = await _dbContext.TblRatings.FirstOrDefaultAsync(x => x.RatingId == dto.RatingId);

                if (RatingToUpdate != null)
                {

                    RatingToUpdate.Rating = dto.Rating;

                    _dbContext.TblRatings.Update(RatingToUpdate);
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
                        Message = $"Rating with ID {dto.RatingId} not found"
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

        public async Task<ApiResponseMessage<string>> DeleteRating(RatingDto dto)
        {
            try
            {

                var RatingToDelete = await _dbContext.TblRatings.FirstOrDefaultAsync(x => x.RatingId == dto.RatingId);

                if (RatingToDelete != null)
                {

                    RatingToDelete.Rating = dto.Rating;

                    _dbContext.TblRatings.Remove(RatingToDelete);
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
                        Message = $"Rating with ID {dto.RatingId} not found"
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
