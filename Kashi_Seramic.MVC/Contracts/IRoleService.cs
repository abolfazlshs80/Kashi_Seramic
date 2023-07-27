using Kashi_Seramic.Application.Models.Identity;

using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Employe;
using Pr_Signal_ir.MVC.Models.Roles;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IRoleService
    {
      Task <ResponseDto> AddRoleToUsers(RoleVM model);
        Task<ResponseDto> DeleteRoleFromUsers(AddRoleToUserVM model);
        Task<ResponseDto> AddRole(AddRoleVM model);
        Task<ResponseDto> UpdateRole(AddRoleVM model);
        Task<ResponseDto> DeleteRoleRole(string RoleId);
        Task<ResponseDto> IsInRole(AddRoleToUserVM model);
        Task<IEnumerable<RoleVM>> GetRoles();
        Task<IEnumerable<RoleVM>> GetRoleschecked(string id);
        Task<RoleVM> GetRole(string roleId);
        Task<RoleVM> GetUserAndRoles(string UserId);
    }
}
