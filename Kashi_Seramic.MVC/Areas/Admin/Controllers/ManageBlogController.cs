using AutoMapper;
using Kashi_Seramic.Application.DTOs.Blog;
using Kashi_Seramic.MVC.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pr_Signal_ir.Application.Extentions;
using Pr_Signal_ir.MVC.Models.TagToBlog;

namespace Kashi_Seramic.MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    // [Authorize(Roles = "Administrator,Teacher")]
    public class ManageBlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ITagService _tagService;
        private readonly ITagToBlogService _tagToBlogService;
        private readonly IUserService _userService;
        private readonly ICategoryToBlogService _blogcate;
        private readonly IFileImagesService _file;
        private readonly IFileToBlogService _blogfile;
        private readonly ICategoryService _category;
        private readonly IFileService _fileuploader;
        private readonly ISiteMap _siteMap;

        private readonly IMapper _mapper;
        public ManageBlogController(
            IBlogService blogService,
            ICategoryToBlogService blogcate,
            IFileImagesService file,
            IFileToBlogService blogfile,
            IMapper mapper,
            ICategoryService category, IFileService fileuploader, ITagService tagService, ITagToBlogService tagToBlogService, ISiteMap siteMap)
        {
            _tagToBlogService = tagToBlogService;
            _blogcate = blogcate;
            _blogfile = blogfile;
            _category = category;
            _file = file;
            _mapper = mapper;
            _blogService = blogService;
            _fileuploader = fileuploader;
            _tagService = tagService;
            _siteMap = siteMap;
        }
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(User.GetUserId()))
            {
                return RedirectToAction("Logout", "Users");
            }
            await _siteMap.CreateSiteMap();
            if (User.IsInRole("Teacher"))
            {
                string userId = User.GetUserId();
                //var user = await _userService.GetEmployee(userId);
                var model = await _blogService.GetBlogsByUserId(userId);
                return View(model);
            }
            else
            {
                var model = await _blogService.GetBlogs();
                return View(model);
            }

          

        }
        #region Create Blog
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateBlogVM();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogVM model)
        {
            if (ModelState.ErrorCount <= 3)
            {
                if (model.CategoryId.Count<1||model.TagId.Count<1)
                {
                    
                }
               
                model.Owner = User.GetUserId();
                model.CreatedBy = User.Identity.Name;
                var resBlog = await _blogService.CreateBlog(model);
                var BlogId = resBlog.Data;
                if (resBlog.Success)
                {
                    foreach (var item in model.CategoryId)
                    {
                await _blogcate.CreateCategoryToBlog(
                            new Pr_Signal_ir.MVC.Models.CategoryToBlog.CreateCategoryToBlogVM
                            {
                                BlogId = BlogId,
                                CategoryId = item
                            });
                    }
            


                    foreach (var item in model.TagId ?? Enumerable.Empty<int>())
                    {
                        var resTag = await _tagToBlogService.CreateTagToBlog(new CreateTagToBlogVM()
                        { BlogId = BlogId, TagId = item });
                    }

                    #region File

                    var filename = model.TitleBrowser.Replace(" ", "-");
                    var rnd = new Random().Next(1000, 99999).ToString();
                    var Name = await _fileuploader.CreateFile(model.FileHeader, "Blog", rnd, filename, "-Slider");
                    var resBlogSlider = await _file.CreateFileImages(new Pr_Signal_ir.MVC.Models.FileImages.CreateFileImagesVM
                    {
                        Owner = model.Owner,
                        DateCreated = DateTime.Now,

                        IsUploaderFile = false,
                        Title = model.TitleBrowser,
                        Path = Name,
                        Type = "Blog"
                    });

                    var filetoblog = await _blogfile.CreateFileToBlog(new Pr_Signal_ir.MVC.Models.FileToBlog.CreateFileToBlogVM
                    {
                        BlogId = BlogId,
                        ImageId = resBlogSlider.Data
                    });
                    if (filetoblog.Success)
                    {
                        var NameBG = await _fileuploader.CreateFile(model.FileForDetials, "Blog", rnd, filename, "-BG");
                        return RedirectToAction("Index");

                    }

                    #endregion




                }
            }


            return View(model);
        }

        #endregion
        #region Edit Blog
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
          //  string userId = User.FindFirst("uid")?.ToString().Replace("uid: ", "");
            //var user = await _userService.GetEmployee(userId);

            var model = await _blogService.GetBlogsDetails(id);
            if (model == null)
                return NotFound();
            //if (User.IsInRole("Teacher"))
            //{
            //    if ((await _blogService.UserInOwner(userId, id)).Success)
            //        return View(_mapper.Map<UpdateBlogVM>(model));
            //    else
            //        return RedirectToAction("Index");
            //}
            //else

            var newmodel = _mapper.Map<UpdateBlogVM>(model);
            newmodel.CategoryId = model.CategoryToBlog.Select(a => a.CategoryId).ToList();
                return View(newmodel);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBlogVM model)
        {
          


                try
                {
                    var Blog = await _blogService.GetBlogsDetails(model.Id);
                    model.LastModifiedBy = User.GetNameUser();
                    var resBlog = await _blogService.UpdateBlog(model.Id, model);
                    if (resBlog.Success)
                    {
                        if (model.CategoryId!=null)
                        {
                            await _blogcate.DeleteCategoryToAnyBlog(model.Id);
                            foreach (var item in model.CategoryId)
                            {
                                await _blogcate.CreateCategoryToBlog(
                                    new Pr_Signal_ir.MVC.Models.CategoryToBlog.CreateCategoryToBlogVM
                                    {
                                        BlogId = model.Id,
                                        CategoryId = item
                                    });
                            }
                        }

                        if (model.TagId!=null)
                        {   await _tagToBlogService.DeleteAnyTagToBlog(Blog.Id);
                            foreach (var item in model.TagId ?? Enumerable.Empty<int>())
                            {
                                
                                var resTag = await _tagToBlogService.CreateTagToBlog(new CreateTagToBlogVM()
                                    { BlogId = Blog.Id, TagId = item });
                            }

                        }


                        if (model.FileHeader != null && model.FileForDetials != null)
                            {
                                var path = Blog.FileToBlog.FirstOrDefault()?.FileManager.Path;
                                var path2 = path.Replace("-Slider", "-BG");
                                await _fileuploader.DeleteFile("Blog", path, "Blog");
                                await _fileuploader.DeleteFile("Blog", path2, "Blog");
                                await _blogfile.DeleteFileToBlog(model.Id);
                                #region Create FIle
                                var filename = model.TitleBrowser.Replace(" ", "-");
                                var rnd = new Random().Next(1000, 99999).ToString();
                                var Name = await _fileuploader.CreateFile(model.FileHeader, "Blog", rnd, filename, "-Slider");
                                var resBlogSlider = await _file.CreateFileImages(new Pr_Signal_ir.MVC.Models.FileImages.CreateFileImagesVM
                                {
                                    CreatedBy = "abolfazl",
                                    DateCreated = DateTime.Now,
                                    IsUploaderFile = false,
                                    Title = model.TitleBrowser,
                                    Path = Name,
                                    Type = "Blog"
                                });

                                var filetoblog = await _blogfile.CreateFileToBlog(new Pr_Signal_ir.MVC.Models.FileToBlog.CreateFileToBlogVM
                                {
                                    BlogId =model.Id,
                                    ImageId =resBlogSlider.Data
                                });
                                if (filetoblog.Success)
                                {
                                    var NameBG = await _fileuploader.CreateFile(model.FileForDetials, "Blog", rnd, filename, "-BG");
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

        #region Delete Blog

        [Route("/Admin/ManageBlog/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                //   string userId = User.FindFirst("uid")?.ToString().Replace("uid: ", "");
                //var user = await _userService.GetEmployee(userId);
                var blog = await _blogService.GetBlogsDetails(id);
                if (blog == null)
                    return RedirectToAction("Index");

                if (blog.FileToBlog != null)
                {
                    try
                    {
                        var path = blog.FileToBlog.FirstOrDefault()?.FileManager?.Path;
                        var path2 = path?.Replace("-Slider", "-BG");
                        await _fileuploader.DeleteFile("Blog", path, "Blog");
                        await _fileuploader.DeleteFile("Blog", path2, "Blog");
                    }
                    catch (Exception e)
                    {
                     
                    }
          

                    //await _file.DeleteFileImages(blog.FileToBlog.FirstOrDefault().BlogId);
                }
                await _blogService.DeleteBlog(id);

                return RedirectToAction("Index");
                var model = await _blogService.GetBlogsDetails(id);
                if (model == null)
                    return NotFound();
                if ((await _blogService.UserInOwner(User.GetUserId(), id)).Success || User.IsInRole("Administrator"))

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

      
        public  async Task< IActionResult> Active(int id)
        {
            var model =await _blogService.GetBlogsDetails(id);
            if (model==null)
            {
                return NotFound();
            }

            model.Status = !model.Status;
           await _blogService.UpdateBlog(model.Id,_mapper.Map<UpdateBlogVM>(model));
            return RedirectToAction("Index");
        }
        [HttpGet("/FindTag/{Tagname}")]
        public async Task<IActionResult> FindTag(string Tagname)
        {
            var model = await _tagService.GetTags();
            return View("FindTag", model.Where(a => a.Name.Contains(Tagname)));
        }

    }
}
