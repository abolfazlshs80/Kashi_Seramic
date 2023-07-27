using AutoMapper;
using Kashi_Seramic.Application.Contracts.Identity;
using Kashi_Seramic.Application.Models.Identity;
using Kashi_Seramic.Application.Models.Identity.Role;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Employe;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Roles;
using Pr_Signal_ir.MVC.Services.Base;
using System.IdentityModel.Tokens.Jwt;
using IRoleService = Pr_Signal_ir.MVC.Contracts.IRoleService;

namespace Pr_Signal_ir.MVC.Services
{


    public class RoleService : IRoleService
    {
        private readonly IAuthService _authenticationService;
        private readonly Kashi_Seramic.Application.Contracts.Identity.IUserService _userService;
        private readonly Kashi_Seramic.Application.Contracts.Identity.IRoleService _roleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private JwtSecurityTokenHandler _tokenHandler;

        public RoleService(IAuthService authenticationService, Kashi_Seramic.Application.Contracts.Identity.IUserService userService, Kashi_Seramic.Application.Contracts.Identity.IRoleService roleService, ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)

        {
            _authenticationService = authenticationService;
            _userService = userService;
            _roleService = roleService;
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._tokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<ResponseDto> AddRole(AddRoleVM model)
        {
          
            return  await  _roleService.AddRole((_mapper.Map<AddRoleDto>(model)));

        }

        public async Task<ResponseDto> AddRoleToUsers(RoleVM model)
        {
            return await _roleService.AddRoleToUsers(_mapper.Map<AddRoleToUserDto>(model));
        }

        public async Task<ResponseDto> DeleteRoleFromUsers(AddRoleToUserVM model)
        {
            return await _roleService.DeleteRoleFromUsers(_mapper.Map<AddRoleToUserDto>(model));
        }

        public async Task<ResponseDto> DeleteRoleRole(string RoleId)
        {
            return await _roleService.DeleteRoleRole(RoleId);
        }

        public async Task<RoleVM> GetRole(string roleId)
        {
            return _mapper.Map<RoleVM>(await _roleService.GetRole(roleId));
        }

        public async Task<IEnumerable<RoleVM>> GetRoles()
        {
            return _mapper.Map <IEnumerable< RoleVM >>( await _roleService.GetRoles());
        }
        public async Task<IEnumerable<RoleVM>> GetRoleschecked(string id)
        {
            return _mapper.Map<IEnumerable<RoleVM>>(await _roleService.GetRoles(id));
        }

        public async Task<RoleVM> GetUserAndRoles(string UserId)
        {//no
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> IsInRole(AddRoleToUserVM model)
        {
            return await  _roleService.IsInRole(_mapper.Map<AddRoleToUserDto>(model));
        }

        public async Task<ResponseDto> UpdateRole(AddRoleVM model)
        {
            return await _roleService.UpdateRole(_mapper.Map<AddRoleDto>(model));
        }
    }
}
