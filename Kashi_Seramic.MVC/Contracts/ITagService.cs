using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Search;
using Pr_Signal_ir.MVC.Models.Tag;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ITagService
    {
        Task<List<TagVM>> GetTags();
        Task<List<TagVM>> GetTagsActive();
        Task<List<TagVM>> GetTagsFindByText(string text);
        Task<TagVM> GetTagsDetails(int id);
        Task<Response<int>> CreateTag(CreateTagVM leaveType);
        Task<Response<int>> UpdateTag(int id,UpdateTagVM leaveType);
        Task<Response<int>> DeleteTag(int id);
        Task<IEnumerable<SearchVM>> GetTagBySearchVM(int id);
        Task<IEnumerable<SearchVM>> GetTagByTextSearchVM(string text);

    }
}
