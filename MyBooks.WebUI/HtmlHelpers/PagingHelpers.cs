using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyBooks.WebUI.Models;
using System.Text;

namespace MyBooks.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
       public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfo pagingInfo,
            Func<int, string> pageUrl)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                res.Append(tag.ToString());


            }

            return MvcHtmlString.Create(res.ToString());
        }

       

       public static MvcHtmlString PageLinks2(this HtmlHelper html,
             PagingInfo pagingInfo,
             Func<int, string> pageUrl)
       {
           StringBuilder res = new StringBuilder();
           for (int i = 1; i <= pagingInfo.TotalPages; i++)
           {
               TagBuilder tag = new TagBuilder("a");
               tag.MergeAttribute("href", pageUrl(i));
               tag.InnerHtml = i.ToString();
               if (i == pagingInfo.CurrentPage)
               {
                   tag.AddCssClass("selected");
                   tag.AddCssClass("btn-primary");
               }
               tag.AddCssClass("btn btn-default");
               res.Append(tag.ToString());


           }

           return MvcHtmlString.Create(res.ToString());
       }

    }
}