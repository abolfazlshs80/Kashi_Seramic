

using Kashi_Seramic.MVC.Models.Slider;
using Pr_Signal_ir.MVC.Models.Category;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{
    // [Authorize(Roles = "AdminSite,Admin")]
    [Area("Admin")]
    //[Authorize(Roles = "Administrator")]

    public class ManageSliderController : Controller
    {

        private readonly ISliderService _cate;
        private readonly IUserService _UserService;
        private readonly IMenuService _MenuService;
        private readonly IFileService _FileService;
        //private readonly IService _cate;
        public int Take { get; set; } = 5;
        private readonly IMapper _mapper;
        public ManageSliderController(ISliderService cate, IMapper mapper, IMenuService MenuService, IUserService UserService, IFileService fileService)
        {
            _cate = cate;
            _mapper = mapper;
            _MenuService = MenuService;
            _UserService = UserService;
            _FileService = fileService;
        }
        [Route("/Admin/ManageSlider/Index/{page?}")]
        [Route("/Admin/ManageSlider/Index")]
        [Route("/Admin/ManageSlider")]
        public async Task<IActionResult> Index(int page = 0)
        {
            var GetAllCategories = await _cate.GetSliders();
            ViewBag.count = (GetAllCategories.Count / 5) + 1;
            ViewBag.page = page;

            return View(GetAllCategories.Skip(page * Take).Take(Take));
        }

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            var cat = await _cate.GetSlidersDetails(id);
            if (cat != null)
            {
                return View(_mapper.Map<UpdateSliderVM>(cat));
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateSliderVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) || string.IsNullOrWhiteSpace(model.Text) )
                return View(model);
            var cat = await _cate.GetSlidersDetails(model.Id);
            if (cat == null)
            {
                return View(model);
            }

            if (model.FileHeader != null)
            {
                await _FileService.DeleteFile("Slider", cat.Title.Replace(" ", "-") + ".jpg", "Slider");
                var filename = model.Title.Replace(" ", "-");
                //      var rnd = new Random().Next(1000, 99999).ToString();
                var Name = await _FileService.CreateFile(model.FileHeader, "Slider", "", filename, "");
                model.PathImage = Name;
            }
            else
                model.PathImage = cat.PathImage;
            
            await _cate.UpdateSlider(model.Id, model);


            return RedirectToAction("Index");
        }
        #endregion


        #region Create  
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(new CreateSliderVM());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) || string.IsNullOrWhiteSpace(model.Text))
                return View(model);
            
            if (model.FileHeader != null)
            {
                var filename = model.Title.Replace(" ", "-");
                //      var rnd = new Random().Next(1000, 99999).ToString();
                var Name = await _FileService.CreateFile(model.FileHeader, "Slider", "", filename, "");
                model.PathImage = Name;
                await _cate.CreateSlider(model);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Blog

        //[Route("/Admin/ManageSlider/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await _cate.GetSlidersDetails(id);
                if (model == null)
                    return RedirectToAction("Index");


                await _cate.DeleteSlider(id);
                await _FileService.DeleteFile("Slider", model.Title.SetForUrl()+".jpg", "Slider");
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
            var model = await _cate.GetSlidersDetails(id);
            if (model == null)
            {
                return NotFound();
            }

            model.Status = !model.Status;
            await _cate.UpdateSlider(model.Id, _mapper.Map<UpdateSliderVM>(model));
            return RedirectToAction("Index");
        }
    }
}
