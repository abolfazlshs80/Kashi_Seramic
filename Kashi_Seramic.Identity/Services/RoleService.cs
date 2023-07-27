using Kashi_Seramic.Application.Contracts.Identity;
using Kashi_Seramic.Application.Models.Identity;
using Kashi_Seramic.Application.Models.Identity.Role;
using Kashi_Seramic.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Pr_Signal_ir.Application.Models.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Identity.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<ResponseDto> AddRole(AddRoleDto model)
        {
            var res = await _roleManager.CreateAsync(new IdentityRole { Name = model.RoleName, NormalizedName = model?.ToString()?.ToUpper() });
            var newmodel = new ResponseDto();
            if (res.Succeeded)
            {
                newmodel.Status = true;
                newmodel.Message = "success";
            }
            else
            {
                newmodel.Status = false;
                newmodel.Message = "failed";
            }
            return newmodel;
        }

        public async Task<ResponseDto> AddRoleToUsers(AddRoleToUserDto model)
        {
            var res = new IdentityResult();
            var usersRoles = await GetRoles(model.UserId);
            var users = await _userManager.FindByIdAsync(model.UserId);
            if (!model.Selected)
            {
                if (await _userManager.IsInRoleAsync(users, model.RoleName))
                    res = await _userManager.RemoveFromRoleAsync(users, model.RoleName);
            }
            else
            {
                if (!await _userManager.IsInRoleAsync(users, model.RoleName))
                {
                    res = await _userManager.AddToRoleAsync(users, model.RoleName);

                }

            }

            var newmodel = new ResponseDto();
            if (res.Succeeded)
            {
                newmodel.Status = true;
                newmodel.Message = "success";
            }
            else
            {
                newmodel.Status = false;
                newmodel.Message = "failed";
            }
            return newmodel;
        }

        public async Task<ResponseDto> DeleteRoleFromUsers(AddRoleToUserDto model)
        {
            var res = await _userManager.RemoveFromRoleAsync(await _userManager.FindByIdAsync(model.UserId), (await _roleManager.FindByIdAsync(model.RoleId)).Name);
            var newmodel = new ResponseDto();
            if (res.Succeeded)
            {
                newmodel.Status = true;
                newmodel.Message = "success";
            }
            else
            {
                newmodel.Status = false;
                newmodel.Message = "failed";
            }
            return newmodel;
        }

        public async Task<ResponseDto> DeleteRoleRole(string RoleId)
        {
            var res = await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(RoleId));
            var newmodel = new ResponseDto();
            if (res.Succeeded)
            {
                newmodel.Status = true;
                newmodel.Message = "success";
            }
            else
            {
                newmodel.Status = false;
                newmodel.Message = "failed";
            }
            return newmodel;
        }

        public async Task<RolesDto> GetRole(string roleId)
        {
            return await _roleManager.Roles.Where(a => a.Id == roleId).Select(a => new RolesDto()
            {
                RoleId = a.Id,
                RoleName = a.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RolesDto>> GetRoles()
        {

            return await _roleManager.Roles.Select(a => new RolesDto()
            {
                RoleId = a.Id,
                RoleName = a.Name
            }).ToListAsync();
        }
        public async Task<IEnumerable<AddRoleToUserDto>> GetRoles(string id)
        {
            var list = new List<AddRoleToUserDto>();
            foreach (var item in _roleManager.Roles)
            {
                list.Add(new AddRoleToUserDto()
                {
                    RoleId = item.Id,
                    UserId = id,
                    RoleName = item.Name,
                    Selected = (await IsInRole(new AddRoleToUserDto() { RoleId = item.Id, UserId = id })).Status.Value
                });
            }
            return list;
        }

        public async Task<RolesDto> GetUserAndRoles(string UserId)
        {
            var model = _roleManager.Roles.Select(b => new RolesDto()
            {
                RoleId = b.Id,
                RoleName = b.Name
            }).Where(a => a.RoleId == UserId);
            return model.FirstOrDefault()!;
        }

        public async Task<ResponseDto> IsInRole(AddRoleToUserDto model)
        {
            var res = await _userManager.IsInRoleAsync(await _userManager.FindByIdAsync(model.UserId), (await _roleManager.FindByIdAsync(model.RoleId)).Name);
            var newmodel = new ResponseDto();
            if (res)
            {
                newmodel.Status = true;
                newmodel.Message = "success";
            }
            else
            {
                newmodel.Status = false;
                newmodel.Message = "failed";
            }
            return newmodel;
        }

        public async Task<ResponseDto> UpdateRole(AddRoleDto model)
        {
            var newmodel1 = await _roleManager.FindByIdAsync(model.RoleId);
            newmodel1.Id = model.RoleId;
            newmodel1.Name = model.RoleName;
            newmodel1.NormalizedName = model.RoleName.ToString().ToUpper();
            var res = await _roleManager.UpdateAsync(newmodel1);
            var newmodel = new ResponseDto();
            if (res.Succeeded)
            {
                newmodel.Status = true;
                newmodel.Message = "success";
            }
            else
            {
                newmodel.Status = false;
                newmodel.Message = "failed";
            }
            return newmodel;
        }
    }
}
