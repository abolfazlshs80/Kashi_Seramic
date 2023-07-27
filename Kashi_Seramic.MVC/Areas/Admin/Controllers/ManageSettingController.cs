using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Setting;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{
    // [Authorize(Roles = "AdminSite,Admin")]
    [Area("Admin")]
  //  [Authorize(Roles = "Administrator")]

    public class ManageSettingController : Controller
    {

        private readonly ICategoryService _cate;
        private readonly ISettingService _setting;
        private readonly IUserService _UserService;
        private readonly IMenuService _MenuService;
        private readonly IFileService _FileService;
        //private readonly IService _cate;
        public int Take { get; set; } = 5;
        private readonly IMapper _mapper;
        public ManageSettingController(ICategoryService cate, IMapper mapper, IMenuService MenuService, IUserService UserService, ISettingService setting, IFileService fileService)
        {
            _cate = cate;
            _mapper = mapper;
            _MenuService = MenuService;
            _UserService = UserService;
            _setting = setting;
            _FileService = fileService;
        }

        [Route("/Admin/ManageSetting/Index")]
        [Route("/Admin/ManageSetting")]
        public async Task<IActionResult> Index()
        {

            var cat = (await _setting.GetSettings()).FirstOrDefault();
            if (cat != null)
            {
                return View(_mapper.Map<SettingVM>(cat));
            }
            return RedirectToAction("Index");
        }

        #region Edit


        [HttpPost]
        public async Task<IActionResult> Edit(SettingVM model)
        {

            var cat = await _setting.GetSettingsDetails(model.Id);
            if (cat != null)
            {
                if (model.FileHeader != null)
                {
                    await _FileService.DeleteFile("Site", "logo" + ".jpg", "Category");
                    var filename = "logo";
                    //      var rnd = new Random().Next(1000, 99999).ToString();
                    var Name = await _FileService.CreateFile(model.FileHeader, "Site", "", filename, "");
                    cat.LogoPath = Name;
                }
                await _setting.UpdateSetting(model.Id, _mapper.Map<UpdateSettingVM>(model));
            }

            return RedirectToAction("Index");
        }
        #endregion

    }
}
