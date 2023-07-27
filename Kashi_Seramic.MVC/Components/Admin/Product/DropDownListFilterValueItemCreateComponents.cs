using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.MVC.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Services;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;

namespace Kashi_Seramic.MVC.Components.Admin.Product
{
    public class DropDownListFilterValueItemCreateComponents : ViewComponent
    {
        private readonly IFilterValueProductService _cateService;
        private readonly IFilterProductService _fileProductService;

        private readonly IMapper _mapper;

        public DropDownListFilterValueItemCreateComponents(IFilterValueProductService cateService,
            IMapper mapper,
            IFilterProductService fileProductService)
        {
            _cateService = cateService;

            _mapper = mapper;
            _fileProductService = fileProductService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _fileProductService.GetFilterProductsByCatId(12);
            return View("/Views/Components/Admin/Product/DropDownListFilterValueItemCreate.cshtml", model);
        }

    }
}


