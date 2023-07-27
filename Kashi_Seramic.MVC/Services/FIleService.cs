using Microsoft.AspNetCore.SignalR;
using NuGet.Packaging.Signing;

using Pr_Signal_ir.MVC.Contracts;

namespace Pr_Signal_ir.MVC.Services
{
    public class FileService : IFileService
    {
        private const string V = "";

        public async Task<string> CreateFile(IFormFile file, string directoryName, string rnd, string Name, string Type)
        {
            string name = Name + rnd + Type + Path.GetExtension(file.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", directoryName, name);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return name;
        }
        [RequestFormLimits(MultipartBodyLengthLimit = 1000000000)]
        public async Task<string> CreateVideoFile(IFormFile file, string directoryName, string Name, string Type, IHubContext<NotifyHub> _notifyHub, IWebHostEnvironment env)
        {
            byte[] buffer = new byte[1024 * 1024];
            long totalBytes = file.Length;
            var path =$"/Uploder/{directoryName}/" + Name.Replace(" ","-") + System.IO.Path.GetExtension(file.FileName);
            using FileStream output = System.IO.File.Create( env.WebRootPath + path);
            using Stream input = file.OpenReadStream();
            long totalReadBytes = 0;
            int readBytes;

            while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                await output.WriteAsync(buffer, 0, readBytes);
                totalReadBytes += readBytes;
                int progress = (int)((float)totalReadBytes / (float)totalBytes * 100.0);
                await _notifyHub.Clients.All.SendAsync("updateProgress", progress);
                await Task.Delay(10); // It is only to make the process slower
            }
            return path;

        }

        public async Task DeleteFile(string directoryName, string Name, string Type)
        {

            if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", directoryName, Name)))
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", directoryName, Name));
            }
            else if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploder", directoryName, Name)))
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploder", directoryName, Name));
            }


        }
    }
}
