namespace Pr_Signal_ir.MVC.Models
{
    using global::Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Setting;
    using global::Pr_Signal_ir.MVC.Models.Roles;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Pr_Signal_ir.MVC.Models.Menu
    {
        public class MenuVM: BaseDomainEntity
        {

            [Display(Name = "نمایش در منو اصلی")]
            public bool StatusInMainMenu { get; set; }
            [Display(Name = "نمایش در منو کاربر")]
            public bool StatusInUserMenu { get; set; }
            [Display(Name = "نمایش در منو ادمین")]
            public bool StatusInAdminMenu { get; set; }
            public string RoleName { get; set; }
            public string Icons { get; set; }
            public string Title { get; set; }
            public string Href { get; set; }
            public int Order { get; set; }
            public string ControllerName { get; set; }

        }
        public class MenuListVM: BaseDomainEntity
        {
            [Display(Name = "نمایش در منو اصلی")]
            public bool StatusInMainMenu { get; set; }
            [Display(Name = "نمایش در منو کاربر")]
            public bool StatusInUserMenu { get; set; }
            [Display(Name = "نمایش در منو ادمین")]
            public bool StatusInAdminMenu { get; set; }
            public string RoleName { get; set; }
            public string Icons { get; set; }
            public string Title { get; set; }
            public string Href { get; set; }
            public int Order { get; set; }
            public string ControllerName { get; set; }
            public List<MenuVM> Menu { get; set; }
            public SettingVM     Setting { get; set; }
            


      

        }
        public class CreateMenuVM: BaseDomainEntity
        {
            [Display(Name = "نمایش در منو اصلی")]
            public bool StatusInMainMenu { get; set; }
            [Display(Name = "نمایش در منو کاربر")]
            public bool StatusInUserMenu { get; set; }
            [Display(Name = "نمایش در منو ادمین")]
            public bool StatusInAdminMenu { get; set; }
            [Display(Name ="نام مقام")]
            [Required(ErrorMessage = "1فیلد مورد نطر راوارد کنید")]
            public string RoleName { get; set; }
            [Required(ErrorMessage = "1فیلد مورد نطر راوارد کنید")]
            [Display(Name = "نام کلاس ایکون")]
            public string Icons { get; set; }
            [Required(ErrorMessage = "1فیلد مورد نطر راوارد کنید")]
            [Display(Name = "عنوان منو")]
            public string Title { get; set; }
            [Required(ErrorMessage = "1فیلد مورد نطر راوارد کنید")]
            [MinLength(15,ErrorMessage = "باید{0} حداقل {1} حرف باشد")]
            [Display(Name = "لینک")]
            
            public string Href { get; set; }
            public int Order { get; set; }
            public string ControllerName { get; set; }
            public IEnumerable<RoleVM> Roles { get; set; }
            public IEnumerable<SelectListItem> RolesDropDown { get; set; }


        }
        public class UpdateMenuVM: BaseDomainEntity
        {
            public IEnumerable<RoleVM> Roles { get; set; }
            public IEnumerable<SelectListItem> RolesDropDown { get; set; }
            [Display(Name = "نمایش در منو اصلی")]
            public bool StatusInMainMenu { get; set; }
            [Display(Name = "نمایش در منو کاربر")]
            public bool StatusInUserMenu { get; set; }
            [Display(Name = "نمایش در منو ادمین")]
            public bool StatusInAdminMenu { get; set; }
            public string RoleName { get; set; }
            public string Icons { get; set; }
            public string Title { get; set; }
            public string Href { get; set; }
            public int Order { get; set; }
            public string ControllerName { get; set; }
        }

        public class AdminMenuVMViewVM:BaseDomainEntity
        {

            [Display(Name = "نمایش در منو اصلی")]
            public bool StatusInMainMenu { get; set; }
            [Display(Name = "نمایش در منو کاربر")]
            public bool StatusInUserMenu { get; set; }
            [Display(Name = "نمایش در منو ادمین")]
            public bool StatusInAdminMenu { get; set; }
            public string RoleName { get; set; }
            public string Icons { get; set; }
            public string Title { get; set; }
            public string Href { get; set; }
            public int Order { get; set; }
            public string ControllerName { get; set; }
        }


    }

}
