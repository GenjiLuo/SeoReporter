﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using SeoReporter.Business.Helpers;

namespace SeoReporter.Business.Services
{
    public class SearchResultFinder : ISearchResultFinder
    {
        private readonly Regex _resultRegex = new Regex("<h3 class=\"r\".*?<a.*?<\\/h3>");
        private readonly Regex _linkUrlRegex = new Regex("href=\".*?\"");

        public string FindPositions(string content, string url)
        {
            var resultMatches = _resultRegex.Matches(content);
            var position = 1;
            var builder = new StringBuilder();
            foreach (Match resultMatch in resultMatches)
            {
                var linkMatches = _linkUrlRegex.Matches(resultMatch.Value);
                if (linkMatches.Count > 1 || linkMatches.Count == 0)
                {
                    throw new Exception($"Unexpected number of links found in search result: {linkMatches.Count}");
                }

                var resultUrl = linkMatches[0].Value.ExtractUrlFromHref();
                if (resultUrl.ToLowerInvariant().Contains(url.ToLowerInvariant()))
                {
                    builder.Append($"{position}, ");
                }
                position++;
            }
            var positions = builder.ToString();
            return String.IsNullOrWhiteSpace(positions) ? "0" : positions.TrimEnd(',', ' ');
        }
    }
}