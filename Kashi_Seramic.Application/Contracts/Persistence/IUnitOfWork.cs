using Kashi_Seramic.Application.Contracts.Persistence;
using System;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository BlogRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IFilterValueProductRepository FilterValueProductRepository { get; }
        IFilterProductRepository FilterProductRepository { get; }
        IFaqUserRepository FaqUserRepository { get; }
        
        IOrdersRepository OrderRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
  
        ITicketRepository TicketRepository { get; }
        ITicketToReplyRepository TicketToReplyRepository { get; }
        ITicketGroupRepository TicketGroupRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ITagRepository TagRepository { get; }
        ISliderRepository SliderRepository { get; }
        IFileManagerRepository FileManagerRepository { get; }
        IFileToBlogRepository FileToBlogRepository { get; }
      
      
        ICategoryToBlogRepository CategoryToBlogRepository { get; }
        ITagToBlogRepository TagToBlogRepository { get; }
        ICommentToBlogRepository CommentToBlogRepository { get; }
        IMenuRepository MenuRepository { get; }
        ISiteSettingRepository SiteSettingRepository { get; }
        IProductRepository ProductRepository { get; }

        IFileToProductRepository FileToProductRepository { get; }
        IFilterToProductRepository FilterToProductRepository { get; }
        ICategoryToProductRepository CategoryToProductRepository { get; }
        ITagToProductRepository TagToProductRepository { get; }
      
        ICommentToProductRepository CommentToProductRepository { get; }
        IOrderSatusRepository OrderSatusRepository { get; }
        IUserAddressRepository UserAddressRepository { get; }


        Task Save();
    }
}
