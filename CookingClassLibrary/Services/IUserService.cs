using CookingClassLibrary.APIResponse;
using CookingClassLibrary.Dto;
using CookingClassLibrary.Entities;

namespace CookingClassLibrary.Services
{
    public interface IUserService
    {
        Task<ApiResponseMessage<string>> DeleteUser(UserDto dto);
        Task<ApiResponseMessage<IList<TblUser>>> GetUser(long UserId);
        Task<ApiResponseMessage<string>> InsertUser(UserDto dto);
        Task<ApiResponseMessage<string>> UpdateUser(UserDto dto);
    }
}