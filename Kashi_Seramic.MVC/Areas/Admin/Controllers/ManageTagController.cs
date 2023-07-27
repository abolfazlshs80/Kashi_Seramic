using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.Tag;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{
    // [Authorize(Roles = "AdminSite,Admin")]
    [Area("Admin")]
    //[Authorize(Roles = "Administrator")]

    public class ManageTagController : Controller
    {

        private readonly ITagService _cate;
        private readonly IUserService _UserService;
        private readonly IMenuService _MenuService;
        private readonly IFileService _FileService;
        //private readonly IService _cate;
        public int Take { get; set; } = 5;
        private readonly IMapper _mapper;
        public ManageTagController(ITagService cate, IMapper mapper, IMenuService MenuService, IUserService UserService, IFileService fileService)
        {
            _cate = cate;
            _mapper = mapper;
            _MenuService = MenuService;
            _UserService = UserService;
            _FileService = fileService;
        }
        [Route("/Admin/ManageTag/Index/{page?}")]
        [Route("/Admin/ManageTag/Index")]
        [Route("/Admin/ManageTag")]
        public async Task<IActionResult> Index(int page = 0)
        {
   
            var GetAllCategories = await _cate.GetTags();
            ViewBag.count = (GetAllCategories.Count / 5) + 1;
            ViewBag.page = page;

            return View(GetAllCategories.Skip(page * Take).Take(Take));
        }

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            var cat = await _cate.GetTagsDetails(id);
            if (cat != null)
            {
                return View(_mapper.Map<UpdateTagVM>(cat));
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTagVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) )
                return View(model);
            var cat = await _cate.GetTagsDetails(model.Id);
            if (cat == null)
            {
                return View(model);
            }
    
            await _cate.UpdateTag(model.Id, model);


            return RedirectToAction("Index");
        }
        #endregion


        #region Create  
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(new CreateTagVM());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTagVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) )
                return View(model);
            await _cate.CreateTag(model);
         
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Blog

        //[Route("/Admin/ManageTag/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await _cate.GetTagsDetails(id);
                if (model == null)
                    return RedirectToAction("Index");

                if (model.TagToBlog != null && model.TagToBlog.Count() > 0||(model.TagToProduct != null && model.TagToProduct.Count() > 0))
                {
                    //await _file.DeleteFileImages(blog.FileToBlog.FirstOrDefault().BlogId);

                    string messsage = "چند دسته بندی با این دسه بنید ثبت شده اند اول دسته بندی انهارا تغییر دهید";
                    return RedirectToAction("Index");
                }
                await _cate.DeleteTag(id);
                await _FileService.DeleteFile("Tag", model.Name.Replace(" ","-")+".jpg", "Tag");
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
            var model = await _cate.GetTagsDetails(id);
            if (model == null)
            {
                return NotFound();
            }

            model.Status = !model.Status;
            await _cate.UpdateTag(model.Id, _mapper.Map<UpdateTagVM>(model));
            return RedirectToAction("Index");
        }
    }
}
