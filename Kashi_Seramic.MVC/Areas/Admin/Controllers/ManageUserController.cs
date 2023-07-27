using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Order;
using Pr_Signal_ir.MVC.Models.Roles;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = "Administrator,Teacher")]

    public class ManageUserController : Controller
    {
        private readonly IUserService _userRepo;
        private readonly IOrderService _OrderRepo;
        private readonly IProductService _BlogRepo;
        private readonly IRoleService _roleRepo;

        private readonly IMapper _mapper;
        public ManageUserController(IUserService userRepo, IMapper mapper, IRoleService roleRepo, IProductService BlogRepo, IOrderService orderRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _BlogRepo = BlogRepo;
            _OrderRepo = orderRepo;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _userRepo.GetEmployees();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
            
        {   string userId = User.FindFirst("uid")?.ToString().Replace("uid: ", "");
            if (User.IsInRole("Teacher"))
            {
                id = userId;
            }

            var model = await _userRepo.GetEmployee(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EmployeeVM model, string pass)
        {
            if (!string.IsNullOrWhiteSpace(pass))
            {
                //chnage password
            }
            var user = await _userRepo.GetEmployee(model.Id);
            if (user == null)
            {
                return NotFound();
            }
            if (ModelState.ErrorCount <= 1)
            {
                var res = await _userRepo.UpdateEmployee(model);
                if (res.Status)
                    return View(model);
                else
                    return NotFound();
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddUserToDore(string id)
        {
            var model = new AddUserToDore();
            model.Blog = await _BlogRepo.GetProducts();
            model.UserId = id;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToDore(AddUserToDore model)
        {
            var blog = await _BlogRepo.GetProductsDetails(model.BlogId);
            if (blog == null)
                return View(model);
            var res = await _OrderRepo.AddUserToDore(model.UserId, model.BlogId);
            if (res.Equals(1))
                return RedirectToAction("Index");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddUserToRole(string id)
        {
            var model = new AddRoleToUserVM();
            model.Roles = await _roleRepo.GetRoleschecked(id);
            model.UserId = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(AddRoleToUserVM model)
        {
            //var l = model.MyRoles.ToList();
            foreach (var item in await _roleRepo.GetRoles())
            {
                var role = await _roleRepo.GetRole(item.RoleId);
                var res = await _roleRepo.AddRoleToUsers(new RoleVM { UserId = model.UserId, RoleId = role.RoleId, RoleName = role.RoleName, Selected = false });

            }
            if (model.MyRoles.Any())
            {
                foreach (var item in model.MyRoles)
                {
                    var role = await _roleRepo.GetRole(item);
                    var res = await _roleRepo.AddRoleToUsers(new RoleVM { UserId = model.UserId, RoleId = role.RoleId, RoleName = role.RoleName, Selected = true });
                }
            }


            return RedirectToAction("Index");
        }
    }
}
