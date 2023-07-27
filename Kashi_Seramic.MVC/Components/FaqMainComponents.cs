using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models;

namespace Pr_Signal_ir.MVC.Components
{
    public class FaqMainComponents:ViewComponent
    {
        private readonly ICategoryService _catService;
        private readonly IBlogService _blogService;
        private readonly IProductService _ProductService;
        private readonly ISettingService _settingService;
        private readonly IFaqUserService _faqUserService;

        private readonly IMapper _mapper;

        public FaqMainComponents(ICategoryService catService,  IBlogService _blogService, ISettingService _settingService,
            IMapper mapper, IProductService ProductService, IFaqUserService faqUserService)
        {
            this._catService = catService;
            this._blogService = _blogService;
            this._settingService = _settingService;

            this._mapper = mapper;
            _ProductService = ProductService;
            _faqUserService = faqUserService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var model = new FaqVM();

          //model.Setting= (await _settingService.GetSettings()).FirstOrDefault();
 
           
            return View("/Views/Components/FaqMain.cshtml",await _faqUserService.GetFaqUsersByNumber(6));
        }
    
    }
}
