
using prima.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prima.Controllers
{
    public class PanouSolarController : Controller
    {
        private ApplicationDbContext _context;
        public PanouSolarController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: PanouSolar
        public ActionResult PanouriSolare()
        {
            var panou = _context.PanouSolar;
            return View(panou);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public ActionResult New()
        {
            PanouSolar panou = new PanouSolar();
            return View(panou);
        }

        [HttpPost]
        public ActionResult New(PanouSolar panouNou)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.PanouSolar.Add(panouNou);
                    //imagine
                    string fileName = Path.GetFileNameWithoutExtension(panouNou.ImageFile.FileName);
                    string extension = Path.GetExtension(panouNou.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    panouNou.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    panouNou.ImageFile.SaveAs(fileName);
                    //arie+randament+initializare raport performanta
                    panouNou.AriePanou = panouNou.Latime * panouNou.Inaltime;
                    panouNou.RandamentPanou = (panouNou.PutereMaxima / (panouNou.AriePanou * 0.001)) * 100;
                    panouNou.RaportPerformantaPanou = 100;
                    _context.SaveChanges();
                    return RedirectToAction("PanouriSolare");
                }
                return View(panouNou);
            }
            catch (Exception e)
            {
                return View(panouNou);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                PanouSolar panou = _context.PanouSolar.Find(id);
                if (panou == null)
                {
                    return HttpNotFound("Nu s-a gasit panoul cu id-ul: " + id.ToString());
                }
                return View(panou);
            }
            else return HttpNotFound("Nu s-a gasit Id-ul !");
        }

        [HttpPut]
        public ActionResult Edit(int PanouId, PanouSolar panouNou)
        {
            try
            {
                int updateImagine = 0;
                if (panouNou.ImageFile != null)
                {
                    updateImagine = 1;
                    string fileName = Path.GetFileNameWithoutExtension(panouNou.ImageFile.FileName);
                    string extension = Path.GetExtension(panouNou.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    panouNou.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    panouNou.ImageFile.SaveAs(fileName);

                }
                if (ModelState.IsValid)
                {
                    PanouSolar panou = _context.PanouSolar
                    .SingleOrDefault(b => b.PanouId.Equals(PanouId));
                    if (TryUpdateModel(panou))
                    {
                        panou.NumePanou = panouNou.NumePanou;
                        panou.Latime = panouNou.Latime;
                        panou.Inaltime = panouNou.Inaltime;
                        panou.AriePanou = panouNou.Latime * panouNou.Inaltime/1000000;
                        panou.PutereMaxima = panouNou.PutereMaxima;
                        panou.RandamentPanou = panouNou.PutereMaxima / (panou.AriePanou * 1000) * 100;
                        if (updateImagine == 1)
                        {
                            panou.ImageFile = panouNou.ImageFile;
                            panou.ImagePath = panouNou.ImagePath;
                        }
                        _context.SaveChanges();
                    }
                    return RedirectToAction("PanouriSolare");
                }
                return View(panouNou);
            }
            catch (Exception e)
            {
                return View(panouNou);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            PanouSolar panou = _context.PanouSolar.Find(id);
            if (panou != null)
            {
                _context.PanouSolar.Remove(panou);
                _context.SaveChanges();
                return RedirectToAction("PanouriSolare");
            }
            return HttpNotFound("Couldn't find the book with id " + id.ToString());
        }

    }
}

  
