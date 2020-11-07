using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YungChing.Models
{
    public class CMember
    {
        public int uId { get; set; }
        [Display(Name = "暱稱")]
        [Required]
        public string uName { get; set; }
        [Display(Name = "電子郵件(帳號)")]
        [Required]
        public string uEmail { get; set; }
        [Display(Name = "密碼")]
        [Required]
        public string uPassword { get; set; }
        public string uAddress { get; set; }
        public Nullable<int> uAge { get; set; }
        public string uGender { get; set; }
        [Display(Name = "密碼確認")]
        [Compare("uPassword")]
        public string confirmPW { get; set; }
        public HttpPostedFileBase image { get; set; }
        public string uPhoto { get; set; }
    }
}