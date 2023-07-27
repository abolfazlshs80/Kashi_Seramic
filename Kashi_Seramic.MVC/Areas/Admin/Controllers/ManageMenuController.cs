using Microsoft.AspNetCore.Mvc.Rendering;
using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{
    // [Authorize(Roles = "AdminSite,Admin")]
    [Area("Admin")]
  //  [Authorize(Roles = "Administrator")]
    public class ManageMenuController : Controller
    {
        private readonly IMenuService _menu;
        private readonly IRoleService _role;
        //private readonly IService _cate;

        private readonly IMapper _mapper;
        public ManageMenuController(IMenuService menu, IMapper mapper, IRoleService role)
        {
            _menu = menu;
            _mapper = mapper;
            _role = role;
        }
        public async Task<IActionResult> Index()
        {
            var GetAllCategories = await _menu.GetMenus();
            return View(GetAllCategories);
        }

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            var cat = await _menu.GetMenusDetails(id);
            var model = _mapper.Map<UpdateMenuVM>(cat);
            model.Roles = await _role.GetRoles();
            model.RolesDropDown = model.Roles.Select(a => new SelectListItem { Text = a.RoleName,Selected=cat.RoleName==a.RoleName, Value = a.RoleName });
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateMenuVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) || string.IsNullOrWhiteSpace(model.Href))
                return View(model);
            var cat = await _menu.GetMenusDetails(model.Id);
            if (cat != null)
            {
                await _menu.UpdateMenu(model.Id, model);
            }

            return RedirectToAction("Index");
        }
        #endregion


        #region Create  
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateMenuVM();
            model.Roles = await _role.GetRoles();
            model.RolesDropDown = model.Roles.Select(a => new SelectListItem { Text = a.RoleName, Value = a.RoleName });
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Title))
                return View(model);
            await _menu.CreateMenu(model);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Blog

        //[Route("/Admin/ManageCategory/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await _menu.GetMenusDetails(id);
                if (model == null)
                    return RedirectToAction("Index");
                await _menu.DeleteMenu(id);

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
            var model = await _menu.GetMenusDetails(id);
            if (model == null)
            {
                return NotFound();
            }

            model.Status = !model.Status;
            await _menu.UpdateMenu(model.Id, _mapper.Map<UpdateMenuVM>(model));
            return RedirectToAction("Index");
        }
    }
}
