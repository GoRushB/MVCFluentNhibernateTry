using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace real_MVC_fluent_nhibernate_try.Models
{
    public class Product
    {
        public virtual int ProductId { get; protected set; }
        public virtual decimal Price { get; set; }
        public virtual string Name { get; set; }
        public virtual string ProductArtUrl { get; set; }
        public virtual IList<Store> Stores { get; protected set; }

        public Product()
        {
            Stores = new List<Store>();
        }
    }
}