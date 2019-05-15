using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBooks.Domain.Entities;
using MyBooks.Domain.Abstract;
using MyBooks.WebUI.Infrastructure;
using MyBooks.WebUI.Models;

namespace MyBooks.WebUI.Controllers
{
    public class CommonBookController : Controller
    {
        private IRepository<CommonBook> comBookRepo;

        private IEntityCollector entityCollector;

        public CommonBookController(IRepository<CommonBook> comBookRepo, IEntityCollector entityCollector)
        {
            this.comBookRepo = comBookRepo;
            this.entityCollector = entityCollector;
        }

        public ViewResult AddBooksToCommonBook(int common_book_id)
        {
            var a = entityCollector.GetBooksForCommonBook(common_book_id);
            var b = entityCollector.GetBooksExcept(common_book_id);
            

            ViewBag.BooksSelected = a;
            ViewBag.Books = b;

            return View(common_book_id);
        }

       
        public ViewResult EditCommonBook( /*[Bind(Prefix="comBook")]*/ int common_book_id)
        {
            CommonBook b = comBookRepo.Entities.First(bb => bb.common_book_id == common_book_id);

            var sss = b.Books.Select(bf=>bf.name);

            ViewBag.books = entityCollector.GetAllBooks(common_book_id);
            ViewBag.publishers = entityCollector.GetAllPublishers(b.phouse_id);

            EditCommonBookViewModel model = new EditCommonBookViewModel
            {
                comBook = b,
                Books = entityCollector.GetAllBooks(common_book_id),
                Publishers = entityCollector.GetAllPublishers(b.phouse_id)
            };

            return View(b);
        }

        private void AddNewBooks(IEnumerable<string> booksToAdd, CommonBook book)
        {
            foreach (var i in booksToAdd)
            {
                int converted = Convert.ToInt32(i);

                Book bbb = entityCollector.GetAllBooksDummy().First(m => m.book_id == converted);

                book.Books.Add(bbb);

            }
        }

        private void RemoveBooks(IEnumerable<string> booksToRemove, CommonBook book)
        {
            foreach (var i in booksToRemove)
            {

                int converted = Convert.ToInt32(i);

                Book bbb = entityCollector.GetAllBooksDummy().First(m => m.book_id == converted);

                book.Books.Remove(bbb);
            }
        }

        [HttpPost]
        public ActionResult AddBooksToCommonBook(string newVals, int comBook)
        {
            CommonBook book = comBookRepo.Entities.First(bb => bb.common_book_id == comBook);

            var newBooks = newVals.Split(',');

            var currentBooks = entityCollector.GetBooksForCommonBook(comBook);

            var booksToAdd = newBooks.Except(currentBooks.Select(a => a.Value));

            var booksToRemove = currentBooks.Select(a => a.Value).Except(newBooks);

            AddNewBooks(booksToAdd, book);

            RemoveBooks(booksToRemove, book);

            comBookRepo.Save(book);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult EditCommonBook(CommonBook book, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    book.imagemimetype = image.ContentType;
                    book.imagedata = new byte[image.ContentLength];
                    image.InputStream.Read(book.imagedata, 0, image.ContentLength);
                }

                Book bbb = entityCollector.GetAllBooksDummy().First(m => m.book_id == 7);
                book.Books.Add(bbb);
                comBookRepo.Save(book);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(book);
            }
        }

        public FileContentResult GetImage(int common_book_id)
        {
            CommonBook cb = comBookRepo.Entities.FirstOrDefault(a => a.common_book_id == common_book_id);
            if (cb != null)
            {
                return File(cb.imagedata, cb.imagemimetype);
            }
            else return null;
        }
    }
}