﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{

    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products {get;set; }
    }



}
