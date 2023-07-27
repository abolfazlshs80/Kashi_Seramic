using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.MVC.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Services;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;

namespace Kashi_Seramic.MVC.Components.Admin.Tag
{
    public class TagItemCreateComponents : ViewComponent
    {
        private readonly ITagService _cateService;

        private readonly IMapper _mapper;

        public TagItemCreateComponents(ITagService cateService,
            IMapper mapper)
        {
            _cateService = cateService;

            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _cateService.GetTags();
            return View("/Views/Components/Admin/Tag/TageItemCreate.cshtml", model);
        }

    }
}


