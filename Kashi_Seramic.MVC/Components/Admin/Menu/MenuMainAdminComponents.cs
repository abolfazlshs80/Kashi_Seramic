using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;

namespace Kashi_Seramic.MVC.Components.Main
{
    public class MainMenuAdminComponents : ViewComponent
    {
        private readonly IMenuService _menuService;
        private readonly ISettingService _SettingService;

        private readonly IMapper _mapper;

        public MainMenuAdminComponents(IMenuService menuService,
            IMapper mapper,
            ISettingService settingService)
        {
            _menuService = menuService;

            _mapper = mapper;
            _SettingService = settingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new MenuListVM();
            model.Menu = await _menuService.GetMenus();
            model.Setting = (await _SettingService.GetSettings()).FirstOrDefault();
            return View("/Views/Components/Admin/Menu/MainMenuAdmin.cshtml", model);
        }

    }
}
