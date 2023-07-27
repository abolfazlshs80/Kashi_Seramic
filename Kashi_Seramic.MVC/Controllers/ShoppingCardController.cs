using Pr_Signal_ir.Application.Extentions;
using Pr_Signal_ir.MVC.Models.OrderDetials;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Order;
using SignalWebsite_RazorPage.Core.ViewModel;

namespace Kashi_Seramic.MVC.Controllers
{
    //[Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _OrderService;
        private readonly IAuthenticationService _AuthenticationService;
        private readonly IUserService _UserService;
        private readonly IOrderDetialservice _OrderDetialservice;
        private readonly IProductService _ProductService;

        private readonly IFileImagesService _file;
        private readonly ICategoryService _category;

        private readonly IMapper _mapper;
        string merchant = "2dddcbee-5c41-4bb4-b089-b2ce9287af6c";
        string amount = "10000";
        string authority;
        string description = "خرید دوره آموزش ام البنین  ";
        string callbackurl = "https://www.omolbininsafaribeauty.com/ManageVideoBlog/VerifyByHttpClient";
        private static Cart _cart = new Cart();
        public OrderController(IOrderService OrderService,
            IMapper mapper, ICategoryService _category,
            IFileImagesService _file, IProductService ProductService, IOrderDetialservice OrderDetialservice, IUserService userService, IAuthenticationService AuthenticationService)
        {
            _AuthenticationService = AuthenticationService;
            this._OrderService = OrderService;

            this._category = _category;
            this._file = _file;
            this._mapper = mapper;
            _ProductService = ProductService;
            _OrderDetialservice = OrderDetialservice;
            _UserService = userService;

        }



        #region Details Order
        [Route("/Order/{id}/{name}")]
        public async Task<IActionResult> Order_Details(int id, string name)
        {
            var model = await _OrderService.GetOrdersDetails(id);

            return View(model);

        }
        #endregion

        [Route("/Orders")]
        [Route("/Order")]
        public async Task<IActionResult> Orders()
        {
            var model = await _OrderService.GetOrders();
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }









        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ShowCard()
        {
            if (!User.Identity.IsAuthenticated)
            {
                var CartVM = new ShowCardVM();

                CartVM.ShowCardNouser = new CartViewModel()
                {
                    CartItems = _cart.CartItems,
                    OrderTotal = _cart.CartItems.Sum(c => c.getTotalPrice())
                };
       
                return View(CartVM);

            }
            else
            {
                var model = new ShowCardVM();
                model.blogs = await _ProductService.GetProducts();


                string UserId = User.GetUserId();
                var finduser = await _UserService.GetEmployee(UserId);
                if (finduser == null)
                    return RedirectToAction("login", "Users");
                try
                {
                    model.Order = (await _OrderService.GetOrdersDetailsUserId(finduser.Id));
                }
                catch (Exception)
                {


                }
                if (model.Order != null)
                    model.OrdersDetails = model.Order.orderDetails;


                return View(model);
            }

        }
        [HttpGet]

        public async Task<IActionResult> DeleteCard(int id)
        {
            if (!User.Identity.IsAuthenticated)

            {
                _cart.removeItem(id);
            }
            else
            {
                string Userid = User.GetUserId();
                var finduser = await _UserService.GetEmployee(Userid);

                var item = await _OrderDetialservice.GetOrderDetialsDetails(id);
                if (item.Count > 1)
                {
                    item.Count--;
                    var blogpraice = item.Product;
                    item.Price = ((int)(item.Count * (blogpraice.OffPrice == 0 ? blogpraice.Price : blogpraice.OffPrice)));
                    await _OrderDetialservice.UpdateOrderDetials(id, _mapper.Map<UpdateOrderDetialsVM>(item));
                }
                else
                    if (item.Count == 1)
                {
                    await _OrderDetialservice.DeleteOrderDetials(id);

                }
                else
                {
                    return NotFound();
                }
            }


            return RedirectToAction("ShowCard");
        }
        [HttpGet]
        public async Task<IActionResult> AddCard(int id)
        {
            int d_id = 0;
            try
            {
                var Product = await _ProductService.GetProductsDetails(id);
                if (!User.Identity.IsAuthenticated)
                {

                    if (Product != null)
                    {
                        var cartItem = new CartItem()
                        {
                            Item = Product,
                            Quantity = 1
                        };
                        _cart.addItem(cartItem);
                    }
                }
                else
                {
                    string Userid = User.GetUserId();
                    var finduser = await _UserService.GetEmployee(Userid);
                    if (finduser == null)
                        return RedirectToAction("login", "Users");

                    var order = (await _OrderService.GetOrdersDetailsUserId(Userid));
                    if (order != null)
                    {

                        var isdetials = await _OrderDetialservice.GetOrderDetialsDetails(order.Id, id);
                        if (isdetials.Success)
                        {
                            var detials = await _OrderDetialservice.GetOrderDetialsBlogId_OrderId(id, order.Id);
                            detials.Count += 1;
                            detials.Price = (int)((detials.Product.OffPrice.ToString().Equals("0") ? (int)detials.Product.Price : (int)detials.Product.OffPrice) * detials.Count);
                            await _OrderDetialservice.UpdateOrderDetials(detials.Id, _mapper.Map<UpdateOrderDetialsVM>(detials));
                            d_id = detials.Id;
                        }
                        else
                        {
                            var details = new OrderDetialsVM()
                            {
                                ProductId = id,
                                OrderId = order.Id,
                                Count = 1,
                                Price = (int)((Product.OffPrice.ToString().Equals("0") ? (int)Product.Price : (int)Product.OffPrice))
                            };
                            await _OrderDetialservice.CreateOrderDetials(_mapper.Map<CreateOrderDetialsVM>(details));

                            d_id = details.Id;
                        }

                    }
                    else
                    {
                        var neworder = new OrderVM
                        {
                            LastModifiedDate = DateTime.Now,
                            Finaly = false,
                            UserId = finduser.Id

                        };
                        var Order_Create = await _OrderService.CreateOrder(_mapper.Map<CreateOrderVM>(neworder));



                        var details = new OrderDetialsVM()
                        {
                            ProductId = id,
                            OrderId = Order_Create,
                            Count = 1,
                            Price = (int)((Product.OffPrice.ToString().Equals("0") ? (int)Product.Price : (int)Product.OffPrice))
                        };
                        await _OrderDetialservice.CreateOrderDetials(_mapper.Map<CreateOrderDetialsVM>(details));
                        d_id = details.Id;


                    }

                }
            }
            catch (Exception ex)
            {


            }
            return RedirectToAction("ShowCard");
        }

