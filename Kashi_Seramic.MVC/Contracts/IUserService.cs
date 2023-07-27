using Kashi_Seramic.Application.Models.Identity;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Employe;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<EmployeeVM>>GetEmployees();
        Task<EmployeeVM> GetEmployee(string userId);
        Task<Response<int>> IS_EXS_EMAIL(string userId);
        Task<Response<int>> IS_EXS_PHONE(string userId);
        Task<Response<int>> IS_EXS_USERNAME(string userId);

        Task<EmployeResponseVM> UpdateEmployee(EmployeeVM model);
        Task<EmployeResponseVM> DeleteEmployee(EmployeeVM model);
        Task<Response<int>> ResetPassword(ChangePasswordDto model);

    }
}
