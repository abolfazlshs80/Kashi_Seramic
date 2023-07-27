using Kashi_Seramic.Domain;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface ICommentToBlogRepository:IGenericRepository<CommentToBlog>
    {
        Task<CommentToBlog> GetCommentToBlogWithDCommentId(int id);
        Task<List<CommentToBlog>> GetCommentToBlogWithCommentToBlogId(int id);
        Task<List<CommentToBlog>> GetCommentToBlogs();



    }
}
