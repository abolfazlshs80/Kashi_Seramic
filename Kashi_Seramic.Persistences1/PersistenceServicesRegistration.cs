using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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


            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<IBlogRepository, BlogRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IOrderDetialsRepository, OrderDetialsRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<ITagRepository, TagRepository>();
            //services.AddScoped<ICategoryToBlogRepository, CategoryToBlogRepository>();
            //services.AddScoped<ITagToBlogRepository, TagToBlogRepository>();
            //services.AddScoped<IFileToBlogRepository, FileToBlogRepository>();
            //services.AddScoped<IFileToTeacherRepository, FileToTeacherRepository>();
            //services.AddScoped<IFileImagesRepository,FileImagesRepository>();
            //services.AddScoped<IMenuRepository, MenuRepository>();
            //services.AddScoped<ISettingRepository, SettingRepository>();
            //services.AddScoped<ICommentToBlogRepository, CommentToBlogRepository>();
            //services.AddScoped<ICommentToBlogVideoRepository, CommentToBlogVideoRepository>();
            //services.AddScoped<ICategoryToBlogVideoRepository, CategoryToBlogVideoRepository>();
            //services.AddScoped<ITagToBlogVideoRepository, TagToBlogVideoRepository>();
            //services.AddScoped<IBlogVideoRepository, BlogVideoRepository>();
            //services.AddScoped<IVideoRepository,VideoRepository>();
            //services.AddScoped<IVideoToBlogVideoRepository, VideoToBlogVideoRepository>();
            //services.AddScoped<IFileToBlogVideoRepository, FileToBlogVideoRepository>();
            //services.AddScoped<ITeacherRepository, TeacherRepository>();
            //services.AddScoped<ITicketRepository, TicketRepository>();
            //services.AddScoped<ITicketGroupRepository, TicketGroupRepository>();
            //services.AddScoped<ITicketToReplyRepository, TicketToReplyRepository>();
            //services.AddScoped<IRequestPaymentRepository, RequestPaymentRepository>();


            return services;
        }
    }
}
