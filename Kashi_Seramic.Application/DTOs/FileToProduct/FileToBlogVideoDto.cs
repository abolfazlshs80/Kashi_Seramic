using Kashi_Seramic.Application.DTOs.FileManager;
using Pr_Signal_ir.Application.DTOs.Product;
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FileToProduct
{
    public class FileToProductDto
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public FileManagerDto FileManager { get; set; }
        //   public ProductDto Product { get; set; }
    }
}
