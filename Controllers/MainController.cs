using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChing.Models;

namespace YungChing.Controllers
{
    public class MainController : Controller
    {
        永慶房屋Entities db = new 永慶房屋Entities();
        public ActionResult mainPage()
        {
            if (Session["uid"] != null)
            {
                List<houseSheet> houseList = new List<houseSheet>();
                var q = from items in db.houseSheet
                        select items;
                houseList = q.ToList();
                return View(houseList);
            }

            else 
            {
                return RedirectToAction("signIn", "Home");
            }
        }
    }
}