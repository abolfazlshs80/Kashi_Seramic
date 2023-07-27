using AutoMapper;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pr_Signal_ir.MVC.Models.Search;

using System.Reflection.Metadata;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Order;
using Pr_Signal_ir.MVC.Models.Receipt;
using Kashi_Seramic.Application.DTOs.Order;
using Kashi_Seramic.Application.Features.Order.Requests.Commands;
using Kashi_Seramic.Application.Features.Order.Requests.Queries;
using Kashi_Seramic.Application.Features.Product.Requests.Queries;
using Kashi_Seramic.Application.Features.OrderDetials.Requests.Commands;
using Kashi_Seramic.Application.DTOs.OrderDetials;

namespace Pr_Signal_ir.MVC.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public OrderService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService, IUserService userService)
        {
            _userService = userService;
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<int> AddUserToDore(string UserId, int blogId)
        {
            try
            {
                var Order =   await _mediator.Send(new CreateOrderCommand() { CreateOrderDto = new CreateOrdersDto { UserId = UserId, Finaly = true, TeacherPaymentStatus = false } });

                 await _mediator.Send(new CreateOrderDetialsCommand() { CreateOrderDetialsDto = new CreateOrderDetialsDto { ProductId = blogId, Count = 1, OrderId = Order.Id, Price = 0 } });
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public async Task<int> CreateOrder(CreateOrderVM Order)
        {
            Order.DateCreated = DateTime.Now;
            Order.LastModifiedDate = DateTime.Now;
            var res  = await _mediator.Send(new CreateOrderCommand() { CreateOrderDto = (_mapper.Map<CreateOrdersDto>(Order)) });
            if (res.Success)
            {
                return res.Id;
            }
            else
                return 0;


        }



        public async Task<Response<int>> DeleteOrder(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteOrderCommand() { Id = id });
            return model;

        }

        public async Task<Response<bool>> ExistsOrder(int id)
        {
            var res = await _mediator.Send(new GetOrderDetailRequest() { Id = id });
            var model = new Response<bool>() { };
            if (res != null)
            {
                model.Success = true;
            }
            else
                model.Success = false;

            return model;

        }

        public async Task<List<OrderVM>> GetOrders()
        {

            try
            {
                var Order = await _mediator.Send(new GetOrderListRequest());
                if (Order == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<List<OrderVM>>(Order.Where(a => !a.TeacherPaymentStatus));
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<List<ReceiptVM>> GetOrdersALL()
        {
            try
            {
                List<ReceiptVM> lstmodel = new List<ReceiptVM>();
                var lstorder = await _mediator.Send(new GetOrderListRequest());
                if (lstorder == null)
                {
                    throw new NotImplementedException();
                }


                foreach (var blog in ( await _mediator.Send(new GetProductListRequest())))
                {
                    int sum = 0;
                    foreach (var order in lstorder.Where(a => a.Finaly && !a.TeacherPaymentStatus).ToList())
                    {
                        sum += order.orderDetails.Where(a => a.ProductId == blog.Id && a.OrderId == order.Id).Sum(a => a.Count);
                    }
                    if (sum > 0)
                        lstmodel.Add(new ReceiptVM { Blog = _mapper.Map<ProductVM>(blog), Count = sum, });
                }
                return _mapper.Map<List<ReceiptVM>>(lstmodel);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<ReceiptVM>> GetOrdersByUserId(string UserId)
        {
            try
            {
                List<ReceiptVM> lstmodel = new List<ReceiptVM>();
                var lstorder = await _mediator.Send(new GetOrderListRequest());
                if (lstorder == null)
                {
                    throw new NotImplementedException();
                }


                foreach (var blog in (await _mediator.Send(new GetProductListRequest())).Where(a => a.Owner == UserId))
                {
                    int sum = 0;
                    foreach (var order in lstorder.Where(a => a.Finaly && !a.TeacherPaymentStatus).ToList())
                    {
                        sum += order.orderDetails.Where(a => a.ProductId == blog.Id && a.OrderId == order.Id).Sum(a => a.Count);
                    }
                    if (sum > 0)
                        lstmodel.Add(new ReceiptVM { Blog = _mapper.Map<ProductVM>(blog), Count = sum, });
                }
                return _mapper.Map<List<ReceiptVM>>(lstmodel);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<OrderVM> GetOrdersDetails(int id)
        {
            try
            {
                var Order = await _mediator.Send(new GetOrderDetailRequest() { Id = id });

                if (Order == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<OrderVM>(Order);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<OrderVM> GetOrdersDetailsUserId(string id)
        {
            try
            {
                var Order = await _userService.GetEmployee(id);

                if (Order == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<OrderVM>(Order);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<OrderVM>> GetOrdersUserId(string id)
        {
            try
            {
                var Order = await _mediator.Send(new GetOrderListRequest());

                if (Order == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<List<OrderVM>>(Order.Where(a => a.UserId == id && !a.TeacherPaymentStatus).ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> IsUserInDore(string UserId, int blogId)
        {
            var model = new Response<int>() { };
            if ((await _mediator.Send(new GetOrderListRequest())).Any(a => a.UserId==UserId &&a.orderDetails.Any(b=>b.ProductId== blogId)))
                model.Success = true;
            else
                model.Success = false;
            return model.Success;
        }

        public async Task<Response<int>> UpdateEnableOrderDetials(int id)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new GetOrderDetailRequest() { Id = id });

            if (res == null)
                model.Success = false;
            res.Finaly = true;
       
            await _mediator.Send(new UpdateOrderCommand() { Id = id, OrderDto = _mapper.Map<UpdateOrdersDto>(res) 
        });
            model.Success = true;
            model.Data = res.Id;

            return model;
        }

        public async Task<Response<int>> UpdateOrder(int id, UpdateOrderVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateOrdersDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateOrderCommand() { Id = id, OrderDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;

        }
    }
}
