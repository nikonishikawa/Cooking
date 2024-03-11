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
    public class UserService : IUserService
    {
        private readonly CookingDbContext _dbContext;

        public UserService(CookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertUser(UserDto dto)
        {
            try
            {
                var _insertUser = new TblUser
                {
                    UserId = dto.UserId,
                    Username = dto.Username,
                    CredentialsId = dto.CredentialsId
                };

                await _dbContext.TblUsers.AddAsync(_insertUser);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved User Data",
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

        public async Task<ApiResponseMessage<IList<TblUser>>> GetUser(long UserId)
        {
            try
            {
                var _data = await _dbContext.TblUsers
                    .Where(x => x.UserId == UserId)
                    .Select(x => new TblUser
                    {
                        UserId = x.UserId,
                        Username = x.Username,
                        CredentialsId = x.CredentialsId
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblUser>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblUser>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateUser(UserDto dto)
        {
            try
            {

                var UserToUpdate = await _dbContext.TblUsers.FirstOrDefaultAsync(x => x.UserId == dto.UserId);

                if (UserToUpdate != null)
                {
                    UserToUpdate.UserId = dto.UserId;
                    UserToUpdate.Username = dto.Username;
                    UserToUpdate.CredentialsId = dto.CredentialsId;

                    _dbContext.TblUsers.Update(UserToUpdate);
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
                        Message = $"User with ID {dto.UserId} not found"
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

        public async Task<ApiResponseMessage<string>> DeleteUser(UserDto dto)
        {
            try
            {

                var UserToDelete = await _dbContext.TblUsers.FirstOrDefaultAsync(x => x.UserId == dto.UserId);

                if (UserToDelete != null)
                {

                    UserToDelete.UserId = dto.UserId;
                    UserToDelete.Username = dto.Username;
                    UserToDelete.CredentialsId = dto.CredentialsId;

                    _dbContext.TblUsers.Remove(UserToDelete);
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
                        Message = $"User with ID {dto.UserId} not found"
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
