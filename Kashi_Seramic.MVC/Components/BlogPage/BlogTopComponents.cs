namespace Kashi_Seramic.MVC.Components.BlogPage
{
    public class BlogTopComponents : ViewComponent
    {
        private readonly IBlogService _blogService;

        private readonly IMapper _mapper;

        public BlogTopComponents(IBlogService blogService,
            IMapper mapper)
        {
            _blogService = blogService;

            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _blogService.GetBlogs();

            return View("/Views/Components/BlogPage/BlogTop.cshtml", model.Take(5).OrderByDescending(a => a.Id));
        }

    }
}
