using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChing.Models;

namespace YungChing.Controllers
{
    public class HomeController : Controller
    {
        永慶房屋Entities db = new 永慶房屋Entities();
        public ActionResult signUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signUp(CMember data)
        {
            //說明:資料模型驗證必加判斷式
            if (ModelState.IsValid)
            {
                //說明:使用者有上傳圖片才進入判斷
                if (data.image != null)
                {
                    string photoName = Guid.NewGuid().ToString();
                    photoName += Path.GetExtension(data.image.FileName);
                    data.image.SaveAs(Server.MapPath("~/Content/" + photoName));
                    data.uPhoto = "../Content/" + photoName;
                }

                memberSheet membersheet = new memberSheet();
                membersheet.uName = data.uName;
                membersheet.uEmail = data.uEmail;
                membersheet.uPassword = data.uPassword;
                membersheet.uAddress = data.uAddress;
                membersheet.uAge = data.uAge;
                membersheet.uGender = data.uGender;
                membersheet.uPhoto = data.uPhoto;             
                db.memberSheet.Add(membersheet);
                db.SaveChanges();

                //說明:轉跳到mainPage控制器
                return RedirectToAction("signIn", "Home");
            }

            return View();
        }

        public ActionResult signIn()
        {
            ViewBag.emailWrong = "";
            ViewBag.passwordWrong = "";
            return View();
        }

        [HttpPost]
        public ActionResult signIn(memberSheet data)
        {
            ViewBag.emailWrong = "";
            ViewBag.passwordWrong = "";
            //CMember cmember;
            if (data.uEmail !=null && data.uPassword != null)
            {
                var q1 = from items in db.memberSheet
                         where data.uEmail == items.uEmail
                         select items;
                
                if (!q1.Any())
                {
                    ViewBag.emailWrong = "emailWrong";
                    return View();
                }

                else
                {
                    var q2 = from items in db.memberSheet
                             where data.uEmail == items.uEmail && data.uPassword == items.uPassword
                             select items;
                    if (!q2.Any())
                    {
                        ViewBag.passwordWrong = "passwordWrong";
                        return View();
                    }
            
                    else 
                    {

                       Session["uname"] = q2.FirstOrDefault().uName;
                       Session["uphoto"] = q2.FirstOrDefault().uPhoto;
                       Session["uid"] = q2.FirstOrDefault().uId.ToString();
                       
                       return RedirectToAction("mainPage", "Main");
                    }
                }
            }
            return View();
        }

    }
}