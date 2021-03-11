using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDateApp.Helper
{
    public class DateHelper : IDateHelper
    {
        //Assume: date2 is greater than date1
        public int GetDifference(string date1, string date2)
        {
            int diff = 0;
            string[] splitDate1 = date1.Split('/');
            string[] splitDate2 = date2.Split('/');
            int day1 = int.Parse(splitDate1[1]);
            int day2 = int.Parse(splitDate2[1]);
            int month1 = int.Parse(splitDate1[0]);
            int month2 = int.Parse(splitDate2[0]);
            int year1 = int.Parse(splitDate1[2]);
            int year2 = int.Parse(splitDate2[2]);

            if (year2 - year1 == 0)
            {
                if(month2 - month1 == 0)
                {
                    diff = day2 - day1;
                }
                else
                {
                    diff = NoOfDaysInMonth(month1, year1) - day1 + day2;
                    for (int i = 1; i < month2 - month1; i++)
                    {
                        diff += NoOfDaysInMonth(month1 + i, year1);
                    }
                }
            }
            else if(year2 - year1 == 1)
            {
                diff = CalculateRemainingDaysInYear(day1, month1, year1) + CalculatePastDaysInYear(day2, month2, year2);
            }
            else
            {
                diff = CalculateRemainingDaysInYear(day1, month1, year1) + CalculatePastDaysInYear(day2, month2, year2);
                for (int i = 1; i < year2 - year1; i++)
                {
                    diff += ((year1 + i) % 4) == 0 ? 366 : 365;
                }
            }
            return diff;
        }


        private int CalculateRemainingDaysInYear(int day, int month, int year)
        {
            int dayCount = NoOfDaysInMonth(month, year) - day;
            for (int i=month + 1; i <= 12; i++)
            {
                dayCount += NoOfDaysInMonth(i, year);
            }
            return dayCount;
        }

        private int CalculatePastDaysInYear(int day, int month, int year)
        {
            int dayCount = day;
            for (int i = 1; i < month; i++)
            {
                dayCount += NoOfDaysInMonth(i, year);
            }
            return dayCount;
        }

        private int NoOfDaysInMonth(int month, int year)
        {
            switch(month)
            {
                case 1:
                    return 31;
                case 2:
                    return year % 4 == 0 ? 29 : 28;
                case 3:
                    return 31;
                case 4:
                    return 30;
                case 5:
                    return 31;
                case 6:
                    return 30;
                case 7:
                    return 31;
                case 8:
                    return 31;
                case 9:
                    return 30;
                case 10:
                    return 31;
                case 11:
                    return 30;
                case 12:
                    return 31;
                default:
                    return 0;
            }
        }
    }

    public class Validator : IValidator
    {
        public bool Validate(string date)
        {
            if (date.IndexOf("/") == -1)
            {
                return false;
            }
            return true;
        }
    }
}
