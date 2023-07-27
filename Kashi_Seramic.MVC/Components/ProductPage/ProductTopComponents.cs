namespace Kashi_Seramic.MVC.Components.ProductPage
{
    public class ProductTopComponents : ViewComponent
    {
        private readonly IProductService _ProductService;

        private readonly IMapper _mapper;

        public ProductTopComponents(IProductService ProductService,
            IMapper mapper)
        {
            _ProductService = ProductService;

            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ProductService.GetProducts();

            return View("/Views/Components/ProductPage/ProductTop.cshtml", model.Take(5).OrderByDescending(a => a.Id));
        }

    }
}