        [HttpGet]
        public async Task<IActionResult> CheckOut(string link = "/", string ErrorMessage = "")
        {
            ViewBag.mymodal = true;
            ViewBag.ErrorMessage = ErrorMessage;
            ViewBag.forward = link;
            var model = new ShowCardVM();
            model.blogs = await _ProductService.GetProducts();

            if (!User.Identity.IsAuthenticated)
            {
                model.ShowCardNouser = new CartViewModel()
                {
                    CartItems = _cart.CartItems,
                    OrderTotal = _cart.CartItems.Sum(c => c.Quantity * c.Item.Price)
                };
            }

            else
            {
                string Userid = User.GetUserId();
                var finduser = await _UserService.GetEmployee(Userid);
                if (finduser == null)
                    return RedirectToAction("login", "Users");
                model.Order = await _OrderService.GetOrdersDetailsUserId(Userid);


                if (model.Order == null || model.OrdersDetails == null)
                    return RedirectToAction("Index", "Home");
                if (!model.Order.orderDetails.Any())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);

        }



        [HttpPost]

        public async Task<IActionResult> Payment(string password, string username, string name, string email = "", string family = "", string phone = "")
        {
            if (!User.Identity.IsAuthenticated)
            {
                if (name == "" || family == "" /*|| phone == ""*/ /*|| phone.Length != 11 */|| string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || password.Length < 8)
                    return RedirectToAction("CheckOut");

                if (!string.IsNullOrWhiteSpace(email))
                {
                    var findUserbyEmail = await _UserService.IS_EXS_EMAIL(email);
                    if (findUserbyEmail.Success)
                    {
                        return RedirectToAction("CheckOut", new { ErrorMessage = "امییل تکراری است لطفا ایمیل معتبر انتخاب کنید", link = "/Order/CheckOut" });
                    }
                }

                //var findUserbyphone = await _UserService.IS_EXS_PHONE(phone);
                //if (findUserbyphone.Success)
                //{
                //    return RedirectToAction("CheckOut", new { ErrorMessage = "شماره تلفن تکراری است لطفا شماره همراه معتبر انتخاب کنید", link = "/ManageVideoBlog/CheckOut" });
                //}
                var findUserbUseraName = await _UserService.IS_EXS_USERNAME(username);
                if (findUserbUseraName.Success)
                {
                    return RedirectToAction("CheckOut", new { ErrorMessage = " نام کاربری تکراری است لطفا نام کاربری معتبر انتخاب کنید", link = "/Order/CheckOut" });
                }



                var result = await _AuthenticationService.Register(new Pr_Signal_ir.MVC.Models.RegisterVM
                {

                    FirstName = name,
                    LastName = family,
                    UserName = username,
                    Password = password,

                    Email = string.IsNullOrEmpty(email) ? null : email,
                });

                if (result)
                {
                    var getUser = (await _UserService.GetEmployees()).Where(a => a.Email == email).FirstOrDefault();
                    if (getUser != null)
                    {
                        TempData["UserId"] = getUser.Id;
                        var neworder = new OrderVM { Finaly = false, DateCreated = DateTime.Now, UserId = getUser.Id };
                        var OrderId = await _OrderService.CreateOrder(_mapper.Map<CreateOrderVM>(neworder));

                        foreach (var item in _cart.CartItems)
                        {
                            var NewOrder = new OrderDetialsVM
                            {
                                ProductId = item.Item.Id,
                                Count = item.Quantity,
                                Price = (int)((item.Quantity) * (item.Item.OffPrice == 0 ? item.Item.Price : item.Item.OffPrice)),
                                OrderId = OrderId
                            };
                            await _OrderDetialservice.CreateOrderDetials(_mapper.Map<CreateOrderDetialsVM>(NewOrder));

                        }

                    }

                    var order = await _OrderService.GetOrdersDetailsUserId(getUser.Id);
                    if (order == null)
                        return Redirect("/Error");


                    order.Finaly = true;
                    await _OrderService.UpdateOrder(order.Id, _mapper.Map<UpdateOrderVM>(order));
                    return RedirectToAction("Index", "Home", new { ErrorMessage = "خرید شما با موفقیت انجام شد   ", link = "/" });


                }





            }
            else
            {
                string USerid = User.GetUserId();
                var finduser = await _UserService.GetEmployee(USerid);
                if (finduser == null)
                    return RedirectToAction("login", "Users");
                var order = await _OrderService.GetOrdersDetailsUserId(USerid);
                if (order == null)
                    return Redirect("/Error");


                order.Finaly = true;
                await _OrderService.UpdateOrder(order.Id, _mapper.Map<UpdateOrderVM>(order));

                return RedirectToAction("Index", "Home", new { ErrorMessage = "خرید شما با موفقیت انجام شد با   ", link = "/" });




            }


            return RedirectToAction("Checkout");


        }



    }
}