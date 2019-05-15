using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.SqlServer.Management.Smo;
using System.ComponentModel.DataAnnotations;

namespace MyBooks.Domain.Entities
{
    public class Book:  IEqualityComparer<Book>
    {
        [Key]
    
        public int book_id { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public int author_id { get; set; }

        [Display(Name="Жанр")]
        public int genre_id { get; set; }

        //[Display(Name = "Издательство")]
        //public int phouse_id { get; set; }

        [Display(Name="Название")]
        public string name { get; set; }

        [Display(Name = "Год")]
        public int year { get; set; }

        public virtual Author author { get; set; }
        public virtual Genre genre { get; set; }
         

        public virtual ICollection<CommonBook> CommonBooks { get; set; }

        public Book()
        {
            CommonBooks = new List<CommonBook>();
        }

        public bool Equals(Book x, Book y)
        { 
            if (Object.ReferenceEquals(x, y)) return true;
 
            return x != null && y != null && x.book_id.Equals(y.book_id) && x.name.Equals(y.name);
        }

        public int GetHashCode(Book obj)
        {
            return obj.name.Length ^ obj.book_id;
        }

       // public virtual Publisher phouse { get; set; }


    }
}
