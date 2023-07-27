using Kashi_Seramic.Domain;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kashi_Seramic.Persistences
{
    public class AppDbContext : AuditableDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
        #region Defind tables

        public DbSet<Menu> Menu { get; set; }
        public DbSet<SiteSetting> SiteSetting { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<OrderSatus> OrderSatus { get; set; }
        public DbSet<OrderDetails> OrderDetials { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<FaqUser> FaqUser { get; set; }
        public DbSet<FilterProduct> FilterProduct { get; set; }
        public DbSet<FilterValueProduct> FilterValueProduct { get; set; }
        public DbSet<Inventory> Inventory { get; set; }


        public DbSet<CommentToBlog> CommentToBlog { get; set; }
        public DbSet<CommentToProduct> CommentToProduct { get; set; }
        public DbSet<CategoryToBlog> CategoryToBlogs { get; set; }
        public DbSet<CategoryToProduct> CategoryToProduct { get; set; }
        public DbSet<TagToBlog> TagToBlog { get; set; }
        public DbSet<TagToProduct> TagToProduct { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<FileManager> FileManager { get; set; }
        public DbSet<FileToBlog> FileToBlogs { get; set; }
        public DbSet<FileToProduct> FileToProduct { get; set; }
        public DbSet<FilterToProduct> FilterToProduct { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketGroup> TicketGroup { get; set; }
        public DbSet<TicketToReply> TicketToReply { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }

        #endregion




    }
}
