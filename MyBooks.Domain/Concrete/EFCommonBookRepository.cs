using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Domain.Abstract;
using MyBooks.Domain.Entities;
using System.Data.Entity;

namespace MyBooks.Domain.Concrete
{
    public class EFCommonBookRepository: IRepository<CommonBook>
    {
        private EFDbContext context = new EFDbContext().ObjectContext;

        public IEnumerable<CommonBook> Entities
        {
            get
            {
                return context.CommonBooks;
            }
        }

        public void AddNewCommonBook(CommonBook book, Book newBook)
        {
            CommonBook b = context.CommonBooks.Find(book.common_book_id);
            b.Books.Add(newBook);
            context.SaveChanges();
        }

        public void Save(CommonBook book)
        {
            CommonBook b = context.CommonBooks.Find(book.common_book_id);
                b.common_book_name = book.common_book_name;
                b.phouse_id = book.phouse_id;
                b.year = book.year;

            if(book.imagedata != null && book.imagemimetype != null)
            {
                b.imagemimetype = book.imagemimetype;
                b.imagedata = book.imagedata;
            }
            var tempBooks = book.Books.ToArray();

            foreach(Book sa in tempBooks)
            {
                b.Books.Add(sa);
            }
               // b.phouse_id = book.phouse_id;
           
            

            context.SaveChanges();
        }


       
    }
}
