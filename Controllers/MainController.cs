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

        public ActionResult logOut() 
        {
            Session["uname"] = null;
            Session["uphoto"] = null;
            Session["uid"] = null;
            return RedirectToAction("signIn", "Home");
        }

        public ActionResult deleteList(string id) 
        {
            CLike D = new CLike();
            D.delete(id);

            return RedirectToAction("myList");
        }

        public ActionResult myList()
        {
            int uid = Convert.ToInt32(Session["uid"]);
            List<houseSheet> myListList = new CLike().mylist(uid);

            return View(myListList);
        }

        public ActionResult likeList(string hid)
        {
            int uid = Convert.ToInt32(Session["uid"]);
            string result = (new CLike()).likeFactory(hid, uid);
            
            Session["result"] = result;

            return RedirectToAction("mainPage");
        }
         
        public ActionResult detail(string id) 
        {
            houseSheet detail = new houseSheet();
            detail = (new CHouseFactory()).getHouseDetail(id);
            return View(detail);
        }

        public ActionResult mainPage()
        {
            string key = Request.Form["keyword"];
            List<houseSheet> houseList = new List<houseSheet>();
            if (Session["uid"] != null)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    houseList = new CHouseFactory().getByKeyword(key);
                    return View(houseList);

                }
                else
                {
                    var q = from items in db.houseSheet
                            select items;
                    houseList = q.ToList();
                    return View(houseList);
                }
            }

            else 
            {
                return RedirectToAction("signIn", "Home");
            }
        }
    }
}