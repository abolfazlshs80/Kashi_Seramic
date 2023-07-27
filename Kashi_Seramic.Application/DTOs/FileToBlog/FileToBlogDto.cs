using Kashi_Seramic.Application.DTOs.FileManager;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.FileToBlog
{
    public class FileToBlogDto
    {
        public int ImageId { get; set; }
        public int BlogId { get; set; }
        public FileManagerDto FileManager { get; set; }
     //   public BlogDto Blog { get; set; }
    }
}
