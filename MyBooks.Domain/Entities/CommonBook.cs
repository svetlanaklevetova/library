using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MyBooks.Domain.Entities

{

    public partial class CommonBook
    {
        [Key]
        public int common_book_id { get; set; }

        [Required(ErrorMessage="Название не может быть пустым")]
        [Display(Name="Название")]
        public string common_book_name { get; set; }

        [Display(Name = "Издательство")]
        public int phouse_id { get; set; }

        [Display(Name="Год")]
        public int year { get; set; }

        [HiddenInput(DisplayValue = false)]
        public byte[] imagedata { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string imagemimetype { get; set; }

        public virtual Publisher phouse { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public CommonBook()
        {
            Books = new List<Book>();
        }
    }
}
