using Kashi_Seramic.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string userId);
        Task<EmployeResponse> UpdateEmployee(Employee model);
        Task<EmployeResponse> DeleteEmployee(Employee model);
        Task<ResponseDto> ChangePasswordEmployee(ChangePasswordDto model);
    }
}
