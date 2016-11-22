using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieBasen.Models;

namespace MovieBasenUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Movie movie = new Movie();

        [TestMethod]
        public void TypeMovieNameFailTest()
        {
            movie.Name = "";
            if (movie.Name == string.Empty)
            {
                throw new Exception("Movie name can't be empty");
                //Assert.Fail();
            }

        }

        [TestMethod]
        public void TypeMovieNameSucceed()
        {
            movie.Name = "Jack the Giantslayer";
            if (movie.Name == string.Empty)
            {
                throw new Exception("Movie name can't be empty");
                //Assert.Fail();
            }


        }
    }
