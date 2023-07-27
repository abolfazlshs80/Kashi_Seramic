using AutoMapper;

using Kashi_Seramic.Application.DTOs.Blog;
using Kashi_Seramic.Application.DTOs.CategoryToProduct;
using Kashi_Seramic.Application.DTOs.CommentToProduct;
using Kashi_Seramic.Application.DTOs.FaqUser;
using Kashi_Seramic.Application.DTOs.FileManager;
using Kashi_Seramic.Application.DTOs.FileToProduct;
using Kashi_Seramic.Application.DTOs.FilterProduct;
using Kashi_Seramic.Application.DTOs.FilterValueProduct;
using Kashi_Seramic.Application.DTOs.Inventory;
using Kashi_Seramic.Application.DTOs.Menu;
using Kashi_Seramic.Application.DTOs.Order;
using Kashi_Seramic.Application.DTOs.OrderDetials;
using Kashi_Seramic.Application.DTOs.Product;

using Kashi_Seramic.Application.DTOs.SiteSetting;
using Kashi_Seramic.Application.DTOs.Slider;
using Kashi_Seramic.Application.DTOs.Tag;
using Kashi_Seramic.Application.DTOs.TagToBlog;
using Kashi_Seramic.Application.DTOs.TagToProduct;
using Kashi_Seramic.Application.DTOs.Ticket;
using Kashi_Seramic.Application.DTOs.TicketGroup;
using Kashi_Seramic.Application.DTOs.TicketToReply;
using Kashi_Seramic.Application.DTOs.UserAddress;
using Kashi_Seramic.Domain;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.Category;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using Pr_Signal_ir.Application.DTOs.FileToBlog;

using Pr_Signal_ir.Application.DTOs.Setting;


using System;
using System.Collections.Generic;
using System.Text;

