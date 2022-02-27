﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.MVC.Pagination
{
    public class Pagination:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "nav";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("aria-label", "Page navigation");
            output.Content.SetHtmlContent(AddPageContent());
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int PageRange { get; set; }
        public string PageFirst { get; set; }
        public string PageLast { get; set; }
        public string PageTarget { get; set; }
        public string Parametars { get; set; }

        private string AddPageContent()
        {
            if (PageRange == 0)
            {
                PageRange = 1;
            }

            if (PageCount < PageRange)
            {
                PageRange = PageCount;
            }

            if (string.IsNullOrEmpty(PageFirst))
            {
                PageFirst = "Newest";
            }

            if (string.IsNullOrEmpty(PageLast))
            {
                PageLast = "Oldest";
            }

            var content = new StringBuilder();
            content.Append(" <ul class='pagination'>");
            if (PageNumber != 1)
            {
                content.Append($"<li class='page-item'><a class='page-link' href='{PageTarget}/1'>{PageFirst}</a></li>");

            }


            if (PageNumber <= PageRange)
            {

                for (int currentPage = 1; currentPage < 2 * PageRange + 1; currentPage++)
                {
                    if (currentPage < 1 || currentPage > PageCount)
                    {
                        continue;
                    }
                    var active = currentPage == PageNumber ? "active" : "";
                    string parametars = PageTarget + "?p=" + currentPage;
                    if (Parametars != null)
                    {
                        parametars += "&category=" + Parametars;
                    }
                    content.Append($"<li class='page-item {active}'><a class='page-link'href='{parametars}'>{currentPage}</a></li>");
                }
            }
            else if (PageNumber > PageRange && PageNumber < PageCount - PageRange)
            {
                for (int currentPage = PageNumber - PageRange; currentPage < PageNumber + PageRange; currentPage++)
                {
                    if (currentPage < 1 || currentPage > PageCount)
                    {
                        continue;
                    }
                    var active = currentPage == PageNumber ? "active" : "";
                    string parametars = PageTarget + "?p=" + currentPage;
                    if (Parametars != null)
                    {
                        parametars += "&category=" + Parametars;
                    }
                    content.Append($"<li class='page-item {active}'><a class='page-link'href='{parametars}'>{currentPage}</a></li>");


                    //   var active = currentPage == PageNumber ? "active" : "";
                    // content.Append($"<li class='page-item {active}'><a class='page-link'href='{PageTarget}?p={currentPage}'>{currentPage}</a></li>");
                }
            }
            else
            {
                for (int currentPage = PageCount - (2 * PageRange); currentPage < PageCount + 1; currentPage++)
                {
                    if (currentPage < 1 || currentPage > PageCount)
                    {
                        continue;
                    }
                    var active = currentPage == PageNumber ? "active" : "";
                    string parametars = PageTarget + "?p=" + currentPage;
                    if (Parametars != null)
                    {
                        parametars += "&category=" + Parametars;
                    }

                    content.Append($"<li class='page-item {active}'><a class='page-link'href='{parametars}'>{currentPage}</a></li>");
                }
            }
            if (PageNumber != PageCount)
            {
                content.Append($"<li class='page-item'><a class='page-link' href='{PageTarget}?p={PageCount}'>{PageLast}</a></li>");

            }

            content.Append(" </ul");
            return content.ToString();
        }
    }
}
