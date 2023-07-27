using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Pr_Signal_ir.MVC.Services;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IFileService
    {
        Task<string> CreateFile(IFormFile file, string directoryName, string rnd, string Name, string Type);
        Task<string> CreateVideoFile(IFormFile file, string directoryName, string Name, string Type, IHubContext<NotifyHub> _notifyHub, IWebHostEnvironment env);
        Task DeleteFile(string directoryName, string Name, string Type);
    }
}
