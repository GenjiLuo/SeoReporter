using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SeoReporter.Business.Helpers
{
    public static class StringHelpers
    {
        public static string GetQueryStringFriendlyParameters(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            var cleanString = StripNonAlphanumeric(input);
            var values = cleanString.Split(" ");

            return string.Join("+", values);
        }

        private static string StripNonAlphanumeric(string input)
        {
            Regex reg = new Regex("[^a-zA-Z0-9 ]");
            var newString = reg.Replace(input, string.Empty);
            return newString.Trim();
        }
    }
}
