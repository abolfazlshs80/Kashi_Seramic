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
    public class FilterItemCreateComponents : ViewComponent
    {
        private readonly IFilterValueProductService _cateService;
        private readonly IFilterProductService _filter;

        private readonly IMapper _mapper;

        public FilterItemCreateComponents(IFilterValueProductService cateService,
            IMapper mapper,
            IFilterProductService filter)
        {
            _cateService = cateService;

            _mapper = mapper;
            _filter = filter;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _filter.GetFilterProductsDetails(ViewBag.FilterId);
            return View("/Views/Components/Admin/Product/FilterItemCreate.cshtml", model);
        }

    }
}


