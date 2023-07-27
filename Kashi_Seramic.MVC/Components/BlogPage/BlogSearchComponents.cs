namespace Kashi_Seramic.MVC.Components.BlogPage
{
    public class BlogSearchComponents : ViewComponent
    {


        private readonly IMapper _mapper;

        public BlogSearchComponents(
            IMapper mapper)
        {


            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("/Views/Components/BlogPage/BlogSearch.cshtml");
        }

    }
}
