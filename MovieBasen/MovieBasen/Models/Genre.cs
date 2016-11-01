using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBasen.Models
{
    public class Genre
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public virtual ICollection<MovieGenre> MoviesGenres { get; set; }

    }
}