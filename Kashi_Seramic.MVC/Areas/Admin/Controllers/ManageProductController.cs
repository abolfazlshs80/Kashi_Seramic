using Pr_Signal_ir.Application.Extentions;
using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.FilterToProduct;
using Pr_Signal_ir.MVC.Models.TagToProduct;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    // [Authorize(Roles = "Administrator,Teacher")]
    public class ManageProductController : Controller
    {
        private readonly IProductService _ProductService;
        private readonly IFilterValueProductService _filterValueProductService;
        private readonly IFilterToProductService _filterToProductService;
        private readonly IFilterProductService _filterProductService;
        private readonly ITagService _tagService;
        private readonly ITagToProductService _tagToProductService;
        private readonly IUserService _userService;
        private readonly ICategoryToProductService _Productcate;
        private readonly IFileImagesService _file;
        private readonly IFileToProductService _Productfile;
        private readonly ICategoryService _category;
        private readonly IFileService _fileuploader;

        private readonly IMapper _mapper;
        public ManageProductController(
            IProductService ProductService,

            ICategoryToProductService Productcate,
            IFileImagesService file,
            IFileToProductService Productfile,
            IMapper mapper,
            ICategoryService category, IFileService fileuploader, ITagService tagService, ITagToProductService tagToProductService
            , IFilterValueProductService filterValueProductService, IFilterProductService filterProductService, IFilterToProductService filterToProductService)
        {
            _tagToProductService = tagToProductService;
            _Productcate = Productcate;
            _Productfile = Productfile;
            _category = category;
            _file = file;
            _mapper = mapper;
            _ProductService = ProductService;
            _fileuploader = fileuploader;
            _tagService = tagService;
            _filterProductService = filterProductService;
            _filterValueProductService = filterValueProductService;
            _filterToProductService = filterToProductService;
        }
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Teacher"))
            {
                string userId = User.FindFirst("uid")?.ToString().Replace("uid: ", "");
                //var user = await _userService.GetEmployee(userId);
                var model = await _ProductService.GetProductsByUserId(userId);
                return View(model);
            }
            else
            {
                var model = await _ProductService.GetProducts();
                return View(model);
            }

        }
        #region Create Product
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateProductVM();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM model)
        {
            if (ModelState.ErrorCount <= 3)
            {
                model.Owner = User.GetUserId();
              
                var resProduct = await _ProductService.CreateProduct(model);
                var ProductId = resProduct.Data;
                if (resProduct.Success)
                {
                    foreach (var item in model.CategoryId)
                    {
                        await _Productcate.CreateCategoryToProduct(
                            new Pr_Signal_ir.MVC.Models.CategoryToProduct.CreateCategoryToProductVM
                            {
                                ProductId = ProductId,
                                CategoryId = item
                            });


                    }
                 

                    foreach (var item in model.TagId ?? Enumerable.Empty<int>())
                    {
                        var resTag = await _tagToProductService.CreateTagToProduct(new CreateTagToProductVM()
                        { ProductId = ProductId, TagId = item });
                    }


                        foreach (var item in model.FilterId ?? Enumerable.Empty<int>())
                        {
                            var resTag = await _filterToProductService.CreateFilterToProduct(new CreateFilterToProductVM()
                                { ProductId = ProductId, FilterId = item });
                        }

                        var filename = model.TitleInBrowser.Replace(" ", "-");
                        var rnd = new Random().Next(1000, 99999).ToString();
                        var Name = await _fileuploader.CreateFile(model.FileHeader, "Product", rnd, filename, "-Slider");
                        var resProductSlider = await _file.CreateFileImages(new Pr_Signal_ir.MVC.Models.FileImages.CreateFileImagesVM
                        {
                            Owner = model.Owner,
                            DateCreated = DateTime.Now,

                            IsUploaderFile = false,
                            Title = model.TitleInBrowser,
                            Path = Name,
                            Type = "Product"
                        });

                        var filetoProduct = await _Productfile.CreateFileToProduct(new Pr_Signal_ir.MVC.Models.FileToProduct.CreateFileToProductVM
                        {
                            ProductId = ProductId,
                            ImageId = resProductSlider.Data
                        });
                        if (filetoProduct.Success)
                        {
                            var NameBG = await _fileuploader.CreateFile(model.FileForDetials, "Product", rnd, filename, "-BG");
                            return RedirectToAction("Index");

                        }

                    

                }
            }


            return View(model);
        }

        #endregion
        #region Edit Product
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = User.GetUserId(); /*User.FindFirst("uid")?.ToString().Replace("uid: ", "");*/
            //var user = await _userService.GetEmployee(userId);

            var model = await _ProductService.GetProductsDetails(id);
            if (model == null)
                return NotFound();
            if (User.IsInRole("Teacher"))
            {
                if ((await _ProductService.UserIsOwner(userId, id)).Success)
                    return View(_mapper.Map<UpdateProductVM>(model));
                else
                    return RedirectToAction("Index");
            }
            else
            {
                var newmodel = _mapper.Map<UpdateProductVM>(model);
                return View(newmodel);
            }
             

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductVM model)
        {




                try
                {
                    var Product = await _ProductService.GetProductsDetails(model.Id);
                    model.Owner = User.GetUserId();
                    var resProduct = await _ProductService.UpdateProduct(model.Id, model);
                    if (resProduct.Success)
                    {
                    

                        if (model.CategoryId != null) 
                        {
                            await _Productcate.DeleteAnyCategoryToProduct(model.Id);
                            foreach (var item in model.CategoryId)
                            {
                                await _Productcate.CreateCategoryToProduct(
                                    new Pr_Signal_ir.MVC.Models.CategoryToProduct.CreateCategoryToProductVM
                                    {
                                        ProductId = Product.Id,
                                        CategoryId = item
                                    });


                            }
                        }
                        if (model.FilterId != null)
                        {
                            await _filterToProductService.DeleteAnyFilterToProduct(model.Id);
                            foreach (var item in model.FilterId ?? Enumerable.Empty<int>())
                            {
                                var resTag = await _filterToProductService.CreateFilterToProduct(new CreateFilterToProductVM()
                                    { ProductId = model.Id, FilterId = item });
                            }

                        }
                        if (model.TagId != null)
                        {
                            await _tagToProductService.DeleteAnyTagToProduct(model.Id);
                            foreach (var item in model.TagId ?? Enumerable.Empty<int>())
                            {
                                var resTag = await _tagToProductService.CreateTagToProduct(new CreateTagToProductVM()
                                    { ProductId = model.Id, TagId = item });
                            }
                        }
                       
              

                         

                     
                            if (model.FileHeader != null && model.FileForDetials != null)
                            {
                                var path = Product.FileToProduct.FirstOrDefault()?.FileManager.Path;
                                var path2 = path.Replace("-Slider", "-BG");
                                await _fileuploader.DeleteFile("Product", path, "Product");
                                await _fileuploader.DeleteFile("Product", path2, "Product");
                                await _Productfile.DeleteFileToProduct(model.Id);
                                #region Create FIle
                                var filename = model.TitleInBrowser.Replace(" ", "-");
                                var rnd = new Random().Next(1000, 99999).ToString();
                                var Name = await _fileuploader.CreateFile(model.FileHeader, "Product", rnd, filename, "-Slider");
                                var resProductSlider = await _file.CreateFileImages(new Pr_Signal_ir.MVC.Models.FileImages.CreateFileImagesVM
                                {
                                    CreatedBy = "abolfazl",
                                    DateCreated = DateTime.Now,
                                    IsUploaderFile = false,
                                    Title = model.Title,
                                    Path = Name,
                                    Type = "Product"
                                });

                                var filetoProduct = await _Productfile.CreateFileToProduct(new Pr_Signal_ir.MVC.Models.FileToProduct.CreateFileToProductVM
                                {
                                    ProductId =model.Id,
                                    ImageId =resProductSlider.Data
                                });
                                if (filetoProduct.Success)
                                {
                                    var NameBG = await _fileuploader.CreateFile(model.FileForDetials, "Product", rnd, filename, "-BG");
                                    return RedirectToAction("Index");

                                }
                                #endregion
                            }


                        
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");

                }

            


            return View(model);
        }

        #endregion

        #region Delete Product

        [Route("/Admin/ManageProduct/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                //   string userId = User.FindFirst("uid")?.ToString().Replace("uid: ", "");
                //var user = await _userService.GetEmployee(userId);
                var Product = await _ProductService.GetProductsDetails(id);
                if (Product == null)
                    return RedirectToAction("Index");

                if (Product.FileToProduct != null)
                {
                    try
                    {
                        var path = Product.FileToProduct.FirstOrDefault()?.FileManager?.Path;
                        var path2 = path?.Replace("-Slider", "-BG");
                        await _fileuploader.DeleteFile("Product", path, "Product");
                        await _fileuploader.DeleteFile("Product", path2, "Product");
                    }
                    catch (Exception e)
                    {
                     
                    }
          

                    //await _file.DeleteFileImages(Product.FileToProduct.FirstOrDefault().ProductId);
                }
                await _ProductService.DeleteProduct(id);

                return RedirectToAction("Index");
                var model = await _ProductService.GetProductsDetails(id);
                if (model == null)
                    return NotFound();
                if ((await _ProductService.UserIsOwner(User.GetUserId(), id)).Success || User.IsInRole("Administrator"))

                {

            
                }

                else
                    return RedirectToAction("Index");


            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }


        }
        #endregion

        public async Task<IActionResult> Active(int id)
        {
            var model = await _ProductService.GetProductsDetails(id);
            if (model == null)
            {
                return NotFound();
            }

            model.Status = !model.Status;
            await _ProductService.UpdateProduct(model.Id, _mapper.Map<UpdateProductVM>(model));
            return RedirectToAction("Index");
        }
        [HttpGet("/FindTag/{Tagname}")]
        public async Task<IActionResult> FindTag(string Tagname)
        {
            var model = await _tagService.GetTags();
            return View("FindTag", model.Where(a => a.Name.Contains(Tagname)));
        }


        [HttpGet("/ShowFilterValueByCateId/{CateId}")]
        public async Task<IActionResult> ShowFilterValueByCateId(int CateId)
        {
            var model = await _filterProductService.GetFilterProductsByCatId(CateId);
            return View("ShowFilterValueByCateId", model);
        }

    }
}
