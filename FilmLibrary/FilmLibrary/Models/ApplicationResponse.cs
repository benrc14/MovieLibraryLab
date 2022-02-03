using System;
using System.ComponentModel.DataAnnotations;

namespace FilmLibrary.Models
{
    public class ApplicationResponse
    {
            //[Key]
            // a type for id
            // all the input types from the form and their get and set (use 'prop' tab)
            [Key]
            [Required]
        public int Movie_id { get; set; }
        [Required]
        public string Title { get; set; }
            [Required]
        public int Year { get; set; }
            [Required]
        public string Director { get; set; }
            [Required]
        public string Rating { get; set; }
        //dropdown
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }


        [Required]
        public int CategoryId { get; set; } //Foreign key relationship

        public Category Category { get; set; }
    }
}
