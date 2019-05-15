using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Domain.Entities;
using System.Data.Entity;
using MyBooks.Domain.Abstract;

namespace MyBooks.Domain.Concrete
{
    public class EFBookRepository: IRepository<Book>
    {
        private EFDbContext context = new EFDbContext().ObjectContext;

        public IEnumerable<Book> Entities
        {
            get
            {
                return context.Books;
            }
        }

        public void Save(Book book)
        {
            //if(book.book_id==0)
            //{
            //    context..Add(book);
            //}
            //else
            {
                Book b = context.Books.Find(book.book_id);
                b.name = book.name;
                b.author_id = book.author_id;
                b.genre_id = book.genre_id;
               // b.phouse_id = book.phouse_id;
                b.year = book.year;
            }

            context.SaveChanges();
        }


    }
}
