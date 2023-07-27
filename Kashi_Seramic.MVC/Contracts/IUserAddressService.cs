using Kashi_Seramic.MVC.Models.Users.UserAddres;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IUserAddressService
    {
        Task<List<UserAddressVM>> GetUserAddresss();

        Task<UserAddressVM> GetUserAddresssDetails(int id);
        Task<List<UserAddressVM>> GetUserAddresssDetailsByUserid(string id);
        Task<Response<int>> CreateUserAddress(CreateUserAddressVM leaveType);
        Task<Response<int>> UpdateUserAddress(int id, UpdateUserAddressVM leaveType);
        Task<Response<int>> DeleteUserAddress(int id);
    }
}
