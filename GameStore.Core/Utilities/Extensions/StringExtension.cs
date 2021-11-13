using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Utilities.Extensions
{
    public static class StringExtension
    {
        public static string Fixed(this string input)
        {
            return input.Trim().ToLower();
        }
    }
}
