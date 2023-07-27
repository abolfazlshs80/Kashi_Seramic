using Kashi_Seramic.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Persistence.Repositories;
using Pr_Signal_ir.Persistences.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Persistences
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("MyConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IOrderSatusRepository, OrderStatusRepository>();
            services.AddScoped<IFilterProductRepository, FilterProductRepository>();
            services.AddScoped<IFilterValueProductRepository, FilterValueProductRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IFaqUserRepository, FaqUserRepository>();
       
            services.AddScoped<IOrdersRepository, OrderRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetialsRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICategoryToBlogRepository, CategoryToBlogRepository>();
            services.AddScoped<ITagToBlogRepository, TagToBlogRepository>();
            services.AddScoped<IFileToBlogRepository, FileToBlogRepository>();
   
            services.AddScoped<IFileManagerRepository, FileManagerRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<ISiteSettingRepository, SettingRepository>();
            services.AddScoped<ICommentToBlogRepository, CommentToBlogRepository>();
            services.AddScoped<ICommentToProductRepository, CommentToProductRepository>();
            services.AddScoped<ICategoryToProductRepository, CategoryToProductRepository>();
            services.AddScoped<ITagToProductRepository, TagToProductRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IFileToProductRepository, FileToProductRepository>();
            services.AddScoped<IFilterToProductRepository, FilterToProductRepository>();
 
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketGroupRepository, TicketGroupRepository>();
            services.AddScoped<ITicketToReplyRepository, TicketToReplyRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();



            return services;
        }
    }
}
