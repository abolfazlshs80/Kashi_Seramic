using Pr_Signal_ir.Application.Extentions;

namespace Kashi_Seramic.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]

    public class OrderController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IOrderService _OrderService;
        private readonly IMapper _mapper;
        private readonly IUserService _UserService;
        public OrderController(IBlogService blogService, IMapper mapper, IUserService userService, IOrderService orderService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _UserService = userService;
            _OrderService = orderService;
        }

        public async Task< IActionResult> GetOrder()
        {
            string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            if (user == null)
                return View("/Home/Error");


            var model =await _OrderService.GetOrdersUserId(userId);


            return View(model);
        }
        public async Task< IActionResult> GetProducts()
        {
             string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            if (user == null)
                return View("/Error");
            var order =await _OrderService.GetOrdersUserId(userId);
  


           

            return View(order);
        }


    }
}
