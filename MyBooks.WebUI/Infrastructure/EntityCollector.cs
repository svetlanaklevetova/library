using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBooks.Domain.Abstract;
using MyBooks.Domain.Entities;
using System.Web.Mvc;

namespace MyBooks.WebUI.Infrastructure
{
    public class EntityCollector : IEntityCollector
    {
        private IRepository<Author> authRepo;

        private IRepository<Genre> genreRepo;

        private IRepository<Publisher> publRepo;

        private IRepository<Book> bookRepo;

        private IRepository<CommonBook> comBookRepo;

        public EntityCollector(IRepository<Author> authRepo, IRepository<Genre> genreRepo, IRepository<Publisher> publRepo, IRepository<Book> bookRepo, IRepository<CommonBook> comBookRepo)
        {
            this.authRepo = authRepo;
            this.genreRepo = genreRepo;
            this.publRepo = publRepo;
            this.bookRepo = bookRepo;
            this.comBookRepo = comBookRepo;
        }

        public List<SelectListItem> GetAllAuthors(int selectedId)
        {
            List<SelectListItem> listOfAuthors = new List<SelectListItem>();

            foreach (Author a in authRepo.Entities)
            {
                listOfAuthors.Add(new SelectListItem { Selected = selectedId == a.author_id, Text = string.Format("{0} {1}", a.fname, a.lname), Value = a.author_id.ToString() });
            }
            return listOfAuthors;
        }

        public List<SelectListItem> GetAllGenres(int selectedId)
        {
            List<SelectListItem> listOfGenres = new List<SelectListItem>();

            foreach (Genre g in genreRepo.Entities)
            {
                listOfGenres.Add(new SelectListItem { Selected = selectedId == g.genre_id, Text = g.name, Value = g.genre_id.ToString() });
            }

            return listOfGenres;
        }

        public List<SelectListItem> GetAllPublishers(int selectedId)
        {
            List<SelectListItem> listOfPublishers = new List<SelectListItem>();

            foreach (Publisher p in publRepo.Entities)
            {
                listOfPublishers.Add(new SelectListItem { Selected = selectedId == p.phouse_id, Text = p.name, Value = p.phouse_id.ToString() });
            }
            return listOfPublishers;
        }

        public List<SelectListItem> GetBooksExcept(int commonBookId)
        {
            CommonBook common = comBookRepo.Entities.Select(b => b).Where(b => b.common_book_id == commonBookId).First();

            var except = bookRepo.Entities.Except(common.Books);
            List<SelectListItem> listOfBooks = new List<SelectListItem>();


            foreach (Book p in except)
            {
                listOfBooks.Add(new SelectListItem { Text = p.name, Value = p.book_id.ToString() });
            }

            return listOfBooks;
        }

        public List<SelectListItem> GetAllBooks(int commonBookId)
        {
            CommonBook common = comBookRepo.Entities.Select(b => b).Where(b => b.common_book_id == commonBookId).First();

            var test = bookRepo.Entities.Except(common.Books);
            List<SelectListItem> listOfBooks = new List<SelectListItem>();


            foreach (Book p in bookRepo.Entities)
            {
                listOfBooks.Add(new SelectListItem { Text = p.name, Value = p.book_id.ToString() });
            }

            return listOfBooks;
            //return bookRepo.Entities.Select(b=>b);
        }

        public List<SelectListItem> GetBooksForCommonBook(int commonBookId)
        {
            CommonBook cb = comBookRepo.Entities.Select(p=>p).Where(p => p.common_book_id == commonBookId).First();
             List<SelectListItem> listOfBooks = new List<SelectListItem>();


            foreach (Book p in cb.Books)
            {
                listOfBooks.Add(new SelectListItem { Text = p.name, Value = p.book_id.ToString() });
            }

            return listOfBooks;
        }

        

        public List<Book> GetAllBooksDummy()
        {
            


            List<SelectListItem> listOfBooks = new List<SelectListItem>();


            foreach (Book p in bookRepo.Entities)
            {
                listOfBooks.Add(new SelectListItem { Text = p.name, Value = p.book_id.ToString() });
            }

            return bookRepo.Entities.ToList();
            //return bookRepo.Entities.Select(b=>b);
        }
    }
}