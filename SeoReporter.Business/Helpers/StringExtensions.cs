using System.Text.RegularExpressions;

namespace SeoReporter.Business.Helpers
{
    public static class StringExtensions
    {
        public static string GetQueryStringFriendlyParameters(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            var cleanString = input.StripNonAlphanumeric();
            var values = cleanString.Split(" ");

            return string.Join("+", values);
        }

        public static string ExtractUrlFromHref(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            var result = Regex.Match(input, "http.*?\"");
            return result.Value.Trim('"');
        }

        public static string StripNonAlphanumeric(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            var reg = new Regex("[^a-zA-Z0-9 ]");
            var newString = reg.Replace(input, string.Empty);
            return newString.Trim();
        }
    }
}
