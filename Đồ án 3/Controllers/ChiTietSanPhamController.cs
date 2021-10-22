using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Đồ_án_3.Models;

namespace Đồ_án_3.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        // GET: ChiTietSanPham
        WebXeMayEntities objWebXeMayEntities = new WebXeMayEntities();
        public ActionResult WaveCT(string Id)
        {
            //var listProduct = objWebXeMayEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            Category_Product objHomeModel = new Category_Product();
            objHomeModel.ListCategory = objWebXeMayEntities.Categories.ToList();
            //objHomeModel.ListProduct = objWebXeMayEntities.Products.Where(n => n.Id == Id).ToList();
            objHomeModel.ListProduct = objWebXeMayEntities.Products.ToList();
            string[] aray = Id.Split('a');
            objHomeModel.ma = int.Parse(aray[0]);
            objHomeModel.cateId = int.Parse(aray[1]);
            return View(objHomeModel);
        }
    }
}