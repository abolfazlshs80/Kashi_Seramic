using Kashi_Seramic.MVC.Models.Slider;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;


using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ISliderService
    {
        Task<List<SliderVM>> GetSliders();
        Task<List<SliderVM>> GetSlidersActive();
        Task<SliderVM> GetSlidersDetails(int id);
        Task<Response<int>> CreateSlider(CreateSliderVM leaveType);
        Task<Response<int>> UpdateSlider(int id,UpdateSliderVM leaveType);
        Task<Response<int>> DeleteSlider(int id);
    }
}
