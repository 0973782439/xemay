using Đồ_án_3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_3.Areas.Admin.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        // GET: Admin/QuanLySanPham
        WebXeMayEntities objWebXeMayEntities = new WebXeMayEntities();

        public ActionResult HomeProduct(string SearchString)
        {
            if (Session["user"] != null)
            {
                var listProduct = objWebXeMayEntities.Products.Where(n => n.Name.Contains(SearchString)).ToList();
                return View(listProduct);
            }
            else
            {
                Response.Redirect("/Home/Index");
            }
            return View();
        }

        // GET: Admin/QuanLySanPham/Details/5
        public ActionResult Details(int Id)
        {
            var objProduct = objWebXeMayEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }

        // GET: Admin/QuanLySanPham/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuanLySanPham/Create
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            try
            {
            //TODO: Add insert logic here
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    //fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    fileName = fileName + "_" + extension;

                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));
                }
                objWebXeMayEntities.Products.Add(objProduct);
                objWebXeMayEntities.SaveChanges();
                return RedirectToAction("HomeProduct");
            }
            catch(Exception)
            {
                return RedirectToAction("HomeProduct");

            }
        }

        // GET: Admin/QuanLySanPham/Edit/5
        public ActionResult Edit(int Id)
        {
            var listProduct = objWebXeMayEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(listProduct);
        }
        // POST: Admin/QuanLySanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id,Product objProduct)
        {
            try
            {
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    //fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    fileName = fileName + "_" + extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));
                }
                // TODO: Add update logic here
                objWebXeMayEntities.Entry(objProduct).State = EntityState.Modified;
                objWebXeMayEntities.SaveChanges();
                return RedirectToAction("HomeProduct");
            }
            catch
            {
                return RedirectToAction("HomeProduct");
            }
        }
        // GET: Admin/QuanLySanPham/Delete/5
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objProduct = objWebXeMayEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
            //return View();

        }

        // POST: Admin/QuanLySanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, Product objPro)
        {
            var objProduct = objWebXeMayEntities.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWebXeMayEntities.Products.Remove(objProduct);
            objWebXeMayEntities.SaveChanges();
            return RedirectToAction("HomeProduct");
           
        }
    }
}
