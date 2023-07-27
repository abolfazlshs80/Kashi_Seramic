using AutoMapper;
using Kashi_Seramic.Application.DTOs.Blog;
using Kashi_Seramic.Application.DTOs.CategoryToProduct;
using Kashi_Seramic.Application.DTOs.CommentToProduct;
using Kashi_Seramic.Application.DTOs.FileManager;
using Kashi_Seramic.Application.DTOs.FileToProduct;
using Kashi_Seramic.Application.DTOs.Menu;
using Kashi_Seramic.Application.DTOs.Order;
using Kashi_Seramic.Application.DTOs.OrderDetials;
using Kashi_Seramic.Application.DTOs.Product;
using Kashi_Seramic.Application.DTOs.SiteSetting;
using Kashi_Seramic.Application.DTOs.Ticket;
using Kashi_Seramic.Application.DTOs.TicketGroup;
using Kashi_Seramic.Application.DTOs.TicketToReply;
using Kashi_Seramic.Application.Models.Identity;
using Kashi_Seramic.Application.Models.Identity.Role;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.Category;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using Pr_Signal_ir.Application.DTOs.FileToBlog;
using Pr_Signal_ir.Application.DTOs.Setting;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.CategoryToBlog;
using Pr_Signal_ir.MVC.Models.CategoryToProduct;

using Pr_Signal_ir.MVC.Models.Employe;
using Pr_Signal_ir.MVC.Models.FileImages;
using Pr_Signal_ir.MVC.Models.FileToBlog;
using Pr_Signal_ir.MVC.Models.FileToProduct;
using Pr_Signal_ir.MVC.Models.OrderDetials;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Order;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Setting;

using Pr_Signal_ir.MVC.Models.Roles;
using Pr_Signal_ir.MVC.Models.Teacher;
using Pr_Signal_ir.MVC.Models.Ticket;
using Pr_Signal_ir.MVC.Models.TicketGroup;
using Pr_Signal_ir.MVC.Models.TicketToReply;
using Pr_Signal_ir.MVC.Models.Users;
using Pr_Signal_ir.MVC.Services.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kashi_Seramic.Application.DTOs.FilterProduct;
using Kashi_Seramic.Application.DTOs.Tag;
using Pr_Signal_ir.MVC.Models.Tag;
using Kashi_Seramic.Application.DTOs.TagToBlog;
using Pr_Signal_ir.MVC.Models.FilterProduct;
using Pr_Signal_ir.MVC.Models.TagToBlog;
using Kashi_Seramic.Application.DTOs.FilterValueProduct;
using Kashi_Seramic.Application.DTOs.TagToProduct;
using Pr_Signal_ir.MVC.Models.FilterToProduct;
using Pr_Signal_ir.MVC.Models.TagToProduct;
using Kashi_Seramic.Application.DTOs.FaqUser;
using Kashi_Seramic.Domain;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.FaqUser;
using Kashi_Seramic.MVC.Models.Slider;
using Kashi_Seramic.Application.DTOs.Slider;
using Kashi_Seramic.Application.DTOs.UserAddress;
using Kashi_Seramic.MVC.Models.Users.UserAddres;

