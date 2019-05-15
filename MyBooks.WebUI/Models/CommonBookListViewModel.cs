using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBooks.Domain.Entities;

namespace MyBooks.WebUI.Models
{
    public class CommonBookListViewModel
    {
        public IEnumerable<CommonBook> CommonBooks { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}