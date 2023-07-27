using Kashi_Seramic.Application.DTOs.FileToProduct;
using Pr_Signal_ir.Application.DTOs.Common;

using Pr_Signal_ir.Application.DTOs.FileToBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FileManager
{
    public class FileManagerDto : BaseDto, IFileManagerDto
    {
        public string Path { get; set; }

        public string Title { get; set; }
        public string? Type { get; set; }
        public bool IsUploaderFile { get; set; }
        public ICollection<FileToBlogDto> FileToBlog { get; set; }
        public ICollection<FileToProductDto> FileToProduct { get; set; }
    }
}
