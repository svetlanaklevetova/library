using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBooks.Domain.Entities;
using System.Web.Mvc;


namespace MyBooks.WebUI.Models
{
    public class EditBookListViewModel
    {
        public Book book { get; set; }

        public List<SelectListItem> Authors { get; set; }

        public List<SelectListItem> Genres { get; set; }

       // public List<SelectListItem> Publishers { get; set; }
    }
}