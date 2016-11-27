using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieBasen.Models
{
    public class Actor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You must fill in a Firstname to the movie.")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "You must fill in a Lastname to the movie.")]
        public String LastName { get; set; }

        [NotMapped]
        public String FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }

            set { }
        }
        [Required(ErrorMessage = "You must fill in the age of the person")]
        [Range(0, 100, ErrorMessage = "It must be between 0 and 100")]
        public int Age { get; set; }

        public virtual ICollection<MovieActor> MoviesActors { get; set; }
    }
}