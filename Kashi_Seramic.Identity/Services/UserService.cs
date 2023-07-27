using AutoMapper;

using Pr_Signal_ir.Application.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kashi_Seramic.Identity.Models;
using Kashi_Seramic.Application.Models.Identity;
using Kashi_Seramic.Application.Contracts.Identity;

namespace Kashi_Seramic.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto> ChangePasswordEmployee(ChangePasswordDto model)
        {
            var newmodel = new ResponseDto();
            var res2 = await _userManager.RemovePasswordAsync(await _userManager.FindByIdAsync(model.UserId));
            var res = await _userManager.AddPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Password);
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

        public async Task<EmployeResponse> DeleteEmployee(Employee model)
        {
            var newmodel = new EmployeResponse();
            newmodel.Status = false;
            var employee = await _userManager.FindByIdAsync(model.Id);

            if (employee != null)
            {
                var res = await _userManager.DeleteAsync(employee);
                if (res.Succeeded)
                {

                    newmodel.Status = true;
                    newmodel.Message = "با موفقیت انجام شد";
                }

            }
            return newmodel;

        }

        public async Task<Employee> GetEmployee(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            return new Employee
            {
                Email = employee.Email,
                Id = employee.Id,
                Firstname = employee.FirstName,
                Lastname = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                Username = employee.UserName,
            };
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _userManager.Users.ToListAsync();
            return employees.Select(q => new Employee
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName,
                Username = q.UserName,
                PhoneNumber = q.PhoneNumber

            }).ToList();
        }

        public async Task<EmployeResponse> UpdateEmployee(Employee model)
        {
            var newmodel = new EmployeResponse();
            var employee = await _userManager.FindByIdAsync(model.Id);
            // _userManager.AddPasswordAsync(employee,)

            if (employee != null)
            {
                employee.FirstName = model.Firstname!;
                employee.LastName = model.Lastname!;
                employee.UserName = model.Username;
                await _userManager.UpdateAsync(employee);
                newmodel.Status = true;
                newmodel.Message = "با موفقیت انجام شد";
            }
            else
                newmodel.Status = false;
            return newmodel;

        }
    }
}
