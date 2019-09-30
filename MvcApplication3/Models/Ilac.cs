using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MvcApplication3.Models
{
    public class Ilac
    {
        public int id { get; set; }
        public string adi { get; set; }
        public string turu { get; set; }
        public int stokAdedi { get; set; }
    }
}