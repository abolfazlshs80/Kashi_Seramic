using Kashi_Seramic.Domain;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface ICommentToProductRepository:IGenericRepository<CommentToProduct>
    {
        Task<CommentToProduct> GetCommentToProductWithDCommentId(int id);
        Task<List<CommentToProduct>> GetCommentToBlogs();
        Task<List<CommentToProduct>> GetCommentToProductWithCommentToProductId(int id);
        

    }
}
