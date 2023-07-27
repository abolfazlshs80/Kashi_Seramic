using Pr_Signal_ir.MVC.Models.FilterProduct;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{
    // [Authorize(Roles = "AdminSite,Admin")]
    [Area("Admin")]
    //[Authorize(Roles = "Administrator")]

    public class ManageFilterProductController : Controller
    {

        private readonly IFilterProductService _cate;
        private readonly IUserService _UserService;
        private readonly IMenuService _MenuService;
        private readonly IFileService _FileService;
        //private readonly IService _cate;
        public int Take { get; set; } = 5;
        private readonly IMapper _mapper;
        public ManageFilterProductController(IFilterProductService cate, IMapper mapper, IMenuService MenuService, IUserService UserService, IFileService fileService)
        {
            _cate = cate;
            _mapper = mapper;
            _MenuService = MenuService;
            _UserService = UserService;
            _FileService = fileService;
        }
        [Route("/Admin/ManageFilterProduct/Index/{page?}")]
        [Route("/Admin/ManageFilterProduct/Index")]
        [Route("/Admin/ManageFilterProduct")]
        public async Task<IActionResult> Index(int page = 0)
        {
            var st = await IS_AUTH_FUNC();
            var GetAllCategories = await _cate.GetFilterProducts();
            ViewBag.count = (GetAllCategories.Count / 5) + 1;
            ViewBag.page = page;

            return View(GetAllCategories.Skip(page * Take).Take(Take));
        }

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {

            //TODO UPDATE FILTER PRODUCT 
            var cat = await _cate.GetFilterProductsDetails(id);
            if (cat != null)
            {
                return View(_mapper.Map<UpdateFilterProductVM>(cat));
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateFilterProductVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) || string.IsNullOrWhiteSpace(model.TitleInBrowser) || string.IsNullOrWhiteSpace(model.Text))
                return View(model);
            var cat = await _cate.GetFilterProductsDetails(model.Id);
            if (cat == null)
            {
                return View(model);
            }
      
            await _cate.UpdateFilterProduct(model.Id, model);


            return RedirectToAction("Index");
        }
        #endregion


        #region Create  
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(new CreateFilterProductVM());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFilterProductVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) || string.IsNullOrWhiteSpace(model.TitleInBrowser) || string.IsNullOrWhiteSpace(model.Text))
                return View(model);
            await _cate.CreateFilterProduct(model);
      
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Blog

        //[Route("/Admin/ManageFilterProduct/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await _cate.GetFilterProductsDetails(id);
                if (model == null)
                    return RedirectToAction("Index");

          
                await _cate.DeleteFilterProduct(id);
   
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }


        }
        #endregion

        #region authorization
        public async Task<bool> IS_AUTH_FUNC()
        {
            string userId = "9e224968-33e4-4652-b7b7-8574d048cdb9";
            var user = await _UserService.GetEmployee(userId);
            foreach (var item in await _MenuService.GetMenusbyAdminPanel())
            {
                if (item.ControllerName.Equals(nameof(ManageFilterProductController)))
                {
                    if (User.IsInRole(item.RoleName))
                    {
                        return true;
                    }

                }
            }
            return false;

        }
        #endregion
    }
}
