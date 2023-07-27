using Pr_Signal_ir.Application.Extentions;
using Pr_Signal_ir.MVC.Models.Ticket;
using Pr_Signal_ir.MVC.Models.TicketGroup;
using Pr_Signal_ir.MVC.Models.TicketToReply;

namespace Kashi_Seramic.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]

    public class TicketController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        private readonly IUserService _UserService;
        private readonly IOrderService _OrderService;
        private readonly ITicketService _TicketService;
        private readonly ITicketGroupService _TicketGroupService;
        private readonly ITicketToReplyService _TicketReplyService;
        public TicketController(IBlogService blogService, IMapper mapper, IUserService userService,
            ITicketService TicketService, ITicketGroupService TicketGroupService, ITicketToReplyService TicketReplyService,
            IOrderService OrderService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _UserService = userService;
            _TicketGroupService = TicketGroupService;
            _TicketService= TicketService;
            _TicketReplyService = TicketReplyService;
            _OrderService = OrderService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            if (user == null)
                return View("/Home/Error");


            return View(await _TicketService.GetTicketsByUserId(userId));

        }

        private async Task< List<TicketGroupVM>>GetGroup()
        {
             string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            List< TicketGroupVM >lst=new List<TicketGroupVM>();
            if (user != null)
            {
                foreach (var order in await _OrderService.GetOrdersUserId(userId))
                {
                    foreach (var item in order.orderDetails.DistinctBy(a=>a.Product.Id))
                    {
                        var qfind =(await _TicketGroupService.GetTicketGroups()).Where(a=>a.NameGroup.Equals(item.Product.Title));
                        lst.AddRange(qfind);
                    }
                }
            }
            return lst;
               
        }
        [HttpGet]
        public async Task  < IActionResult> CreateTicket()
        {
            var model = new CreateTicketVM();
            model.Group =await GetGroup();
            return View(model);
        }
        [HttpPost]
        public async Task< IActionResult> CreateTicket(string Text, string Title, int groupId)
        {
            if (string.IsNullOrEmpty(Text) || string.IsNullOrWhiteSpace(Title) || groupId == 0)
            {
                var model = new CreateTicketVM();
             
                return View(model);
            }
             string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            if (user == null)
                return View("/Home/Error");
            var newticket = new CreateTicketVM()
            {
                DateCreated = DateTime.Now,
                Status = false,
                Title = Title,
                Text = Text,
                GroupId = groupId,
                UserId = user.Id
            };
          await  _TicketService.CreateTicket(newticket);
            return RedirectToAction("Index");
        }
        [Route("/User/Ticket/ShowTicketById/{Code}")]
        public async Task< IActionResult> ShowTicketById(int Code = 0)
        {
             string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            if (user == null)
                return View("/Home/Error");
            if (Code == 0)
                return RedirectToAction("ShowTicket");
            var model = new TicketVM();
            model =await _TicketService.GetTicketsDetails(Code);
            return View(model);

        }
        public async Task<IActionResult> InsertMessage(int Code, string Text)
        {
             string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            if (user == null)
                return View("/Home/Error");

            if (Code == 0)
                return RedirectToAction("ShowTicketById", new { Code = Code });
            var newmessage = new CreateTicketToReplyVM
            {
                DateCreated = DateTime.Now,
                TicketId = Code,
                CreatedBy = user.Id,
                Status = "User",
                Text = Text,


            };
            var ticket = await _TicketService.GetTicketsDetails(Code);
            ticket.Status = false;
            await _TicketService.UpdateTicket(Code, _mapper.Map<UpdateTicketVM>(ticket));

            await _TicketReplyService.CreateTicketToReply(newmessage);

            return RedirectToAction("ShowTicketById", new { Code = Code });
        }

    }
}
