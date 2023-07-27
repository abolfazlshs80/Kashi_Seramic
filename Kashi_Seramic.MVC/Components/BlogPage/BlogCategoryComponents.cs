namespace Kashi_Seramic.MVC.Components.BlogPage
{
    public class BlogCategoryComponents : ViewComponent
    {
        private readonly ICategoryService _CategoryService;

        private readonly IMapper _mapper;

        public BlogCategoryComponents(ICategoryService CategoryService,
            IMapper mapper)
        {
            _CategoryService = CategoryService;

            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _CategoryService.GetCategorys();
            return View("/Views/Components/BlogPage/BlogCategory.cshtml", model);
        }

    }
}
