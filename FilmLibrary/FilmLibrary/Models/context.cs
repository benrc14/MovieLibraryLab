using System;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Models
{
    public class Context : DbContext
    {
        //Constructor
        public Context(DbContextOptions<Context>options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<ApplicationResponse> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName="Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Comedy"},
                new Category { CategoryId = 3, CategoryName = "Drama"},
                new Category { CategoryId = 4, CategoryName = "Family"},
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense"},
                new Category { CategoryId = 6, CategoryName = "Miscellaneous"},
                new Category { CategoryId = 7, CategoryName = "Television"},
                new Category { CategoryId = 8, CategoryName = "VHS"}
                );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    Movie_id = 1,
                    CategoryId = 1,
                    Title = "Jojo Rabbit",
                    Year = 2019,
                    Director = "Taika Waititi",
                    Rating = "PG-13",
                },

                new ApplicationResponse
                {
                    Movie_id = 2,
                    CategoryId = 1,
                    Title = "Dune",
                    Year = 2021,
                    Director = "Denis Villenueve",
                    Rating = "PG-13",
                    Edited = false,
                },

                new ApplicationResponse
                {
                    Movie_id = 3,
                    CategoryId = 4,
                    Title = "The Santa Clause",
                    Year = 1994,
                    Director = "John Pasquin",
                    Rating = "PG",
                    Edited = false,
                }
                );
        }
    }
}