namespace Kashi_Seramic.MVC.Models.Users.UserAddres
{
    public class UserAddressVM:BaseDomainEntity
    {
        public bool ActiveByDefualt { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
        public string Ostan { get; set; }
        public string City { get; set; }
        public string CodePostal { get; set; }
        public string Avenu { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
    }
    public class CreateUserAddressVM : BaseDomainEntity
    {
        public bool ActiveByDefualt { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
        public string Ostan { get; set; }
        public string City { get; set; }
        public string CodePostal { get; set; }
        public string Avenu { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
    }
    public class UpdateUserAddressVM : BaseDomainEntity
    {
        public bool ActiveByDefualt { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
        public string Ostan { get; set; }
        public string City { get; set; }
        public string CodePostal { get; set; }
        public string Avenu { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }

    }
}
