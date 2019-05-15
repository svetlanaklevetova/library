using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyBooks.Domain.Entities
{
    public class Genre
    {
        [Key]
        public int genre_id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
