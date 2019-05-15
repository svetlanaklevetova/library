using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Domain.Abstract;
using MyBooks.Domain.Entities;

namespace MyBooks.Domain.Concrete
{
    public class EFPublisherRepository: IRepository<Publisher>
    {
        private EFDbContext context = new EFDbContext().ObjectContext;

        public IEnumerable<Publisher> Entities
        {
            get
            {
                return context.Publishers;

            }
        }

        public void Save(Publisher entity)
        { }
    }
}
