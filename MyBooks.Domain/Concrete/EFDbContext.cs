using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Domain.Entities;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace MyBooks.Domain.Concrete
{
    public class EFDbContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<CommonBook> CommonBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommonBook>().HasMany(c => c.Books)
                .WithMany(s => s.CommonBooks)
                .Map(t => t.MapLeftKey("common_book_id")
                    .MapRightKey("book_id")
                    .ToTable("BookCommonBooks"));



        }

        public EFDbContext ObjectContext
        {
            get
            {
                string ocKey = "ocm_" + HttpContext.Current.GetHashCode().ToString("x");
                if (!HttpContext.Current.Items.Contains(ocKey))
                    HttpContext.Current.Items.Add(ocKey, new EFDbContext());
                return HttpContext.Current.Items[ocKey] as EFDbContext;
            }
        }
    }
}
