using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using System.Data.Entity;
namespace MvcApplication3.Controllers
{
    public class IlacController : Controller
    {
   

        public ActionResult IlacListele()
        {
            UsersContext context = new UsersContext();
            List<Ilac> ilaclarım = new List<Ilac>();
            ilaclarım = context.Ilacs.ToList();
            return View(ilaclarım);
            
        }
        
        public ActionResult IlacEkle()
        {
        
            return View();
        }
        [HttpPost]
        public ActionResult IlacEkle(Ilac newIlac)
        {
            Ilac ilacım = new Ilac { adi = newIlac.adi, stokAdedi = newIlac.stokAdedi, turu = newIlac.turu };
            UsersContext context = new UsersContext();
            context.Ilacs.Add(ilacım);
            context.SaveChanges();
            return RedirectToAction("IlacListele");
           
        }
        public ActionResult IlacDuzenle(int id)
        {
            Ilac ilacim = new Ilac();
            UsersContext context = new UsersContext();
            context.Ilacs.FirstOrDefault(i=>i.id==id);
            return View(ilacim);
        }
         [HttpPost]
        public ActionResult IlacDuzenle(int id, Ilac duzenlenenIlac)
        {
           
            UsersContext context = new UsersContext();
            Ilac ilacim = context.Ilacs.FirstOrDefault(i => i.id == id);
            ilacim.adi = duzenlenenIlac.adi;
            ilacim.turu = duzenlenenIlac.turu;
            ilacim.stokAdedi = duzenlenenIlac.stokAdedi;
            context.SaveChanges();
            return RedirectToAction("IlacListele");
        }
         public ActionResult IlacSil(int id)
         {
             UsersContext context = new UsersContext();
             Ilac ilacim = context.Ilacs.FirstOrDefault(i => i.id == id);
             return View(ilacim);
         }
        [HttpPost]
         public ActionResult IlacSilPost(int id)
         {
             UsersContext context = new UsersContext();
             Ilac ilacim = context.Ilacs.FirstOrDefault(i => i.id == id);
             context.Ilacs.Remove(ilacim);
             context.SaveChanges();
             return RedirectToAction("IlacListele");
         }
        

    }
}
