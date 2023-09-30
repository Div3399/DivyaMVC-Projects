using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
    }

    public class checkProduct
    {
        public List<Product> Data { get; set; }

        public bool status { get; set; }

        public string message { get; set; }


    }


    public class checkAddProduct
    {
        public string ProductId { get; set; }

        public bool status { get; set; }

        public string message { get; set; }

    }


}