namespace Pr_Signal_ir.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBlogDto, CreateBlogVM>().ReverseMap();
            CreateMap<UpdateBlogDto, UpdateBlogVM>().ReverseMap();
            CreateMap<BlogVM, UpdateBlogVM>().ReverseMap();
            CreateMap<BlogDto, BlogVM>().ReverseMap();

            CreateMap<CommentToBlogDto, CommentToBlogVM>().ReverseMap();
            CreateMap<CommentToProductDto, CommentToProductVM>().ReverseMap();

            CreateMap<FileToBlogVM, FileToBlogDto>().ReverseMap();
            CreateMap<FileManagerDto, FileImagesVM>().ReverseMap();

            CreateMap<CategoryToBlogDto, CategoryToBlogVM>().ReverseMap();
            CreateMap<CategoryDto, CategoryVM>().ReverseMap();
            CreateMap<CreateTagToProductVM, CreateTagToProductDto>().ReverseMap();
            CreateMap<CreateTagDto, CreateTagVM>().ReverseMap();
            CreateMap<UpdateTagVM, TagVM>().ReverseMap();
            CreateMap<UpdateTagVM, UpdateTagDto>().ReverseMap();
       
      
          
            CreateMap<RegistrationRequest, RegisterVM>().ReverseMap();
            CreateMap<CategoryVM, UpdateCategoryVM>().ReverseMap();
            CreateMap<MenuVM, UpdateMenuVM>().ReverseMap();
            CreateMap<CreateMenuVM, CreateMenuDto>().ReverseMap();
            CreateMap<UpdateCategoryDto, UpdateCategoryVM>().ReverseMap();
            CreateMap<UpdateMenuDto, UpdateMenuVM>().ReverseMap();
            CreateMap<CreateCategoryDto, CreateCategoryVM>().ReverseMap();
            //CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();
            CreateMap<EmployeeVM, Employee>().ReverseMap();
            CreateMap<EmployeResponseVM, EmployeResponse>().ReverseMap();
            CreateMap<MenuDto, MenuVM>().ReverseMap();
            CreateMap<SiteSettingDto, SettingVM>().ReverseMap();
            CreateMap<CreateCommentToBlogVM, CreateCommentToBlogDto>().ReverseMap();
            CreateMap<CommentToBlogVM, CommentToBlogDto>().ReverseMap();
            CreateMap<ResetPasswordVM, ResetPasswordDto>().ReverseMap();
            CreateMap<AddRoleToUserVM, AddRoleToUserDto>().ReverseMap();
            CreateMap<AddRoleVM, AddRoleDto>().ReverseMap();
            CreateMap<RoleVM, AddRoleToUserDto>().ReverseMap();
            CreateMap<CreateCategoryToBlogVM, CreateCategoryToBlogDto>().ReverseMap();
            CreateMap<CreateFileImagesVM, CreateFileManagerDto>().ReverseMap();
            CreateMap<CreateFileToBlogVM, CreateFileToBlogDto>().ReverseMap();
            
            CreateMap<RoleVM, RolesDto>().ReverseMap();
            #region Product Mappings
            CreateMap<ProductVM, ProductDto>().ReverseMap();
            CreateMap<ProductDto, UpdateProductDto>().ReverseMap();
            CreateMap<ProductVM, UpdateProductVM>().ReverseMap();
            CreateMap<ProductVM, CreateProductDto>().ReverseMap();
            CreateMap<ProductVM, UpdateProductDto>().ReverseMap();
            CreateMap<UpdateProductVM, UpdateProductDto>().ReverseMap();
            CreateMap<CreateProductDto, CreateProductVM>().ReverseMap();

            CreateMap<CreateCategoryToProductVM, CreateCategoryToProductDto>().ReverseMap();
            CreateMap<CategoryToProductVM, CategoryToProductDto>().ReverseMap();

            CreateMap<CommentToProductDto, CommentToProductVM>().ReverseMap();


            CreateMap<FileToProductDto, FileToProductVM>().ReverseMap();
            CreateMap<CreateFileToProductDto, CreateFileToProductVM>().ReverseMap();
            #endregion

            #region FilterToProductDto Mappings
            CreateMap<FilterToProductDto, FilterToProductVM>().ReverseMap();
            CreateMap<CreateFilterToProductDto, CreateFilterToProductVM>().ReverseMap();
            #endregion


            #region SiteSettingDto Mappings  
            CreateMap<SiteSettingDto, SettingVM>().ReverseMap();
            CreateMap<SiteSettingDto, SettingVM>().ReverseMap();
            CreateMap<UpdateSettingVM, SettingVM>().ReverseMap();
            CreateMap<UpdateSettingVM, UpdateSiteSettingDto>().ReverseMap();
            #endregion


            #region UserAddress Mappings  
            CreateMap<UserAddressDto, UserAddressVM>().ReverseMap();
            CreateMap<UserAddressDto, UserAddressVM>().ReverseMap();
            CreateMap<UpdateUserAddressVM, UserAddressVM>().ReverseMap();
            CreateMap<UpdateUserAddressVM, UpdateUserAddressDto>().ReverseMap();
            CreateMap<CreateUserAddressVM, CreateUserAddressDto>().ReverseMap();
            #endregion





            #region OrdersDto Mappings
            CreateMap<OrdersDto, OrderVM>().ReverseMap();
            CreateMap<OrdersDto, UpdateOrdersDto>().ReverseMap();
            CreateMap<CreateOrdersDto, CreateOrderVM>().ReverseMap();
            CreateMap<CreateOrderDetialsDto, CreateOrderDetialsVM>().ReverseMap();
            CreateMap<CreateOrderDetialsVM, OrderDetialsVM>().ReverseMap();
            CreateMap<UpdateOrderDetialsVM, OrderDetialsVM>().ReverseMap();
            CreateMap<UpdateOrderDetialsVM, UpdateOrderDetialsDto>().ReverseMap();
            CreateMap<OrderVM, UpdateOrderVM>().ReverseMap();
            CreateMap<UpdateOrderVM, UpdateOrdersDto>().ReverseMap();
            CreateMap<CreateOrderVM, OrderVM>().ReverseMap();
            CreateMap<OrderDetialsDto, OrderDetialsVM>().ReverseMap();
            #endregion


            #region CommentToBlogVM Mappings 
            CreateMap<CommentToBlogVM, UpdateCommentToBlogVM>().ReverseMap();
            CreateMap<CommentToProductVM, UpdateCommentToProductVM>().ReverseMap();
            CreateMap<UpdateCommentToBlogDto, UpdateCommentToBlogVM>().ReverseMap();

            CreateMap<CommentToProductVM, UpdateCommentToProductVM>().ReverseMap();
            CreateMap<CreateCommentToProductDto, CreateCommentToProductVM>().ReverseMap();
            CreateMap<UpdateCommentToProductDto, UpdateCommentToProductVM>().ReverseMap();
            #endregion
        







            #region Ticket Mappings
            CreateMap<TicketVM, UpdateTicketVM>().ReverseMap();
            CreateMap<CreateTicketDto, CreateTicketVM>().ReverseMap();
            CreateMap<TicketVM, TicketDto>().ReverseMap();
            CreateMap<TicketVM, CreateTicketDto>().ReverseMap();
            CreateMap<TicketVM, UpdateTicketDto>().ReverseMap();
            CreateMap<UpdateTicketVM, UpdateTicketDto>().ReverseMap();
            CreateMap<TicketDto, UpdateTicketDto>().ReverseMap();
            CreateMap<TicketDto, CreateTicketDto>().ReverseMap();
            #endregion Ticket


            #region TicketGroup Mappings
            CreateMap<TicketGroupVM, TicketGroupDto>().ReverseMap();
            CreateMap<TicketGroupVM, CreateTicketGroupDto>().ReverseMap();
            CreateMap<CreateTicketGroupVM, CreateTicketGroupDto>().ReverseMap();
            CreateMap<TicketGroupVM, UpdateTicketGroupDto>().ReverseMap();
            CreateMap<CreateTicketGroupVM, UpdateTicketGroupVM>().ReverseMap();
            CreateMap<TicketGroupVM, UpdateTicketGroupVM>().ReverseMap();
            CreateMap<UpdateTicketGroupDto, UpdateTicketGroupVM>().ReverseMap();
            CreateMap<TicketGroupDto, UpdateTicketGroupDto>().ReverseMap();
            CreateMap<TicketGroupDto, CreateTicketGroupDto>().ReverseMap();
            #endregion TicketGroup

            #region TicketToReply Mappings
            CreateMap<TicketToReplyVM, TicketToReplyDto>().ReverseMap();
            CreateMap<TicketToReplyVM, TicketToReplyDto>().ReverseMap();
            CreateMap<TicketToReplyVM, TicketToReplyDto>().ReverseMap();
            CreateMap<TicketToReplyDto, UpdateTicketToReplyDto>().ReverseMap();
            CreateMap<TicketToReplyDto, CreateTicketToReplyDto>().ReverseMap();
            CreateMap<CreateTicketToReplyVM, CreateTicketToReplyDto>().ReverseMap();
            #endregion TicketToReply


            #region TicketToReply Mappings
            CreateMap<TagVM, TagDto>().ReverseMap();
            CreateMap<CreateTagToBlogDto, CreateTagToBlogVM>().ReverseMap();

            #endregion TicketToReply

            #region FilterProduct Mappings
            CreateMap<FilterProductVM, FilterProductDto>().ReverseMap();
            CreateMap<CreateFilterProductVM, CreateFilterProductDto>().ReverseMap();
            CreateMap<UpdateProductVM, UpdateFilterProductDto>().ReverseMap();
            CreateMap<FilterProductVM, UpdateFilterProductVM>().ReverseMap();
            #endregion

            #region FilterProductValue Mappings
            CreateMap<FilterValueProductVM, FilterValueProductDto>().ReverseMap();
            CreateMap<CreateFilterValueProductVM, CreateFilterValueProductDto>().ReverseMap();
            CreateMap<UpdateFilterValueProductVM, UpdateFilterValueProductDto>().ReverseMap();
            CreateMap<FilterValueProductVM, UpdateFilterValueProductVM>().ReverseMap();
            #endregion


            #region Product Mappings
            CreateMap<ProductVM, ProductDto>().ReverseMap();
            CreateMap<CreateProductVM, CreateProductDto>().ReverseMap();
            CreateMap<UpdateProductVM, UpdateProductDto>().ReverseMap();
            CreateMap<ProductVM, UpdateProductVM>().ReverseMap();
            #endregion

            #region Slider Mappings
            CreateMap<SliderVM, SliderDto>().ReverseMap();
            CreateMap<CreateSliderVM, CreateSliderDto>().ReverseMap();
            CreateMap<UpdateSliderVM, UpdateSliderDto>().ReverseMap();
            CreateMap<SliderVM, UpdateSliderVM>().ReverseMap();
            #endregion

            #region FaqUserDto Mappings
            CreateMap<FaqUserVM, FaqUserDto>().ReverseMap();
            CreateMap<FaqUserVM, FaqUserDto>().ReverseMap();
            CreateMap<FaqUserVM, FaqUserDto>().ReverseMap();
            CreateMap<FaqUserDto, UpdateFaqUserDto>().ReverseMap();
            CreateMap<FaqUserDto, CreateFaqUserDto>().ReverseMap();
            #endregion

            #region Tag Mappings
            CreateMap<TagToProductVM, TagToProductDto>().ReverseMap();
            CreateMap<TagToBlogVM, TagToBlogDto>().ReverseMap();
            CreateMap<TagVM, TagDto>().ReverseMap();
            #endregion 

        }
    }

}
