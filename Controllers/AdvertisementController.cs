using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChing.Models;

namespace YungChing.Controllers
{
    public class AdvertisementController : Controller
    {
        永慶房屋Entities db = new 永慶房屋Entities();
        public JsonResult ShowAD()
        {
            List<CAD> adList = new List<CAD>();
            var q = from items in db.houseSheet
                    select items;

            foreach (var items in q) 
            {
                CAD cad = new CAD()
                {
                    hId = items.hId,
                    hName = items.hName,
                    hText = items.hText,
                    hPhoto = items.hPhoto
                };
                adList.Add(cad);
            }

            return Json(adList, JsonRequestBehavior.AllowGet); ;
        }
    }
}