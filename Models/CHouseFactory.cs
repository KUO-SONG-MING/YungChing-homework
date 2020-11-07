using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YungChing.Models
{
    public class CHouseFactory
    {
        永慶房屋Entities db = new 永慶房屋Entities();
        public houseSheet getHouseDetail (string id)
        {
            var q = db.houseSheet.FirstOrDefault(items => items.hId.ToString() == id);
            return q;
        }

    }
}