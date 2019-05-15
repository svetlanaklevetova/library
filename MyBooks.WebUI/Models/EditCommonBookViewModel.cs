using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBooks.Domain.Entities;
using System.Web.Mvc;

namespace MyBooks.WebUI.Models
{
    public class EditCommonBookViewModel
    {
        public CommonBook comBook { get; set; }

        public List<SelectListItem> Books { get; set; }

        public List<SelectListItem> Publishers { get; set; }
    }
}