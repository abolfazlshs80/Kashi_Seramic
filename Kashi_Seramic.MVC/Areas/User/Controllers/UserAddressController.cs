using Kashi_Seramic.MVC.Models.Users.UserAddres;
using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.Application.Extentions;

namespace Kashi_Seramic.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]

    public class UserAddressController : Controller
    {
        private readonly IUserAddressService _cate;
        private readonly IUserService _UserService;
        private readonly IMenuService _MenuService;
        private readonly IFileService _FileService;
        private readonly IUserAddressService _UserAddressService;
        public int Take { get; set; } = 5;
        private readonly IMapper _mapper;
        public UserAddressController(IUserAddressService cate, IUserService userService, IMenuService menuService, IFileService fileService, IUserAddressService userAddressService,  IMapper mapper)
        {
            _cate = cate;
            _UserService = userService;
            _MenuService = menuService;
            _FileService = fileService;
            _UserAddressService = userAddressService;
        
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 0)
        {

            var GetAllCategories = await _UserAddressService.GetUserAddresssDetailsByUserid(User.GetUserId())??new List<UserAddressVM>();
            ViewBag.count = (GetAllCategories?.Count / 5) + 1;
            ViewBag.page = page;

            return View(GetAllCategories?.Skip(page * Take).Take(Take));
        }

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            var cat = await _cate.GetUserAddresssDetails(id);
            if (cat != null)
            {
                return View(_mapper.Map<UpdateUserAddressVM>(cat));
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserAddressVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var cat = await _cate.GetUserAddresssDetails(model.Id);
            if (cat == null)
            {
                return View(model);
            }
            model.Owner = User.GetUserId();
            await _cate.UpdateUserAddress(model.Id, model);


            return RedirectToAction("Index");
        }
        #endregion


        #region Create  
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(new CreateUserAddressVM());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserAddressVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.Owner = User.GetUserId();
            await _cate.CreateUserAddress(model);

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Blog

        //[Route("/Admin/ManageUserAddress/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await _cate.GetUserAddresssDetails(id);
                if (model == null)
                    return RedirectToAction("Index");


                await _cate.DeleteUserAddress(id);
                await _FileService.DeleteFile("UserAddress", model.Name.Replace(" ", "-") + ".jpg", "UserAddress");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }


        }
        #endregion

    }
}
