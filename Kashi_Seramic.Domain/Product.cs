using Kashi_Seramic.Domain.Common;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Domain
{
    public class Product:BaseDomainEntity
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }

        public decimal OffPrice { get; set; }
        public int Qountity { get; set; }
        public int Seen { get; set; }
        public string LinkKey { get; set; }
        public ICollection<OrderDetails> orderDetails { get; set; }
        public ICollection<CategoryToProduct> CategoryToProduct { get; set; }
        public ICollection<FileToProduct> FileToProduct { get; set; }
        public ICollection<CommentToProduct> CommentToProduct { get; set; }
        public ICollection<TagToProduct> TagToProduct { get; set; }
        public ICollection<FilterToProduct> FilterToProduct { get; set; }

    }
}
