﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBooks.Domain.Entities;

namespace MyBooks.WebUI.Models
{
    public class AuthorListViewModel
    {
        public IEnumerable<Author> Authors { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}