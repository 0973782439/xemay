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
    public class QuanLyDanhMucController : Controller   
    {
        // GET: Admin/QuanLyDanhMuc
        WebXeMayEntities objWebXeMayEntities = new WebXeMayEntities();
        [Route("'tú")]
        public ActionResult HomeCategory()
        {
            if (Session["user"] != null)
            {
                var listCategory = objWebXeMayEntities.Categories.ToList();
                return View(listCategory);
            }
            else
            {
                Response.Redirect("/Home/Index");
            }
            return View();

        }

        // GET: Admin/QuanLyDanhMuc/Details/5
        public ActionResult DetailsCate(int Id)
        {
            var listCate = objWebXeMayEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(listCate);
        }

        // GET: Admin/QuanLyDanhMuc/Create
        public ActionResult CreateCate()
        {
            return View();
        }
        // POST: Admin/QuanLyDanhMuc/Create
        [HttpPost]
        public ActionResult CreateCate(Category objCate)
        {
            try
            {
                objWebXeMayEntities.Categories.Add(objCate);
                objWebXeMayEntities.SaveChanges();
                return RedirectToAction("HomeCategory");
            }
            catch (Exception)
            {
                return RedirectToAction("HomeCategory");
            }
        }

        // GET: Admin/QuanLyDanhMuc/Edit/5
        public ActionResult EditCate(int Id)
        {
            var listCate = objWebXeMayEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(listCate);
        }

        // POST: Admin/QuanLyDanhMuc/Edit/5
        [HttpPost]
        public ActionResult EditCate(int Id, Category objCate)
        {
            try
            {
                // TODO: Add update logic here
                objWebXeMayEntities.Entry(objCate).State = EntityState.Modified;
                objWebXeMayEntities.SaveChanges();
                return RedirectToAction("HomeCategory");

            }
            catch
            {
                return RedirectToAction("HomeCategory");
            }
        }

        // GET: Admin/QuanLyDanhMuc/Delete/5
        public ActionResult DeleteCate(int Id)
        {
            var listCate = objWebXeMayEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(listCate);
        }

        // POST: Admin/QuanLyDanhMuc/Delete/5
        [HttpPost]
        public ActionResult DeleteCate(int Id, Category objCate)
        {
            var listCate = objWebXeMayEntities.Categories.Where(n => n.Id == objCate.Id).FirstOrDefault();
            objWebXeMayEntities.Categories.Remove(listCate);
            objWebXeMayEntities.SaveChanges();
            return RedirectToAction("HomeCategory");
        }
    }
}
