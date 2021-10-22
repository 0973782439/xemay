using Đồ_án_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_3.Controllers
{
    public class HomeController : Controller
    {
        WebXeMayEntities objWebXeMayEntities = new WebXeMayEntities();
        public ActionResult Index()
        {
            Category_Product objHomeModel = new Category_Product();
            objHomeModel.ListCategory = objWebXeMayEntities.Categories.ToList();
            objHomeModel.ListProduct = objWebXeMayEntities.Products.ToList();

            //var listProduct =  objWebXeMayEntities.Products.ToList();
            return View(objHomeModel);
        }
        public JsonResult CheckLogin(FormCollection collection)
        {
            string uid = collection["uid"];
            string pass = collection["pass"];
            JsonResult jr = new JsonResult();
            User user = new User();
            List<User> listUser = objWebXeMayEntities.Users.ToList();
            bool check = false;

            for(var i = 0; i < listUser.Count; i++)
            {
                if(listUser[i].Email == uid && listUser[i].PassWord == pass)
                {
                    user = listUser[i];
                    check = true;
                    break;
                }
            }
        if (check == false)
            {
                jr.Data = new
                {
                    status = "F"
                };
            }
            else
            {
                Session["user"] = user;
                Session.Timeout = 60;
                jr.Data = new
                {
                    status = "OK"
                };
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
        public void logout()
        {
            Session["user"] = null;
            Response.Redirect(Request.Url.Scheme + "://" + Request.Url.Authority + "/Home/Index");
        }

    }
   
}