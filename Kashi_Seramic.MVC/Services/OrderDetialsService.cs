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
using Pr_Signal_ir.MVC.Models.OrderDetials;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Order;
using Kashi_Seramic.Application.DTOs.OrderDetials;
using Kashi_Seramic.Domain;
using Kashi_Seramic.Application.Features.OrderDetials.Requests.Commands;
using Kashi_Seramic.Application.Features.OrderDetials.Requests.Queries;

namespace Pr_Signal_ir.MVC.Services
{
    public class OrderDetialsService : IOrderDetialservice
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public OrderDetialsService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateOrderDetials(CreateOrderDetialsVM leaveType)
        {
            var model = new Response<int>() { };
            leaveType.DateCreated = DateTime.Now;
            leaveType.LastModifiedDate = DateTime.Now;
            var res = await _mediator.Send(new CreateOrderDetialsCommand() { CreateOrderDetialsDto = (_mapper.Map<CreateOrderDetialsDto>(leaveType)) });
            if (res.Success)
            {
                model.Success = true;
            }
            else
                model.Success = false;
            return model;
        }

        public async Task<Response<int>> DeleteOrderDetials(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteOrderDetialsCommand() { Id = id });
            return model;

        }

        public async Task<Response<bool>> ExistsOrderDetials(int id)
        {
            var res = await _mediator.Send(new GetOrderDetialsDetailRequest() { Id = id });
            var model = new Response<bool>() { };
            if (res != null)
            {
                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<List<OrderDetialsVM>> GetOrderDetials()
        {
            try
            {
                var OrderDetials = await _mediator.Send(new GetOrderDetialsListRequest());

                if (OrderDetials == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<OrderDetialsVM>>(OrderDetials);
                return _mapper.Map<List<OrderDetialsVM>>(OrderDetials);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<OrderDetialsVM> GetOrderDetialsDetails(int id)
        {
            try
            {
                var Order = await _mediator.Send(new GetOrderDetialsDetailRequest() { Id = id });

                if (Order == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<OrderDetialsVM>(Order);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Response<int>> GetOrderDetialsDetails(int orderId, int blogId)
        {
            try
            {
                var model = new Response<int>();
                var Order = await  _mediator.Send(new GetOrderDetialsListRequest());
                model.Success = false;
                if ((Order.Where(a => a.OrderId.Equals(orderId) && a.ProductId.Equals(blogId)).Any()))
                {
                    model.Success = true;
                }
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<OrderDetialsVM> GetOrderDetialsBlogId_OrderId(int blogId, int orderId)
        {
            try
            {
                var model = new OrderDetialsVM();
                var Order = await _mediator.Send(new GetOrderDetialsListRequest());

                if ((Order.Where(a => a.OrderId.Equals(orderId) && a.ProductId.Equals(blogId)).Any()))
                {
                    model = _mapper.Map<OrderDetialsVM>(Order.Where(a => a.OrderId.Equals(orderId) && a.ProductId.Equals(blogId)).FirstOrDefault());
                }
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<int>> UpdateOrderDetials(int id, UpdateOrderDetialsVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateOrderDetialsDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateOrderDetialsCommand() { Id = id, OrderDetialsDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;

        }
    }
}
