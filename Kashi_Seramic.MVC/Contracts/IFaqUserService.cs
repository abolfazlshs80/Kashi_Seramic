using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.FaqUser;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IFaqUserService
    {
        Task<List<FaqUserVM>> GetFaqUsers();
        Task<List<FaqUserVM>> GetFaqUsersByNumber(int number);
        Task<FaqUserVM> GetFaqUsersDetails(int id);
        Task<Response<int>> CreateFaqUser(CreateFaqUserVM leaveType);
        Task<Response<int>> UpdateFaqUser(int id,UpdateFaqUserVM leaveType);
        Task<Response<int>> DeleteFaqUser(int id);
    }
}
