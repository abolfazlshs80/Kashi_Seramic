

using Pr_Signal_ir.MVC.Models.FilterProduct;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{
    // [Authorize(Roles = "AdminSite,Admin")]
    [Area("Admin")]
    //[Authorize(Roles = "Administrator")]

    public class ManageFilterValueProductController : Controller
    {

        private readonly IFilterValueProductService _cate;
        private readonly IUserService _UserService;
        private readonly IMenuService _MenuService;
        private readonly IFileService _FileService;
        //private readonly IService _cate;
        public int Take { get; set; } = 5;
        private readonly IMapper _mapper;
        public ManageFilterValueProductController(IFilterValueProductService cate, IMapper mapper, IMenuService MenuService, IUserService UserService, IFileService fileService)
        {
            _cate = cate;
            _mapper = mapper;
            _MenuService = MenuService;
            _UserService = UserService;
            _FileService = fileService;
        }
        [Route("/Admin/ManageFilterValueProduct/Index/{id}/{page?}")]
        [Route("/Admin/ManageFilterValueProduct/Index{id}")]
        [Route("/Admin/ManageFilterValueProduct/{id}")]
        public async Task<IActionResult> Index(int id,int page = 0)
        {
            var st = await IS_AUTH_FUNC();
            var GetAllCategories = await _cate.GetFilterValueProductsByFilterId(id);
            ViewBag.count = (GetAllCategories.Count / 5) + 1;
            ViewBag.page = page;
            ViewBag.FilterId = id;
            return View(GetAllCategories.Skip(page * Take).Take(Take));
        }

        #region Edit
        [HttpGet()]
        public async Task<IActionResult> Edit(int id = 0)
        {

            //TODO UPDATE FILTER PRODUCT 
            var cat = await _cate.GetFilterValueProductsDetails(id);
            if (cat != null)
            {
                return View(_mapper.Map<UpdateFilterValueProductVM>(cat));
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateFilterValueProductVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Value))
                return View(model);
            var cat = await _cate.GetFilterValueProductsDetails(model.Id);
            if (cat == null)
            {
                return View(model);
            }
      
            await _cate.UpdateFilterValueProduct(model.Id, model);


            return RedirectToAction("Index");
        }
        #endregion


        #region Create  
        [HttpGet("/Admin/ManageFilterValueProduct/Create/{FilterId}")]
        public async Task<IActionResult> Create(int FilterId)
        {
            ViewBag.FilterId = FilterId;
            return View(new CreateFilterValueProductVM(){FilterId = FilterId});
        }
        [HttpPost("/Admin/ManageFilterValueProduct/Create")]
        public async Task<IActionResult> Create(CreateFilterValueProductVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Value))
                return View(model);
            await _cate.CreateFilterValueProduct(model);
      
            return RedirectToAction("Index",new {id=model.FilterId});
        }
        #endregion

        #region Delete Blog

        [Route("/Admin/ManageFilterValueProduct/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _cate.GetFilterValueProductsDetails(id);
            int filterId = model.FilterId;
            try
            {
           
                if (model == null)
                    return RedirectToAction("Index","ManageFilterProduct");

          
                await _cate.DeleteFilterValueProduct(id);
   
                return RedirectToAction("Index", new { id = model.FilterId });
            }
            catch (Exception)
            {

                return RedirectToAction("Index", new { id = model.FilterId });
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
                if (item.ControllerName.Equals(nameof(ManageFilterValueProductController)))
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
