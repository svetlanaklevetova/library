using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Domain.Abstract
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> Entities { get; }

        void Save(T entity);
    }
}
