

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Extentions
{
    public  class ShortCode
    {
        private async Task< string >CreateShortKey()
        {
            string[] arrABC = new string[] { "a", "b", "c", "d", "f", "g", "h", "j", "k", "l", "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "z", "x", "n", "v", "m" };
            string title = "";
            for (int i = 0; i < 3; i++)
            {
                title += arrABC[new Random().Next(0, arrABC.Length - 1)];
            }
            title += new Random().Next(0, 9);
            return title;

        }

        public async Task< string> GetCodeValidForBlog(List<Blog> blogs)
        {
            bool linkStatus = false;
            var newlink =await CreateShortKey();
            while (!linkStatus)
            {
                if (blogs.Where( a => a.LinkKey == newlink).Any())
                    newlink =await CreateShortKey();
                else
                    linkStatus = true;


            }
            return newlink;
        }
        public async Task<string> GetCodeValidForProduct(List<Product> blogs)
        {
            bool linkStatus = false;
            var newlink = await CreateShortKey();
            while (!linkStatus)
            {
                if (blogs.Where(a => a.LinkKey == newlink).Any())
                    newlink = await CreateShortKey();
                else
                    linkStatus = true;


            }
            return newlink;
        }

    
    }
}
