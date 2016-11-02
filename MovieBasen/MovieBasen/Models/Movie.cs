using MovieBasen.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBasen.Models
{
    public class Movie
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public String Year { get; set; }

        public String MovieImagePath { get; set; }

        public void SaveImage(HttpPostedFileBase image, String serverPath, String pathToFile)
        {
            if (image == null) return;

            //ImageModel
            Guid guid = Guid.NewGuid();
            ImageModel.ResizeAndSave(serverPath + pathToFile, guid.ToString(), image.InputStream, 200);

            MovieImagePath = pathToFile + guid.ToString() + ".jpg";
        }

        public virtual ICollection<MovieGenre> MoviesGenres { get; set; }

        //..test...
        public String Description { get; set; }

    }

}