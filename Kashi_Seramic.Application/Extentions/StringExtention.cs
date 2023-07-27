using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class StringExtention
{
    public static string SetForUrl(this string str)
    {
        return str.Replace(" ", "-");
    }

    public static string SetForSliderUrl(this string str)
    {
        return "/Images/Slider/" + str;
    }

    public static string SetForBlogBackUrl(this string str)
    {
        return "/Images/Blog/" + str;
    }
    public static string SetForBlogUrl(this string str)
    {
        return "/Images/Blog/" + str.Replace("Slider", "BG");
       
    }

    public static string SetForProductUrl(this string str)
    {
        return "/Images/Product/" + str;
    }
    public static string SetForProductBackUrl(this string str)
    {
        return "/Images/Product/" + str.Replace("Slider", "BG");
     
    }
    public static string SetForLogoUrl(this string str)
    {
        return "/Images/Site/" + str;
    }
}

