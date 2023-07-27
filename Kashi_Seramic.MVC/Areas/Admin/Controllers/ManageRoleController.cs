using Pr_Signal_ir.MVC.Models.Roles;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = "Administrator")]
    public class ManageRoleController : Controller
    {
        private readonly IUserService _userRepo;
        private readonly IRoleService _roleRepo;

        private readonly IMapper _mapper;
        public ManageRoleController(IUserService userRepo, IMapper mapper, IRoleService roleRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _roleRepo.GetRoles();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            var model = new RoleVM();
            model.RoleId = Guid.NewGuid().ToString();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleVM model)
        {
            if (!string.IsNullOrWhiteSpace(model.RoleName))
            {
                var res = await _roleRepo.AddRole(new AddRoleVM { RoleId = model.RoleId, RoleName = model.RoleName });
                if (res.Status.Value)
                    return RedirectToAction("Index");
                else
                    return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var model = await _roleRepo.GetRole(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(RoleVM model)
        {
        
            var user = await _roleRepo.GetRole(model.RoleId);
            if (user == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrWhiteSpace(model.RoleName))
            {
                var res = await _roleRepo.UpdateRole(new AddRoleVM { RoleId=model.RoleId,RoleName=model.RoleName});
                if (res.Status.Value)
                    return RedirectToAction("Index");
                else
                    return NotFound();
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {

            var user = await _roleRepo.GetRole(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
          
                var res = await _roleRepo.DeleteRoleRole(id);
                if (res.Status.Value)
                    return RedirectToAction("Index");
                else
                    return NotFound();

            return RedirectToAction("Index");
        }
    }
}
