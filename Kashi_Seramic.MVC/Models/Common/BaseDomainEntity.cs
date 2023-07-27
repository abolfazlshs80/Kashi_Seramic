namespace Kashi_Seramic.MVC.Models.Common
{
    public class BaseDomainEntity
    {
        public BaseDomainEntity()
        {
                DateCreated= DateTime.Now;
                LastModifiedDate= DateTime.Now;
                Owner = "";
                Status = true;
                CreatedBy = "Admin";
                LastModifiedBy = "ADmin";
        }
        public string? Owner { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
