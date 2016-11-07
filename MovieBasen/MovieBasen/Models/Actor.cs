using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieBasen.Models
{
    public class Actor
    {
        public int ID { get; set; }

        public String FirstName { get; set; }

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

        public int Age { get; set; }

        public virtual ICollection<MovieActor> MoviesActors { get; set; }
    }
}