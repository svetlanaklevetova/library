using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBooks.Domain.Abstract;
using MyBooks.Domain.Entities;
using MyBooks.WebUI.Infrastructure;
using MyBooks.WebUI.Models;

namespace MyBooks.WebUI.Controllers
{
    public class BookController : Controller
    {
        private IRepository<Book> mainBookRepo;

        private IEntityCollector entityCollector;

        public BookController(IRepository<Book> bookRepo, IEntityCollector entityCollector)
        {
            this.mainBookRepo = bookRepo;

            this.entityCollector = entityCollector;


        }
        public ViewResult EditBook(int book_id)
        {
            Book b = mainBookRepo.Entities.First(bb => bb.book_id == book_id);
            //var sss = b.CommonBooks.Select(cc => cc.common_book_name);
            //var bg = sss.First();
            EditBookListViewModel model = new EditBookListViewModel
            {
                book = b,
                Authors = entityCollector.GetAllAuthors(b.author_id),
                Genres = entityCollector.GetAllGenres(b.genre_id)
                //Publishers = entityCollector.GetAllPublishers(b.phouse_id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            if (ModelState.IsValid)
            {

                mainBookRepo.Save(book);
                return RedirectToAction("Index","Home");
            }
            else return View(book);
        }
    }
}