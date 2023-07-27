using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Setting;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ISettingService
    {
        Task<List<SettingVM>> GetSettings();
        Task<SettingVM> GetSettingsDetails(int id);
        Task<Response<int>> CreateSetting(CreateSettingVM leaveType);
        Task<Response<int>> UpdateSetting(int id,UpdateSettingVM leaveType);
        Task<Response<int>> DeleteSetting(int id);
    }
}
