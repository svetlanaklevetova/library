using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBooks.Domain.Abstract;
using MyBooks.WebUI.Models;
using MyBooks.Domain.Entities;

namespace MyBooks.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private IRepository<Author> authRepo;

        private IRepository<Book> bookRepo;

        private IRepository<Genre> genreRepo;

        private IRepository<Publisher> publRepo;

        private IRepository<CommonBook> comBookRepo;


        private int PageSize = 4;

        public HomeController(IRepository<Author> authRepo,
            IRepository<Book> bookRepo,
            IRepository<Genre> genreRepo, 
            IRepository<Publisher> publRepo,
            IRepository<CommonBook> comBookRepo
            )
        {
            this.authRepo = authRepo;
            this.bookRepo = bookRepo;
            this.genreRepo = genreRepo;
            this.publRepo = publRepo;
            this.comBookRepo = comBookRepo;
        }

        public ActionResult Index(string genre, int authorPage=1, int bookPage=1, int comBookPage=1)
        {
            HomeListViewModel model = new HomeListViewModel 
            { 
                AuthorListViewModel = GetAuthorListViewModel(authorPage), 
                BookListViewModel = GetBookListViewModel(genre, bookPage),
                CommonBookListViewModel = GetCommonBookListViewModel(comBookPage)
            };

           // var sss = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
           // var ssss = sss.Take(5).Union(sss.Skip(sss.Count - 3).Take(3).Reverse()).ToList();
            
            return View(model);
        }

        private AuthorListViewModel GetAuthorListViewModel(int authorPage)
        {
            return new AuthorListViewModel
            {
                Authors = authRepo.Entities.OrderBy(p => p.author_id).Skip((authorPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = authorPage, ItemPerPage = PageSize, TotalItems = authRepo.Entities.Count() }
            };
        }

        private CommonBookListViewModel GetCommonBookListViewModel(int bookPage)
        {
            return new CommonBookListViewModel
            {
                CommonBooks = comBookRepo.Entities.OrderBy(p => p.common_book_id).Skip((bookPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = bookPage, ItemPerPage = PageSize, TotalItems = comBookRepo.Entities.Count() }
            };
        }

        private BookListViewModel GetBookListViewModel(string genre,int bookPage)
        {
            var books = genre == null ? bookRepo.Entities.OrderBy(p => p.book_id).ToArray() : bookRepo.Entities.Select(p => p).ToArray().Where(p => p.genre.name == genre);
          
            var count = books.Count();

            return new BookListViewModel
            {
                Books = books.OrderBy(p => p.book_id).Skip((bookPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = bookPage, ItemPerPage = PageSize, TotalItems = count, },
                CurrentGenre = genre
            };

        }

        public PartialViewResult GetBooks(int page=1, string genre=null)
        {
            return PartialView("BookTable", GetBookListViewModel(genre, page));
        }

        public PartialViewResult GetAuthors(int page = 1)
        {
            return PartialView("AuthorTable", GetAuthorListViewModel(page));
        }

        public PartialViewResult GetCommonBooks(int page=1)
        {
            return PartialView("CommonBookTable", GetCommonBookListViewModel(page));
        }
    }
}