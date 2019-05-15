using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyBooks.Domain.Entities;

namespace MyBooks.WebUI.Infrastructure
{
    public interface IEntityCollector
    {
        List<SelectListItem> GetAllAuthors(int selectedId);
        List<SelectListItem> GetAllGenres(int selectedId);
        List<SelectListItem> GetAllPublishers(int selectedId);
        List<SelectListItem> GetAllBooks(int commonBookId);
        List<Book> GetAllBooksDummy();
        List<SelectListItem> GetBooksForCommonBook(int commonBookId);
        List<SelectListItem> GetBooksExcept(int commonBookId);
    }
}