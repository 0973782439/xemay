using Đồ_án_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
namespace Đồ_án_3.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        WebXeMayEntities objWebXeMayEntities = new WebXeMayEntities();
        public ActionResult Wave(int Id)
        {
            Category_Product objHomeModel = new Category_Product();
            objHomeModel.ListCategory = objWebXeMayEntities.Categories.ToList();
            objHomeModel.ListProduct = objWebXeMayEntities.Products.Where(n => n.CategoryId == Id).ToList();

            objHomeModel.ma = Id;
            return View(objHomeModel);

            //var listProduct = objWebXeMayEntities.Products.Where(n => n.CategoryId == Id).ToList();
            //return View(listProduct);
        }
        public ActionResult AirBlade()
        {
            return View();
        }
    }
}