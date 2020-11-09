using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChing.Models;

namespace YungChing.Controllers
{
    public class Edit2Controller : Controller
    {
        // GET: Edit2
        永慶房屋Entities db = new 永慶房屋Entities();
        public ActionResult EditMember()
        {
            int uid = Convert.ToInt32(Session["uid"]);
            memberSheet MS = db.memberSheet.FirstOrDefault(items => items.uId == uid);

            return View(MS);
        }

        [HttpPost]
        public ActionResult EditMember(CMember changes)
        {

            memberSheet oldData = db.memberSheet.FirstOrDefault(items => items.uId == changes.uId);
            if (changes.image != null)
            {
                string photoName = Guid.NewGuid().ToString();
                photoName += Path.GetExtension(changes.image.FileName);
                changes.image.SaveAs(Server.MapPath("~/Content/" + photoName));
                changes.uPhoto = "../Content/" + photoName;
                oldData.uPhoto = changes.uPhoto;
                Session["uphoto"] = changes.uPhoto;
            }

            oldData.uName = changes.uName;
            oldData.uAddress = changes.uAddress;
            db.SaveChanges();
            return RedirectToAction("mainPage","Main");

        }
    }
}