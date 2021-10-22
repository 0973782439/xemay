using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Đồ_án_3.Models
{
    public class Category_Product
    {
        public List<Product> ListProduct { get; set;}
        public List<Category> ListCategory { get; set; }
        public int ma { get; set; }
        public int cateId { get; set; }

    }
}