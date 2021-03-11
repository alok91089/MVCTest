using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDateApp.Helper
{
    public interface IDateHelper
    {
        int GetDifference(string date1, string date2);
    }

    public interface IValidator
    {
        bool Validate(string date);
    }
}
