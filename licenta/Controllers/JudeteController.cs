using prima.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prima.Controllers
{
    public class JudeteController : Controller
    {
        private ApplicationDbContext _context;
   

        public  JudeteController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Judete
        
        public ActionResult Index(int? eroare)
        {
            if (eroare == 1)
            {
                ViewBag.eroare = "1";
            }
            ViewBag.judete = _context.Judete.ToList();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult NewJudet()
        {
            Judet judet = new Judet();
            return View(judet);
        }

        [HttpPost]
        public ActionResult NewJudet(Judet judetNou)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Judete.Add(judetNou);
                    //Salvam imaginea 
                    string fileName = Path.GetFileNameWithoutExtension(judetNou.ImageFile.FileName);
                    string extension = Path.GetExtension(judetNou.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    judetNou.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    judetNou.ImageFile.SaveAs(fileName);
                    judetNou.RadiatieSolara = judetNou.RadiatieSolaraIanuarie + judetNou.RadiatieSolaraFebruarie + judetNou.RadiatieSolaraMartie + judetNou.RadiatieSolaraAprilie + judetNou.RadiatieSolaraMai + judetNou.RadiatieSolaraIunie + judetNou.RadiatieSolaraIulie + judetNou.RadiatieSolaraAugust + judetNou.RadiatieSolaraSeptembrie + judetNou.RadiatieSolaraOctombrie + judetNou.RadiatieSolaraNoiembrie + judetNou.RadiatieSolaraDecembrie;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(judetNou);
            }
            catch (Exception e)
            {
                return View(judetNou);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditJudet (Calcule calcul)
        {
            int id = calcul.JudetId;
            if (id!=null)
            {
                Judet judet = _context.Judete.Find(id);
                if (judet == null)
                {
                    return HttpNotFound("Nu s-a gasit judetul cu id-ul: " + id.ToString());
                }
                return View(judet);
            }
            else return HttpNotFound("Nu s-a gasit Id-ul !");
        }

        [HttpPut]
        public ActionResult EditJudet (Calcule calcul, Judet judetNou)
        {
            try
            {
                int updateImagine = 0;
                if (judetNou.ImageFile != null)
                {
                    updateImagine = 1;
                    string fileName = Path.GetFileNameWithoutExtension(judetNou.ImageFile.FileName);
                    string extension = Path.GetExtension(judetNou.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    judetNou.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    judetNou.ImageFile.SaveAs(fileName);

                }

                if (ModelState.IsValid)
                {
                    Judet judet = _context.Judete
                    .SingleOrDefault(b => b.JudetId.Equals(calcul.JudetId));
                    if (TryUpdateModel(judet))
                    {
                        judet.Nume = judetNou.Nume;
                        judet.RadiatieSolaraIanuarie = judetNou.RadiatieSolaraIanuarie;
                        judet.RadiatieSolaraFebruarie = judetNou.RadiatieSolaraFebruarie;
                        judet.RadiatieSolaraMartie = judetNou.RadiatieSolaraMartie;
                        judet.RadiatieSolaraAprilie = judetNou.RadiatieSolaraAprilie;
                        judet.RadiatieSolaraMai = judetNou.RadiatieSolaraMai;
                        judet.RadiatieSolaraIunie = judetNou.RadiatieSolaraIunie;
                        judet.RadiatieSolaraIulie = judetNou.RadiatieSolaraIulie;
                        judet.RadiatieSolaraAugust = judetNou.RadiatieSolaraAugust;
                        judet.RadiatieSolaraSeptembrie = judetNou.RadiatieSolaraSeptembrie;
                        judet.RadiatieSolaraOctombrie = judetNou.RadiatieSolaraOctombrie;
                        judet.RadiatieSolaraNoiembrie = judetNou.RadiatieSolaraNoiembrie;
                        judet.RadiatieSolaraDecembrie = judetNou.RadiatieSolaraDecembrie;
                        judet.TemperaturaMedieIanuarie = judetNou.TemperaturaMedieIanuarie;
                        judet.TemperaturaMedieFebruarie = judetNou.TemperaturaMedieFebruarie;
                        judet.TemperaturaMedieMartie = judetNou.TemperaturaMedieMartie;
                        judet.TemperaturaMedieAprilie = judetNou.TemperaturaMedieAprilie;
                        judet.TemperaturaMedieMai = judetNou.TemperaturaMedieMai;
                        judet.TemperaturaMedieIunie = judetNou.TemperaturaMedieIunie;
                        judet.TemperaturaMedieIulie = judetNou.TemperaturaMedieIulie;
                        judet.TemperaturaMedieAugust = judetNou.TemperaturaMedieAugust;
                        judet.TemperaturaMedieSeptembrie = judetNou.TemperaturaMedieSeptembrie;
                        judet.TemperaturaMedieOctombrie = judetNou.TemperaturaMedieOctombrie;
                        judet.TemperaturaMedieNoiembrie = judetNou.TemperaturaMedieNoiembrie;
                        judet.TemperaturaMedieDecembrie = judetNou.TemperaturaMedieDecembrie;
                        judet.RadiatieSolara = judetNou.RadiatieSolaraIanuarie + judetNou.RadiatieSolaraFebruarie + judetNou.RadiatieSolaraMartie + judetNou.RadiatieSolaraAprilie + judetNou.RadiatieSolaraMai + judetNou.RadiatieSolaraIunie + judetNou.RadiatieSolaraIulie + judetNou.RadiatieSolaraAugust + judetNou.RadiatieSolaraSeptembrie + judetNou.RadiatieSolaraOctombrie + judetNou.RadiatieSolaraNoiembrie + judetNou.RadiatieSolaraDecembrie;
                        if (updateImagine == 1)
                        {
                            judet.ImageFile = judetNou.ImageFile;
                            judet.ImagePath = judetNou.ImagePath;
                        }
                        _context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(judetNou);
            }
            catch (Exception e)
            {
                return View(judetNou);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult Delete(Calcule calcul)
        {
            Judet judet = _context.Judete.Find(calcul.JudetId);
            if (judet != null)
            {
                _context.Judete.Remove(judet);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the book with id " + calcul.JudetId.ToString());
        }

    }
}
    

