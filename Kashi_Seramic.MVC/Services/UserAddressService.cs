using AutoMapper;
using Kashi_Seramic.Application.DTOs.UserAddress;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.MVC.Models.Users.UserAddres;
using Pr_Signal_ir.MVC.Contracts;

using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public UserAddressService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<List<UserAddressVM>> GetUserAddresssDetailsByUserid(string id)
        {
            try
            {
                var UserAddress = await _mediator.Send(new GetUserAddressListRequest());

                if (UserAddress == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<List<UserAddressVM>>(UserAddress.Where(a=>a.Owner==(id)));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<int>> CreateUserAddress(CreateUserAddressVM leaveType)
        {
            leaveType.CreatedBy = "abolfzl";
            leaveType.DateCreated = DateTime.Now;
            leaveType.LastModifiedDate = DateTime.Now;
            leaveType.LastModifiedBy = "abolfazl";
            var response = new Response<int>();
            var res = await _mediator.Send(new CreateUserAddressCommand() { CreateUserAddressDto = (_mapper.Map<CreateUserAddressDto>(leaveType)) });
            if (res.Success)
            {
                response.Success = true;
                response.Data = res.Id;

            }
            else
                response.Success = false;
            return response;
        }

        public async Task<Response<int>> DeleteUserAddress(int id)
        {
            var response = new Response<int>();
            await _mediator.Send(new DeleteUserAddressCommand() { Id = id });

            response.Success = true;



            return response;





        }

        public async Task<List<UserAddressVM>> GetUserAddresss()
        {
            try
            {
                var UserAddress = await _mediator.Send(new GetUserAddressListRequest());

                if (UserAddress == null)
                {
                    throw new NotImplementedException();
                }
               // var a = _mapper.Map<ICollection<UserAddressVM>>(UserAddress);
                return _mapper.Map<List<UserAddressVM>>(UserAddress.OrderByDescending(a=>a.LastModifiedDate));
            }
            catch (Exception)
            {
                return null;
            }

        }


        public async Task<UserAddressVM> GetUserAddresssDetails(int id)
        {
            try
            {
                var UserAddress = await _mediator.Send(new GetUserAddressDetailRequest() { Id = id });

                if (UserAddress == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<UserAddressVM>(UserAddress);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<int>> UpdateUserAddress(int id, UpdateUserAddressVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateUserAddressDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateUserAddressCommand() { Id = id, UserAddressDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
