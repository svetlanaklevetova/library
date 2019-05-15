using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyBooks.Domain.Infrastructure;



namespace MyBooks.Domain.Entities
{
  //  [ModelBinder(typeof(AuthorSummaryModelBinder))]
    public class Author
    {
        [Key]
        [HiddenInput(DisplayValue=false)]
        public int author_id { get; set; }

        [Display(Name="Имя")]
        [Required(ErrorMessage="Введите имя")]
        public string fname { get; set; }

        [Display(Name="Фамилия")]
        [Required(ErrorMessage="Введите фамилию")]
        public string lname { get; set; }

        [HiddenInput(DisplayValue = false)]
        public byte[] imagedata { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string imagemimetype { get; set; }

        [Display(Name="Об авторе")]
        public string biography { get; set; }

        [Display(Name="Дата рождения")]
        [DateValidatorAttributeNotNull(ErrorMessage = "Выберите дату в календаре, поле не может быть пустым")]
        public DateTime? birthdate { get; set; }

        [Display(Name = "Дата смерти")]
        [DateValidatorAttributeNull(ErrorMessage = "Выберите дату в календаре")]
        public DateTime? deathdate { get; set; }


        public virtual ICollection<Book> Books { get; set; }

      

    }
}
