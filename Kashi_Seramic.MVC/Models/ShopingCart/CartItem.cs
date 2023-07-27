using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class CartItem
    {
        public int Id { get; set; }
        public ProductVM Item { get; set; }
        public int Quantity { get; set; }

        public decimal getTotalPrice()
        {
            return (Item.OffPrice.ToString().Equals("0.00")?Item.Price:Item.OffPrice) * Quantity;
        }
    }

