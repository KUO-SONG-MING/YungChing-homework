using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YungChing.Models;

namespace YungChing.Models
{
    public class CLike
    {
        永慶房屋Entities db = new 永慶房屋Entities();

        public void delete(string id) 
        {
            var q = db.likeSheet.FirstOrDefault(d => d.houseID.ToString() == id);
            if(q != null) 
            {
                db.likeSheet.Remove(q);
                db.SaveChanges();
            };
        }

        public List<houseSheet> mylist(int uid) 
        {
            List<houseSheet> mylistlist = new List<houseSheet>();
            
            var q = from items in db.likeSheet
                    where uid == items.userID
                    select items;

            foreach (var data in q)
            {
                var x = from items in db.houseSheet
                        where data.houseID == items.hId
                        select items;

                houseSheet hs = new houseSheet();
                hs.hId = x.FirstOrDefault().hId;
                hs.hName = x.FirstOrDefault().hName;
                hs.hText = x.FirstOrDefault().hText;
                hs.hPhoto = x.FirstOrDefault().hPhoto;
                mylistlist.Add(hs);
            }

            return mylistlist;
        }

        public string likeFactory(string hid, int uid) 
        {
            var q = from items in db.likeSheet
                    where hid == items.houseID.ToString() && uid == items.userID
                    select items;

            if (q.Any())
            {
                return "no";
            }

            else
            {
                likeSheet like = new likeSheet()
                {
                    userID = uid,
                    houseID = Convert.ToInt32(hid)
                };
                db.likeSheet.Add(like);
                db.SaveChanges();
                return "ok";
            }
        }

    }
}