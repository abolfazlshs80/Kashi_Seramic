
using AutoMapper;

using Pr_Signal_ir.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Pr_Signal_ir.Persistences.Repositories;
using Pr_Signal_ir.Application.DTOs.FileToBlog;
using Kashi_Seramic.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Constants;

namespace Pr_Signal_ir.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IBlogRepository _BlogRepository;
        private IOrderSatusRepository _OrderSatusRepository;
        private IFilterProductRepository _FilterProductRepository;
        private IFilterValueProductRepository _FilterValueProductRepository;
        private IFaqUserRepository _FaqUserRepository;
        private IInventoryRepository _InventoryRepository;
        private IOrdersRepository _OrderRepository;
        private IOrderDetailsRepository _OrderDetialsRepository;
        private ICategoryRepository _CategoryRepository;
        private ITagRepository _TagRepository;
        private IFileManagerRepository _FileManagerRepository;
        private ICategoryToBlogRepository _CategoryToBlogRepository;
        private ITagToBlogRepository _TagToBlogRepository;
        private IFileToBlogRepository _FileToBlogRepository;
        private ICommentToBlogRepository _CommentToBlogRepository;
        private IMenuRepository _MenuRepository;
        private ISiteSettingRepository _SiteSettingRepository;

        private IProductRepository _ProductRepository;

        private IFileToProductRepository _FileToProductRepository;
        private IFilterToProductRepository _FilterToProductRepository;
     
        private ICategoryToProductRepository _CategoryToProductRepository;
        private ITagToProductRepository _TagToProductRepository;
        private ICommentToProductRepository _CommentToProductRepository;

        private ITicketRepository _TicketRepository;
        private ITicketGroupRepository _TicketGroupRepository;
        private ITicketToReplyRepository _TicketToReplyRepository;
        private ISliderRepository _SliderRepository;
        private IUserAddressRepository _UserAddressRepository;


        public UnitOfWork()
        {
        }

        public UnitOfWork(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public IBlogRepository BlogRepository =>
            _BlogRepository ??= new BlogRepository(_context);
        public ICategoryRepository CategoryRepository =>
            _CategoryRepository ??= new CategoryRepository(_context);

     

        public IFileManagerRepository FileManagerRepository =>
            _FileManagerRepository ??= new FileManagerRepository(_context);
        public IFileToBlogRepository FileToBlogRepository =>
       _FileToBlogRepository ??= new FileToBlogRepository(_context);
        public ICategoryToBlogRepository CategoryToBlogRepository =>
       _CategoryToBlogRepository ??= new CategoryToBlogRepository(_context);
        public ISiteSettingRepository SiteSettingRepository =>
_SiteSettingRepository ??= new SettingRepository(_context);
        public IMenuRepository MenuRepository =>
_MenuRepository ??= new MenuRepository(_context);
        public ICommentToBlogRepository CommentToBlogRepository =>
_CommentToBlogRepository ??= new CommentToBlogRepository(_context);


        public ICommentToProductRepository CommentToProductRepository =>
_CommentToProductRepository ??= new CommentToProductRepository(_context);

        public ICategoryToProductRepository CategoryToProductRepository =>
_CategoryToProductRepository ??= new CategoryToProductRepository(_context);
        public IFileToProductRepository FileToProductRepository => _FileToProductRepository ??= new FileToProductRepository(_context);
        public IFilterToProductRepository FilterToProductRepository => _FilterToProductRepository ??= new FilterToProductRepository(_context);
 
        public IProductRepository ProductRepository =>
            _ProductRepository ??= new ProductRepository(_context);

       

      
        public ITicketToReplyRepository TicketToReplyRepository => _TicketToReplyRepository ??= new TicketToReplyRepository(_context);
        public ITicketGroupRepository TicketGroupRepository => _TicketGroupRepository ??= new TicketGroupRepository(_context);
        public ITicketRepository TicketRepository => _TicketRepository ??= new TicketRepository(_context);

        public ITagRepository TagRepository => _TagRepository ??= new TagRepository(_context);
        public ITagToBlogRepository TagToBlogRepository => _TagToBlogRepository ??= new TagToBlogRepository(_context);
        public ITagToProductRepository TagToProductRepository => _TagToProductRepository ??= new TagToProductRepository(_context);

        public IInventoryRepository InventoryRepository => _InventoryRepository ??= new InventoryRepository(_context);
        public IOrdersRepository OrderRepository => _OrderRepository ??= new OrderRepository(_context);

        public IOrderDetailsRepository OrderDetailsRepository => _OrderDetialsRepository ??= new OrderDetialsRepository(_context);

        public IFilterValueProductRepository FilterValueProductRepository => _FilterValueProductRepository ??= new FilterValueProductRepository(_context);

        public IFilterProductRepository FilterProductRepository => _FilterProductRepository ??= new FilterProductRepository(_context);

        public IFaqUserRepository FaqUserRepository => _FaqUserRepository ??= new FaqUserRepository(_context);



        public IOrderSatusRepository OrderSatusRepository => _OrderSatusRepository ??= new OrderStatusRepository(_context);
        public ISliderRepository SliderRepository => _SliderRepository ??= new SliderRepository(_context);
        public IUserAddressRepository UserAddressRepository => _UserAddressRepository ??= new UserAddressRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}
