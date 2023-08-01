using Pr_Signal_ir.MVC.Models.Search;

namespace Kashi_Seramic.MVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogService _blogService;
        private readonly IProductService _ProductService;

        private readonly ICategoryService _catService;
        private readonly ITagService _tagService;
        private readonly ISettingService _settingService;
        public int Take { get; set; } = 5;
        private readonly IMapper _mapper;

        public SearchController(IBlogService BlogService,
            IMapper mapper, ILogger<HomeController> logger, ISettingService settingService, ICategoryService catService, IProductService ProductService, ITagService tagService)
        {
            this._blogService = BlogService;
            _tagService = tagService;
            _ProductService = ProductService;
            this._mapper = mapper;
            this._catService = catService;
            _logger = logger;
            _settingService = settingService;
        }
        [Route("/Category/{id:int}/{title}/{page?}")]
        public async Task<IActionResult> SearchByCategory(int id, string title, int page = 0)
        {
            title = title.RemoveDahst();
            var model = await _catService.GetCategorysDetails(id);
            if (model == null)
                return NotFound();
            var searchmodel = new SearchAllVM();

            searchmodel.Type = "Category";
            searchmodel.Desc = model.ShortDesc;
            searchmodel.Path2 = model.Name;
            searchmodel.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            searchmodel.SearchVM.AddRange((await _catService.GetBlogsCategoryBySearchVM(id)).Skip(page * Take).Take(Take));
            SetViewbag(searchmodel.SearchVM.Count,page,id,"Category");
            SetLocationBar(true, "دسته بندی ها", title);
           
            return View("SearchItems", searchmodel);

        }
        [Route("/Categori/{id}/{page?}")]
        public async Task<IActionResult> SearchByCategory(int id, int page = 0)
        {
            
            var model = await _catService.GetCategorysDetails(id);
            if (model == null)
                return NotFound();
            var searchmodel = new SearchAllVM();

            searchmodel.Type = "Category";
            searchmodel.Desc = model.ShortDesc;
            searchmodel.Path2 = model.Name;
            searchmodel.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            searchmodel.SearchVM.AddRange((await _catService.GetBlogsCategoryBySearchVM(id)).Skip(page * Take).Take(Take));
            SetViewbag(searchmodel.SearchVM.Count, page, id, "Category");
            SetLocationBar(true, "دسته بندی ها", model.Name);

            return View("SearchItems", searchmodel);

        }
        [Route("/Category/{title}/{page?}")]
        public async Task<IActionResult> SearchByCategory( string title, int page = 0)
        {
            title = title.RemoveDahst();
            if (string.IsNullOrEmpty(title) )
                return NotFound();
            var model = (await _catService.GetCategorys()).Where(a=>a.Name.Contains(title)).FirstOrDefault();
            if (model == null)
                return NotFound();
            var searchmodel = new SearchAllVM();
            searchmodel.Type = "Category";

            searchmodel.Desc = model.ShortDesc;
            searchmodel.Path2 = title;
            searchmodel.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            searchmodel.SearchVM.AddRange((await _catService.GetCategoryBySearchVM(title)).Skip(page * Take).Take(Take));
            SetViewbag(searchmodel.SearchVM.Count, page,0, "Category");
            SetLocationBar(true, "دسته بندی ها", title);

            return View("SearchItems", searchmodel);

        }
        [Route("/Filter/{title}/{page?}")]
        public async Task<IActionResult> SearchByFilter(string title, int page = 0)
        {
            title = title.RemoveDahst();
            if (string.IsNullOrEmpty(title))
                return NotFound();
            var searchmodel = new SearchAllVM();
            searchmodel.Path2 = title;
            searchmodel.Type = "Filter";
            searchmodel.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            searchmodel.SearchVM.AddRange((await _ProductService.GetProductsCategoryByFilter(title)).Skip(page * Take).Take(Take));
            SetViewbag(searchmodel.SearchVM.Count, page, 0, "Category");
            SetLocationBar(true, "دسته بندی ها", title);

            return View("SearchItems", searchmodel);

        }
        [Route("/Tag/{id}/{title}/{page?}")]
        public async Task<IActionResult> SearchByTag(int id, string title,int page = 0)
        {
            title = title.RemoveDahst();
            var model = await _tagService.GetTagsDetails(id);
            if (model == null)
                return NotFound();
            var searchmodel = new SearchAllVM();
            searchmodel.Path2 = model.Name;
            searchmodel.Type = "Tag";
            searchmodel.SearchVM.AddRange((await _tagService.GetTagBySearchVM(id)).Skip(page * Take).Take(Take));
            SetViewbag(searchmodel.SearchVM.Count, page, id, "Tag");
            SetLocationBar(true, "تگ ها", title);
            searchmodel.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            return View("SearchItems", searchmodel);

        }
        [Route("/Tag/{title}/{page?}")]
        public async Task<IActionResult> SearchByTagNoId( string title, int page = 0)
        {
            title = title.RemoveDahst();

            var searchmodel = new SearchAllVM();
            searchmodel.Path2 = title;
            searchmodel.Type = "Tag";
            searchmodel.SearchVM.AddRange((await _tagService.GetTagByTextSearchVM(title)).DistinctBy(a=>a.Id).ToList().Skip(page * Take).Take(Take));
            SetViewbag(searchmodel.SearchVM.Count, page, 0, "Tag");
            SetLocationBar(true, "تگ ها", title);
            searchmodel.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            return View("SearchItems", searchmodel);

        }

        [Route("/Search/{title}")]
        [Route("/Search/{title}/{page?}")]
        public async Task<IActionResult> SearchByText(string title, int page = 0)
        {
            title = title.RemoveDahst();
            if (string.IsNullOrEmpty(title))
                return RedirectToAction("Index", "Home");
            var searchmodel = new SearchAllVM();
            searchmodel.Type = "Search";
            searchmodel.Path2 = title;
            searchmodel.SearchVM.AddRange((await _blogService.GetBlogsBySearchVM(title)).Skip(page * Take).Take(Take)
            );
            searchmodel.SearchVM.AddRange((await _ProductService.GetProductsBySearchVM(title)).Skip(page * Take).Take(Take));
            searchmodel.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            SetLocationBar(true, " جست وجو", title);
            SetViewbag(searchmodel.SearchVM.Count, page, title, "Search");
            searchmodel.Search = searchmodel.SearchVM.Skip(page * Take).Take(Take);
            return View("SearchItems",searchmodel);

        }
        [HttpPost]
        public async Task<IActionResult> SearchText(string title)
        {
            title = title.RemoveDahst();
            var searchmodel = new SearchAllVM();
            searchmodel.Type = "Search";
            searchmodel.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            searchmodel.Path2 = title;
            searchmodel.SearchVM.AddRange((await _blogService.GetBlogsBySearchVM(title)).Skip(0 * Take).Take(Take)
            );
            searchmodel.SearchVM.AddRange((await _ProductService.GetProductsBySearchVM(title)).Skip(0 * Take).Take(Take));
            SetLocationBar(true, "جست وجو", title);
            SetViewbag(searchmodel.SearchVM.Count, 0, title, "Search");
            return View("SearchItems", searchmodel);

        }

        [Route("/Blog")]
        public async Task<IActionResult> Blogs(int id, string title, int page = 0)
        {
            title = title.RemoveDahst();
            var model = await _blogService.GetBlogs();
            if (model == null)
                return NotFound();
            var searchmodel = new SearchAllVM();
            searchmodel.Type = "Blog";
            searchmodel.Path2 = "مقاله ها";
            searchmodel.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            searchmodel.SearchVM.AddRange((await _blogService.GetBlogsCategoryBySearchVM()).Skip(page * Take).Take(Take));
            SetViewbag(searchmodel.SearchVM.Count, page, id, "Blog");
            SetLocationBar(true, "مقاله  ها", title);

            return View("SearchItems", searchmodel);

        }
        [Route("/Product")]
        public async Task<IActionResult> Products(int id, string title, int page = 0)
        {
            title = title.RemoveDahst();

            var searchmodel = new SearchAllVM();
            searchmodel.Path2 = "محصولات ";
            searchmodel.Type = "Product";
            searchmodel.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            searchmodel.SearchVM.AddRange((await _ProductService.GetProductsCategoryBySearchVM()).Skip(page * Take).Take(Take));
            SetViewbag(searchmodel.SearchVM.Count, page, id, "Product");
            SetLocationBar(true, "محصولا ما  ", title);

            return View("SearchItems", searchmodel);

        }
        public void SetLocationBar(bool loc1,string title1,string title2)
        {
            ViewBag.StatusLocationBarOne = loc1;
            ViewBag.StatusLocationBar = true;
            ViewBag.LocationBarOne = title1;
            ViewBag.Title = title2;
        }
        public void SetViewbag(int count, int page, int id,string type)
        {
            ViewBag.count = (count / 5) + 1;
            ViewBag.page = page;
            ViewBag.Id = id;
            ViewBag.type = type;
        }

        public void SetViewbag(int count, int page, string title, string type)
        {
            ViewBag.Id = 0;
            ViewBag.count = (count / 5) + 1;
            ViewBag.page = page;
            ViewBag.title = title;
            ViewBag.type = type;
        }
    }
}
