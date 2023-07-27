using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class IntExtention
    {
        public static int ConvertToInt(this decimal value)
        {
            return (Convert.ToInt32(value));
        }
    }
