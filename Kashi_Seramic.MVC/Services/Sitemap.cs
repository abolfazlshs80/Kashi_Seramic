using Kashi_Seramic.Application.Contracts.SiteMap;
using Kashi_Seramic.MVC.Contracts;

namespace Kashi_Seramic.MVC.Services
{
    public class SiteMap: ISiteMap
    {
        IBlogService repblog;
        IProductService repproduct;
        ICategoryService repcat;
        ITagService repTag;
        IMenuService repmenu;
        ISettingService repsSettingService;
        public SiteMap(IBlogService _blogService,IProductService productService, ICategoryService _repcat, ITagService _repTag, IMenuService _repmenu, ISettingService _repsSettingService)
        {
            repblog=_blogService;
            repproduct = productService;
            repTag = _repTag;
            repcat = _repcat;
            repmenu = _repmenu;
            repsSettingService = _repsSettingService;

        }

        public async Task< bool> CreateSiteMap()
        {
            Sitemap sitemap = new Sitemap();
            var setting = (await repsSettingService.GetSettings()).FirstOrDefault();
            string PathBase = setting.SitePath;
            sitemap.Add(new SitemapLocation
            {
                ChangeFrequency = SitemapLocation.eChangeFrequency.monthly,
                Url = PathBase,
                Priority = 1,
                LastModified = DateTime.Now,
                Images = null //optional
            });

            sitemap.Add(new SitemapLocation
            {
                ChangeFrequency = SitemapLocation.eChangeFrequency.monthly,
                Url = $"{PathBase}/Blog",
                Priority = 0.9,
                Images = null //optional
            });
         
            sitemap.Add(new SitemapLocation
            {
                ChangeFrequency = SitemapLocation.eChangeFrequency.monthly,
                Priority = 0.9,
                Url =$"{PathBase}Product",
                Images = null //optional
            });
    
            sitemap.Add(new SitemapLocation
            {
                ChangeFrequency = SitemapLocation.eChangeFrequency.monthly,
                Priority = 0.9,
                Url =$"{PathBase}AboutUs",
                Images = null //optional
            });
            sitemap.Add(new SitemapLocation
            {
                ChangeFrequency = SitemapLocation.eChangeFrequency.monthly,
                Priority = 0.9,
                Url = $"{PathBase}Faq",
                Images = null //optional
            });
            sitemap.Add(new SitemapLocation
            {
                ChangeFrequency = SitemapLocation.eChangeFrequency.monthly,
                Priority = 0.9,
                Url = $"{PathBase}ContactUs",
                Images = null //optional
            });
            sitemap.Add(new SitemapLocation
            {
                ChangeFrequency = SitemapLocation.eChangeFrequency.monthly,
                Priority = 0.9,
                Url =$"{PathBase}users/login",
                Images = null //optional
            });
            sitemap.Add(new SitemapLocation
            {
                ChangeFrequency = SitemapLocation.eChangeFrequency.monthly,
                Priority = 0.9,
                Url =$"{PathBase}users/Register",
                Images = null //optional
            });
            foreach (var item in await repblog.GetBlogs())
            {
                if (item.Status)
                {
                    sitemap.Add(new SitemapLocation
                    {
                        ChangeFrequency = SitemapLocation.eChangeFrequency.weekly,
                        Priority = 0.8,
                        Url =
                            $"https://www.omolbininsafaribeauty.com/Blog/{item.Id}/{item.ShortTitle.SetForUrl()}",
                        Images = null //optional
                    });
                }
           

            }

            foreach (var item in await repproduct.GetProducts())
            {
                if (item.Status)
                {
                    sitemap.Add(new SitemapLocation
                    {
                        ChangeFrequency = SitemapLocation.eChangeFrequency.weekly,
                        Priority = 0.8,
                        Url =
                            $"https://www.omolbininsafaribeauty.com/Blog/{item.Id}/{item.Title.SetForUrl()}",
                        Images = null //optional
                    });
                }
           

            }

            foreach (var item in await repcat.GetCategorys())
            {
                if (item.Status)
                {
                    sitemap.Add(new SitemapLocation
                    {
                        ChangeFrequency = SitemapLocation.eChangeFrequency.weekly,
                        Priority = 0.8,
                        Url =
                            $"https://www.omolbininsafaribeauty.com/Category/{item.Id}/{item.Name.SetForUrl()}",
                        Images = null //optional
                    });
                }
            

            }
            foreach (var item in await repTag.GetTags())
            {
                if (item.Status)
                {
                    sitemap.Add(new SitemapLocation
                    {
                        ChangeFrequency = SitemapLocation.eChangeFrequency.weekly,
                        Priority = 0.8,
                        Url =
                            $"https://www.omolbininsafaribeauty.com/Category/{item.Id}/{item.Name.SetForUrl()}",
                        Images = null //optional
                    });
                }


            }
            foreach (var item in await repmenu.GetMenus())
            {
                if (item.Status&&item.StatusInMainMenu)
                {
                    sitemap.Add(new SitemapLocation
                    {
                        ChangeFrequency = SitemapLocation.eChangeFrequency.weekly,
                        Priority = 0.8,
                        Url =
                            $"https://www.omolbininsafaribeauty.com/Category/{item.Id}/{item.Title.SetForUrl()}",
                        Images = null //optional
                    });
                }


            }
            sitemap.WriteSitemapToFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "sitemap.xml"));
            return true;
        }

    }
}

