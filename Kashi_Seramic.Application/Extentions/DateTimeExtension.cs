using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DateTimeExtension
{
    public static string ConvertHeloToPersion(this string dt)
    {
        return "سلام";
    }
    public static string ConvertDateToPersion(this DateTime dt)
    {
        PersianCalendar persianCalendar = new PersianCalendar();


        return persianCalendar.GetYear(dt) + "/" + persianCalendar.GetMonth(dt) + "/" + persianCalendar.GetDayOfMonth(dt);
    }
    public static string ConvertTimeToPersion(this DateTime dt)
    {
        PersianCalendar persianCalendar = new PersianCalendar();


        return persianCalendar.GetHour(dt) + "/" + persianCalendar.GetMinute(dt) + "/" + persianCalendar.GetSecond(dt);
    }

}
