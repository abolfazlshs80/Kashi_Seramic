

namespace Kashi_Seramic.MVC.Models.Slider
{
    public class SliderVM:BaseDomainEntity
        
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PathImage { get; set; }
        public int Order { get; set; }
    }

    public class CreateSliderVM : BaseDomainEntity
    {

        public string Title { get; set; }
        public string Text { get; set; }
        public string PathImage { get; set; }
        public int Order { get; set; }
        public IFormFile FileHeader { get; set; } 
    }
    public class UpdateSliderVM:BaseDomainEntity
    {
        public IFormFile FileHeader { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string PathImage { get; set; }
        public int Order { get; set; }
    }

    public class AdminSliderVM : BaseDomainEntity
    {
    }
    
}
