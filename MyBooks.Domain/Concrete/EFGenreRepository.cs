using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Domain.Abstract;
using MyBooks.Domain.Entities;

namespace MyBooks.Domain.Concrete
{
    public class EFGenreRepository: IRepository<Genre>
    {
        EFDbContext context = new EFDbContext().ObjectContext;

        public IEnumerable<Genre> Entities
        {
            get
            {
                return context.Genres;
            }
        }

        public void Save(Genre genre)
        {

        }
    }
}
