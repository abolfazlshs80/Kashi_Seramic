using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models;

namespace Kashi_Seramic.MVC.Components.HomePage
{
    public class LastProductItemMainPageComponents : ViewComponent
    {
        private readonly ICategoryService _catService;
        private readonly IBlogService _blogService;
        private readonly IProductService _ProductService;
        private readonly ISettingService _settingService;

        private readonly IMapper _mapper;

        public LastProductItemMainPageComponents(ICategoryService catService, IBlogService _blogService, ISettingService _settingService,
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
            ViewBag.Title = "قیمت آسان برای صاحبان خانه";
            ViewBag.Descrition = "          لورم ایپسوم به سادگی ساختار چاپ و متن را در بر می گیرد. لورم ایپسوم به مدت 40 سال\r\n                        استاندارد صنعت بوده است.لورم ایپسوم به سادگی ساختار چاپ و متن را در بر می گیرد. لورم\r\n                        ایپسوم به مدت 40 سال استاندارد صنعت بوده است.\r\n               ";
            var model = await _ProductService.GetProductsToLasted();


            return View("/Views/Components/HomePage/ProductItemMainPage.cshtml", model);
        }

    }
}
