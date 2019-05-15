using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBooks.Domain.Entities;
using MyBooks.Domain.Abstract;
using MyBooks.WebUI.Infrastructure;

namespace MyBooks.WebUI.Controllers
{
    public class AuthorController : Controller
    {
        private IRepository<Author> mainAuthorRepo;

        public AuthorController(IRepository<Author> authorRepo)
        {
            this.mainAuthorRepo = authorRepo;
        }

        public ViewResult EditAuthor(int author_id)
        {
            Author auth = mainAuthorRepo.Entities.First(a => a.author_id == author_id);

            return View(auth);
        }

        [HttpPost]
        public ActionResult EditAuthor(Author auth, HttpPostedFileBase image)
        {
            if (auth.birthdate >= auth.deathdate)
            {
                ModelState.AddModelError("", "Дата рождения должна быть меньше даты смерти");
            }
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    auth.imagemimetype = image.ContentType;
                    auth.imagedata = new byte[image.ContentLength];
                    image.InputStream.Read(auth.imagedata, 0, image.ContentLength);

                }
                mainAuthorRepo.Save(auth);
                return RedirectToAction("Index","Home");
            }

            else return View(auth);
        }


        public ViewResult AuthorSummary(int author)
        {
            Author auth = mainAuthorRepo.Entities.First(a => a.author_id == author);

            return View(auth);
        }

        public FileContentResult GetImage(int author_id)
        {
            Author auth = mainAuthorRepo.Entities.FirstOrDefault(a => a.author_id == author_id);
            if (auth != null)
            {
                return File(auth.imagedata, auth.imagemimetype);
            }
            else return null;
        }

        //public ViewResult AuthorSummary(Author author)
        //{

        //    return View(author);
        //}
    }
}