namespace Pr_Signal_ir.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product Mappings
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            
            #endregion
            #region Blog Mappings
            /*reateMap<Blog, BlogDto>().ReverseMap();*/
            CreateMap<Blog, BlogDto>()
                
                //.IncludeMembers(a=>a.FileToBlog,b=>b.FileToBlog)
                //.IncludeBase<FileManager,FileManagerDto>()
                //.ForMember(dest => dest.FileToBlog, opt => opt.MapFrom(src => src.FileToBlog))
                
                .ReverseMap();
            CreateMap<Blog, CreateBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();
            CreateMap<CategoryToBlog, CategoryToBlogDto>().ReverseMap();

            #endregion Blog
            #region Inventory Mappings
            /*reateMap<Blog, BlogDto>().ReverseMap();*/
            CreateMap<Inventory, InventoryDto>()

                //.IncludeMembers(a=>a.FileToBlog,b=>b.FileToBlog)
                //.IncludeBase<FileManager,FileManagerDto>()
                //.ForMember(dest => dest.FileToBlog, opt => opt.MapFrom(src => src.FileToBlog))

                .ReverseMap();
            CreateMap<Inventory, CreateInventoryDto>().ReverseMap();
            CreateMap<Inventory, UpdateInventoryDto>().ReverseMap();
            CreateMap<Inventory, UpdateInventoryDto>().ReverseMap();


            #endregion Blog
            #region FilterProduct Mappings
     
            CreateMap<FilterProduct, FilterProductDto>().ReverseMap();
            CreateMap<FilterProduct, CreateFilterProductDto>().ReverseMap();
            CreateMap<FilterProduct, UpdateFilterProductDto>().ReverseMap();



            #endregion FilterProduct

            #region FilterProductValue Mappings

            CreateMap<FilterValueProduct, FilterValueProductDto>().ReverseMap();
            CreateMap<FilterValueProduct, CreateFilterValueProductDto>().ReverseMap();
            CreateMap<FilterValueProduct, UpdateFilterValueProductDto>().ReverseMap();



            #endregion FilterProductValue
            #region FilterValueProduct Mappings

            CreateMap<FilterValueProduct, FilterValueProductDto>().ReverseMap();
            CreateMap<FilterValueProduct, CreateFilterValueProductDto>().ReverseMap();
            CreateMap<FilterValueProduct, UpdateFilterValueProductDto>().ReverseMap();
            CreateMap<FilterValueProduct, UpdateFilterValueProductDto>().ReverseMap();


            #endregion FilterValueProduct
            #region Category Mappings
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            #endregion Category

       

            #region Tag Mappings
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<CreateTagDto, Tag>();
            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<Tag, UpdateTagDto>().ReverseMap();
            #endregion Tag
            #region FileManager Mappings
            CreateMap<FileManager,FileManagerDto>().ReverseMap();
        
            CreateMap<FileManager, CreateFileManagerDto>().ReverseMap();
            CreateMap<FileManager, UpdateFileManagerDto>().ReverseMap();
            #endregion FileManager

            #region FileToBlog Mappings
            CreateMap<FileToBlog, FileToBlogDto>()
                //.ForMember(dest=>dest.FileManagerDto,opt=>opt.MapFrom(src=>src.FileManager))
                .ReverseMap();

            CreateMap<FileToBlog, CreateFileToBlogDto>().ReverseMap();

            #endregion FileToBlog
       

            #region FileToProduct Mappings
            CreateMap<FileToProduct, FileToProductDto>().ReverseMap();

            CreateMap<FileToProduct, CreateFileToProductDto>().ReverseMap();

            #endregion FileToBlog
            #region FilterToProduct Mappings
            CreateMap<FilterToProduct, FilterToProductDto>().ReverseMap();

            CreateMap<FilterToProduct, CreateFilterToProductDto>().ReverseMap();

            #endregion 
            #region CategoryToBlog Mappings
            CreateMap<CategoryToBlog, CategoryToBlogDto>().ReverseMap();

            CreateMap<CategoryToBlog, CreateCategoryToBlogDto>().ReverseMap();

            #endregion CategoryToBlog
            #region TagToBlog Mappings
            CreateMap<TagToBlog, TagToBlogDto>().ReverseMap();

            CreateMap<TagToBlog, CreateTagToBlogDto>().ReverseMap();

            #endregion TagToBlog
            #region CategoryToProduct Mappings
            CreateMap<CategoryToProduct, CategoryToProductDto>().ReverseMap();

            CreateMap<CategoryToProduct, CreateCategoryToProductDto>().ReverseMap();

            #endregion CategoryToBlog
            #region TagToProduct Mappings
            CreateMap<TagToProduct, TagToProductDto>().ReverseMap();

            CreateMap<TagToProduct, CreateTagToProductDto>().ReverseMap();

            #endregion TagToBlog

            #region CommentToBlog Mappings
            CreateMap<CommentToBlog, CommentToBlogDto>().ReverseMap();

            CreateMap<CommentToBlog, CreateCommentToBlogDto>().ReverseMap();
            CreateMap<CommentToBlog, UpdateCommentToBlogDto>().ReverseMap();

            #endregion CommentToBlog

            #region CommentToProduct Mappings
            CreateMap<CommentToProduct, CommentToProductDto>().ReverseMap();

            CreateMap<CommentToProduct, CreateCommentToProductDto>().ReverseMap();
            CreateMap<CommentToProduct, UpdateCommentToProductDto>().ReverseMap();

            #endregion CommentToBlog

            #region Product Mappings
            CreateMap<Product, ProductDto>() .ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<CategoryToProduct, CategoryToProductDto>().ReverseMap();
            #endregion CommentToBlog

            #region SiteSetting Mappings
            CreateMap<SiteSetting, SiteSettingDto>().ReverseMap();

            CreateMap<SiteSetting, CreateSiteSettingDto>().ReverseMap();
            CreateMap<SiteSetting, UpdateSiteSettingDto>().ReverseMap();

            #endregion SiteSetting


            #region Menu Mappings
            CreateMap<Menu, MenuDto>().ReverseMap();

            CreateMap<Menu, CreateMenuDto>().ReverseMap();
            CreateMap<Menu, UpdateMenuDto>().ReverseMap();
            #endregion Menu

            #region UserAddress Mappings
            CreateMap<UserAddress, UserAddressDto>().ReverseMap();

            CreateMap<UserAddress, CreateUserAddressDto>().ReverseMap();
            CreateMap<UserAddress, UpdateUserAddressDto>().ReverseMap();
            #endregion Menu


            #region Orders Mappings
            /*reateMap<Blog, BlogDto>().ReverseMap();*/
            CreateMap<Orders, OrdersDto>().ReverseMap();
            CreateMap<Orders, CreateOrdersDto>().ReverseMap();
            CreateMap<Orders, UpdateOrdersDto>().ReverseMap();
            CreateMap<Orders, UpdateOrdersDto>().ReverseMap();
            #endregion Order



            #region OrderDetails Mappings
            CreateMap<OrderDetails, OrderDetialsDto>() .ReverseMap();
            CreateMap<OrderDetails, CreateOrderDetialsDto>().ReverseMap();
            CreateMap<OrderDetails, UpdateOrderDetialsDto>().ReverseMap();
            CreateMap<OrderDetails, UpdateOrderDetialsDto>().ReverseMap();
            #endregion OrderDetails


    

            #region Ticket Mappings
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<Ticket, CreateTicketDto>().ReverseMap();
            CreateMap<Ticket, UpdateTicketDto>().ReverseMap();
            CreateMap<TicketDto, UpdateTicketDto>().ReverseMap();
            CreateMap<TicketDto, CreateTicketDto>().ReverseMap();
            #endregion Ticket


            #region TicketGroup Mappings
            CreateMap<TicketGroup, TicketGroupDto>().ReverseMap();
            CreateMap<TicketGroup, CreateTicketGroupDto>().ReverseMap();
            CreateMap<TicketGroup, UpdateTicketGroupDto>().ReverseMap();
            CreateMap<TicketGroupDto, UpdateTicketGroupDto>().ReverseMap();
            CreateMap<TicketGroupDto, CreateTicketGroupDto>().ReverseMap();
            #endregion TicketGroup



            #region TicketToReply Mappings
            CreateMap<TicketToReply, TicketToReplyDto>().ReverseMap();
            CreateMap<TicketToReply, CreateTicketToReplyDto>().ReverseMap();
            CreateMap<TicketToReply, UpdateTicketToReplyDto>().ReverseMap();
            CreateMap<TicketToReplyDto, UpdateTicketToReplyDto>().ReverseMap();
            CreateMap<TicketToReplyDto, CreateTicketToReplyDto>().ReverseMap();
            #endregion TicketToReply

            #region FaqUserDto Mappings
            CreateMap<FaqUser, FaqUserDto>().ReverseMap();
            CreateMap<FaqUser, FaqUserDto>().ReverseMap();
            CreateMap<FaqUser, FaqUserDto>().ReverseMap();
            CreateMap<FaqUserDto, UpdateFaqUserDto>().ReverseMap();
            CreateMap<FaqUserDto, CreateFaqUserDto>().ReverseMap();
            #endregion



            #region Slider Mappings
            CreateMap<Slider, SliderDto>().ReverseMap();
            CreateMap<CreateSliderDto, Slider>();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            #endregion 
        }
    }
}
