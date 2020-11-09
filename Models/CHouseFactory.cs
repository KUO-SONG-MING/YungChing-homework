using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YungChing.Models
{
    public class CHouseFactory
    {
        永慶房屋Entities db = new 永慶房屋Entities();

        public List<houseSheet> getByKeyword(string key)
        {
            var q = from items in db.houseSheet
                    where items.hName.Contains(key)
                    select items;
            return q.ToList();
        }

        public houseSheet getHouseDetail (string id)
        {
            var q = db.houseSheet.FirstOrDefault(items => items.hId.ToString() == id);
            return q;
        }

    }
}