using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IMenuService
    {
        Task<List<MenuVM>> GetMenus();
        Task<List<MenuVM>> GetMenusActive();

        Task<List<MenuVM>> GetMenusbyAdminPanel();
        Task<List<MenuVM>> GetMenusbyUserPanel();
        Task<MenuVM> GetMenusDetails(int id);
        Task<Response<int>> CreateMenu(CreateMenuVM leaveType);
        Task<Response<int>> UpdateMenu(int id, UpdateMenuVM leaveType);
        Task<Response<int>> DeleteMenu(int id);
    }
}
