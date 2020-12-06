using System;

namespace MVC_Lib1
{
    public class Calc
    {
        public static string getDate(int age)
        {
            var date = DateTime.Now.Date;
            date = date.AddYears(-age);
            return date.ToShortDateString();
        }
    }
}
