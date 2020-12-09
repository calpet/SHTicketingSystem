using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SelfHelpTicketingSystem.Classes
{
    public class HtmlMarkupManager
    {
        public static string EncodeHtml(string text)
        {
            return WebUtility.HtmlEncode(text);
        }

        public static string DecodeHtml(string text)
        {
            return WebUtility.HtmlDecode(text);
        }

        public static string StripHtmlTags(string text)
        {
            return Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }
    }
}
