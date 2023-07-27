using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models;

namespace Kashi_Seramic.MVC.Components.HomePage
{
    public class NewBlogMainPageComponents : ViewComponent
    {
        private readonly ICategoryService _catService;
        private readonly IBlogService _blogService;
        private readonly IProductService _ProductService;
        private readonly ISettingService _settingService;

        private readonly IMapper _mapper;

        public NewBlogMainPageComponents(ICategoryService catService, IBlogService _blogService, ISettingService _settingService,
            IMapper mapper, IProductService ProductService)
        {
            _catService = catService;
            this._blogService = _blogService;
            this._settingService = _settingService;

            _mapper = mapper;
            _ProductService = ProductService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _blogService.GetBlogs();


            return View("/Views/Components/HomePage/NewBlogMainPage.cshtml", model);
        }

    }
}
