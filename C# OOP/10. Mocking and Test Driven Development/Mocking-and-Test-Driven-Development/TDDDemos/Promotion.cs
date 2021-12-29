using System;
using System.Collections.Generic;
using System.Text;

namespace TDDDemos
{
    public class Promotion
    {
        private DateTime dateToday;

        public Promotion(DateTime today)
        {
            dateToday = today;
        }

        public Promotion()
            : this(DateTime.Now)
        {

        }

        public virtual int CalculateDiscount(int price)
        {
            return price - price * Get() / 100;
        }

        public virtual int Get()
        {
            if (dateToday.DayOfWeek == DayOfWeek.Monday)
            {
                return 30;
            }
            if (dateToday.DayOfWeek == DayOfWeek.Tuesday)
            {
                return 10;
            }
            if (dateToday.DayOfWeek == DayOfWeek.Wednesday)
            {
                return 40;
            }
            if (dateToday.DayOfWeek == DayOfWeek.Sunday)
            {
                return -10;
            }
            return 0;
        }
    }
}
