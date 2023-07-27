using Pr_Signal_ir.MVC.Models.Category;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{
    // [Authorize(Roles = "AdminSite,Admin")]
    [Area("Admin")]
    //[Authorize(Roles = "Administrator")]

    public class ManageCategoryController : Controller
    {

        private readonly ICategoryService _cate;
        private readonly IUserService _UserService;
        private readonly IMenuService _MenuService;
        private readonly IFileService _FileService;
        //private readonly IService _cate;
        public int Take { get; set; } = 5;
        private readonly IMapper _mapper;
        public ManageCategoryController(ICategoryService cate, IMapper mapper, IMenuService MenuService, IUserService UserService, IFileService fileService)
        {
            _cate = cate;
            _mapper = mapper;
            _MenuService = MenuService;
            _UserService = UserService;
            _FileService = fileService;
        }
        [Route("/Admin/ManageCategory/Index/{page?}")]
        [Route("/Admin/ManageCategory/Index")]
        [Route("/Admin/ManageCategory")]
        public async Task<IActionResult> Index(int page = 0)
        {

            var GetAllCategories = await _cate.GetCategorys();
            ViewBag.count = (GetAllCategories.Count / 5) + 1;
            ViewBag.page = page;

            return View(GetAllCategories.Skip(page * Take).Take(Take));
        }

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            var cat = await _cate.GetCategorysDetails(id);
            if (cat != null)
            {
                return View(_mapper.Map<UpdateCategoryVM>(cat));
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Type) || string.IsNullOrWhiteSpace(model.ShortDesc))
                return View(model);
            var cat = await _cate.GetCategorysDetails(model.Id);
            if (cat == null)
            {
                return View(model);
            }
            if (model.FileHeader != null)
            {
                await _FileService.DeleteFile("Category", cat.Name.Replace(" ", "-") + ".jpg", "Category");
                var filename = model.Name.Replace(" ", "-");
                //      var rnd = new Random().Next(1000, 99999).ToString();
                var Name = await _FileService.CreateFile(model.FileHeader, "Category", "", filename, "");

            }
            await _cate.UpdateCategory(model.Id, model);


            return RedirectToAction("Index");
        }
        #endregion


        #region Create  
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(new CreateCategoryVM());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Type) || string.IsNullOrWhiteSpace(model.ShortDesc))
                return View(model);
            await _cate.CreateCategory(model);
            if (model.FileHeader != null)
            {
                var filename = model.Name.Replace(" ", "-");
                //      var rnd = new Random().Next(1000, 99999).ToString();
                var Name = await _FileService.CreateFile(model.FileHeader, "Category", "", filename, "");

            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Blog

        //[Route("/Admin/ManageCategory/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await _cate.GetCategorysDetails(id);
                if (model == null)
                    return RedirectToAction("Index");

                if (model.CategoryToBlog != null && model.CategoryToBlog.Count > 0)
                {


                    //await _file.DeleteFileImages(blog.FileToBlog.FirstOrDefault().BlogId);

                    string messsage = "چند دسته بندی با این دسه بنید ثبت شده اند اول دسته بندی انهارا تغییر دهید";
                    return RedirectToAction("Index");
                }
                await _cate.DeleteCategory(id);
                await _FileService.DeleteFile("Category", model.Name.Replace(" ","-")+".jpg", "Category");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }


        }
        #endregion

        public async Task<IActionResult> Active(int id)
        {
            var model = await _cate.GetCategorysDetails(id);
            if (model == null)
            {
                return NotFound();
            }

            model.Status = !model.Status;
           await _cate.UpdateCategory(model.Id, _mapper.Map<UpdateCategoryVM>(model));
            return RedirectToAction("Index");
        }
    }
}
