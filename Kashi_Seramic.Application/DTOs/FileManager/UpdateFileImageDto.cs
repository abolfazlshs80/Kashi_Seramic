
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FileManager
{
    public class UpdateFileManagerDto : BaseDto, IFileManagerDto
    {
        public string Path { get; set; }

        public string Title { get; set; }
        public string? Type { get; set; }
    }
}
