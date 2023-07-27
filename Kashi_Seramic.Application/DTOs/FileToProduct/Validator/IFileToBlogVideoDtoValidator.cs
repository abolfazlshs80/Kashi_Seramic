using FluentValidation;
using Kashi_Seramic.Application.DTOs.FileToProduct;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FileToProduct.Validator
{
    public class IFileToProductDtoValidator : AbstractValidator<FileToProductDto>
    {
        private IFileToProductRepository _rep_FileToProduct;
        public IFileToProductDtoValidator(IFileToProductRepository rep_FileToProduct)
        {
            _rep_FileToProduct = rep_FileToProduct;




        }
    }
}
