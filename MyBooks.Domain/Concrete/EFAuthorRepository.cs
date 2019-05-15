using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Domain.Abstract;
using MyBooks.Domain.Entities;

namespace MyBooks.Domain.Concrete
{
    public class EFAuthorRepository : IRepository<Author>
    {
        private EFDbContext context = new EFDbContext().ObjectContext;

        public IEnumerable<Author> Entities
        {
            get { return context.Authors; }
        }

        public void Save(Author author)
        {
            if (author.author_id == 0)
            {
                context.Authors.Add(author);
            }
            else
            {
                var a = context.Authors.Find(author.author_id);
                if (a != null)
                {
                    a.fname = author.fname;
                    a.lname = author.lname;
                    a.biography = author.biography;
                    a.birthdate = author.birthdate;
                    a.deathdate = author.deathdate;
                    if(author.imagedata!=null&&author.imagemimetype!=null)
                    {
                        a.imagedata = author.imagedata;
                        a.imagemimetype = author.imagemimetype;
                    }
                    
                }


            }
            context.SaveChanges();
        }
    }
}
