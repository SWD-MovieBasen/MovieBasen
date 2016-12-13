using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieBasen.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace MovieBasenTestProject
{
    [TestClass]
    public class UnitTest1
    {

        Movie movie = new Movie(); //Instance of the movie class

        [TestMethod]
        public void TypeMovieNameFailTest() //Type empty movie name
        {
            movie.Name = ""; //Movie name is an empty string
            if (movie.Name == string.Empty) //If movie name is empty, then throw exception (The test will fail)
            {
                throw new Exception("Movie name can't be empty");
            }

        }

        [TestMethod]
        public void TypeMovieNameSucceed()
        {
            movie.Name = "Jack the Giantslayer";
            if (movie.Name == string.Empty) //Same condition as above, but passes because the movie name isn't empty
            {
                throw new Exception("Movie name can't be empty");

            }

        }

        [TestMethod]
        public void TypeMovieYearFail()
        {
            movie.Year = "19000"; //Movie year set to year 19.000
            if (movie.Year.Length != 4) //Checks the length of the movie year (Year can't be more than 4 chars)
            {
                throw new Exception("Movie year can't be more than 4 chars");
            }
        }

        [TestMethod]
        public void TypeMovieYearFail2()
        {
            movie.Year = "1240";
            StringAssert.StartsWith(movie.Year, "19"); //Movie Year has to start with 19__

        }

        [TestMethod]
        public void TypeMovieYearFail3()
        {
            movie.Year = "2040";
            StringAssert.StartsWith(movie.Year, "201"); //Movie Year has to be between 2010 and 2019!

        }

        [TestMethod]
        public void TypeMovieYearPass() //Test passes
        {
            movie.Year = "2010";
            StringAssert.StartsWith(movie.Year, "201"); //Movie Year has to be between 2010 and 2019!

        }
    }
}

