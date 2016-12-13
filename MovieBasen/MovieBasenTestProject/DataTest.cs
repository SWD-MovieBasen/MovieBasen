using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace MovieBasenTestProject
{
    [TestClass]
    class DataTest
    {
        private List<string> dbToAdd = new List<string>();
         SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Data Source = (LocalDb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\aspnet-MovieBasen-20161023074225.mdf;Initial Catalog = aspnet - MovieBasen - 20161023074225;"].ConnectionString);
        
        [TestMethod]
        public void DatabaseCon() //Type empty movie name
        {
           string dbToAdd = "movie";
            string db = conn.ConnectionString.ToString();
           var sh= conn.GetSchema();
            if(dbToAdd == db)
            {
                throw new Exception("yes");
            }
            throw new Exception("no");
        }
    }
}
