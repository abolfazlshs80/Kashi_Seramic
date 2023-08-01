using Kashi_Seramic.Application;
using Kashi_Seramic.Persistences;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pr_Signal_ir.Application;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Contracts.Services;
using Pr_Signal_ir.MVC.Middleware;
using Pr_Signal_ir.MVC.Services;
using Pr_Signal_ir.MVC.Services.Base;
using System.Reflection;
using Kashi_Seramic.Identity;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Persistence.Repositories;
using System.Text.Json.Serialization;
using Kashi_Seramic.MVC.Contracts;
using Microsoft.AspNetCore.ResponseCompression;
using StackExchange.Profiling.Storage;
using WebMarkupMin.AspNetCore6;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApplicationServices();
builder.Services.AddResponseCaching();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
// Add services to the container.

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = new PathString("/users/login");
    options.AccessDeniedPath = new PathString("/users/AccessDenied");
});

builder.Services.AddMiniProfiler(options =>
{

    options.RouteBasePath = "/profiler";
    options.EnableMvcViewProfiling = true;



});

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new
            []
            {
                "application/javascript"
            });
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IFaqUserService, FaqUserService>();
builder.Services.AddScoped<IFilterProductService, FilterProductService>();
builder.Services.AddScoped<IFilterValueProductService, FilterValueProductService>();

builder.Services.AddScoped<IFileToBlogService, FileToBlogService>();
builder.Services.AddScoped<IFileToProductService, FileToProductService>();
builder.Services.AddScoped<IFilterToProductService, FilterToProductService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryToBlogService, CategoryToBlogService>();
builder.Services.AddScoped<ICategoryToProductService, CategoryToProductService>();
builder.Services.AddScoped<IFileImagesService, FileImagesService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<ICommentToBlogService, BlogToCommentService>();
builder.Services.AddScoped<ICommentToProductService, CommentToProductService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetialservice, OrderDetialsService>();
//builder.Services.AddScoped<IOrderSatusService, Orderstat>();

builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketGroupService, TicketGroupService>();
builder.Services.AddScoped<ITicketToReplyService, TicketToReplyService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ITagToBlogService, TagToBlogService>();
builder.Services.AddScoped<ITagToProductService, TagToProductService>();
builder.Services.AddScoped<IUserAddressService, UserAddressService>();
builder.Services.AddScoped<ISiteMap, Kashi_Seramic.MVC.Services.SiteMap>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}); ;
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Limits.MaxRequestBodySize = 9552428800;
});
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = long.MaxValue;
});
builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
builder.Services.AddWebMarkupMin(options =>
    {
        options.AllowMinificationInDevelopmentEnvironment = true;
        options.AllowCompressionInDevelopmentEnvironment = true;
    })
    .AddHtmlMinification()
    .AddHttpCompression()
    .AddXmlMinification();
var app = builder.Build();
app.UseWebMarkupMin();
app.UseMiniProfiler();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseCookiePolicy();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles( new StaticFileOptions
        {
    HttpsCompression = Microsoft.AspNetCore.Http.Features.HttpsCompressionMode.Compress,
            OnPrepareResponse = ctx =>
            {
            
                ctx.Context.Response.Headers.Append("Cache-Control", "public, max-age=3600");
            }
        });
app.UseResponseCompression();
app.UseResponseCaching();
app.UseRouting();
//app.UseMiddleware<RequestMiddleware>();
app.UseAuthorization();

app.MapHub<NotifyHub>("/notifyhub");
app.MapControllerRoute(
    name: "ManageBlog",
    pattern: "{area:exists}/{controller=ManageBlog}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
