using AutoMapper;
using Kashi_Seramic.Application.Models.Identity;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Employe;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using System.IdentityModel.Tokens.Jwt;

namespace Pr_Signal_ir.MVC.Services
{


    public class UserService : IUserService
    {
        private readonly Kashi_Seramic.Application.Contracts.Identity.IAuthService _authenticationService;
        private readonly Kashi_Seramic. Application.Contracts.Identity. IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private JwtSecurityTokenHandler _tokenHandler;

        public UserService( ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor,
            IMapper mapper, Kashi_Seramic.Application.Contracts.Identity.IAuthService authenticationService,
            Kashi_Seramic.Application.Contracts.Identity.IUserService userService)
           
        {
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._tokenHandler = new JwtSecurityTokenHandler();
            _authenticationService = authenticationService;
            _userService = userService;
        }

        public async Task<EmployeResponseVM> DeleteEmployee(EmployeeVM model)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeVM> GetEmployee(string userId)
        {
            var user = await _userService.GetEmployee(userId);

            return _mapper.Map<EmployeeVM>(user);
        }

        public async Task<IEnumerable<EmployeeVM>> GetEmployees()
        {
            var user = await _userService.GetEmployees();

            return _mapper.Map<List<EmployeeVM>>(user);
        }

        public async Task<Response<int>> IS_EXS_EMAIL(string email)
        {
            var model = new Response<int>();
            model.Success = false;
            var user = await _userService.GetEmployees();
            if (user.Any(user => user.Email == email))
                model.Success = true;

            return model;
        }

        public async Task<Response<int>> IS_EXS_PHONE(string phone)
        {
            var model = new Response<int>();
            model.Success = false;
            var user = await _userService.GetEmployees();
            if (user.Any(user => user.PhoneNumber == phone))
                model.Success = true;

            return model;
        }

        public async Task<Response<int>> IS_EXS_USERNAME(string username)
        {
            var model = new Response<int>();
            model.Success = false;
            var user = await _userService.GetEmployees();
            if (user.Any(user => user.Username == username))
                model.Success = true;

            return model;
        }

        public async Task<Response<int>> ResetPassword(Kashi_Seramic.Application.Models.Identity.ChangePasswordDto model)
        {
            var StatusModel = new Response<int>();
            StatusModel.Success = false;
            var user = await _userService.GetEmployee(model.UserId);
            if (user != null)
            {
                StatusModel.Success = true;
            }
            var res = await _userService.ChangePasswordEmployee(model);
            StatusModel.Success = res.Status.Value;


            return StatusModel;
        }

        public async Task<EmployeResponseVM> UpdateEmployee(EmployeeVM model)
        {
            var res = await _userService.UpdateEmployee(_mapper.Map<Employee>(model));
            return _mapper.Map<EmployeResponseVM>(res);
        }
    }
}
