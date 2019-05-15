using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBooks.Domain.Abstract;
using MyBooks.Domain.Entities;

namespace MyBooks.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IRepository<Book> repo;

        public NavController(IRepository<Book> repo)
        {
            this.repo = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(string genre = null)
        {
            ViewBag.SelectedGenre = genre;
            //IEnumerable<string> genres = repo.Books.Select(x => x.genre.name).Distinct().OrderBy(x => x);

            IEnumerable<string> genres = repo.Entities.OrderBy(x => x.genre.name).Select(x => x.genre.name).Distinct().ToArray();

            return PartialView(genres);
        }
    }
}