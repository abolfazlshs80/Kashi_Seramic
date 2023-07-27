using Pr_Signal_ir.MVC.Models.OrderDetials;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalWebsite_RazorPage.Core.ViewModel
{
    public class ShowCardVM
    {
        public ShowCardVM()
        {
            Order=new OrderVM();
            Order.orderDetails=new List<OrderDetialsVM>();
            OrdersDetails = new List<OrderDetialsVM>();
            blogs=new List<ProductVM>();
        }
        public CartViewModel ShowCardNouser { get; set; }
        public OrderVM Order { get; set; }
        public IEnumerable<OrderDetialsVM> OrdersDetails { get; set; }
        public IEnumerable<ProductVM> blogs { get; set; }
        public ProductVM Blog(int id)
        {
            try
            {

                return blogs.Where(a => a.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
