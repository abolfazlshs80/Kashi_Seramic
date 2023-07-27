namespace Kashi_Seramic.MVC.Components.ProductPage
{
    public class FilterProductComponents : ViewComponent
    {
        private readonly IProductService _ProductService;

        private readonly IMapper _mapper;

        public FilterProductComponents(IProductService ProductService,
            IMapper mapper)
        {
            _ProductService = ProductService;

            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ProductService.GetProductsDetails(ViewBag.blogid);

            return View("/Views/Components/ProductPage/FilterProduct.cshtml", model);
        }

    }
}
