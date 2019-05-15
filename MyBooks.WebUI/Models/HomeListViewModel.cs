using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBooks.WebUI.Models
{
    public class HomeListViewModel
    {
        public AuthorListViewModel AuthorListViewModel { get; set;}

        public BookListViewModel BookListViewModel { get; set; }

        public CommonBookListViewModel CommonBookListViewModel { get; set; }
    }
}