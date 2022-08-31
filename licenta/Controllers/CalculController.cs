using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prima.Models;

namespace prima.Controllers
{
    public class CalculController : Controller
    {
        private ApplicationDbContext _context;
        public CalculController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

           
            public ActionResult SelectJudet(Judet judet)
        {
            if (judet.JudetId != 0)
            {
                int id = judet.JudetId;
                Calcule calcul = new Calcule();
                calcul.JudetId = id;
                ViewBag.panouri = _context.PanouSolar;
                ViewBag.IdJudet = calcul.JudetId;
                ViewBag.IdCalcul = calcul.Id;
                ViewBag.judet = _context.Judete.Find(id);
                return View(calcul);
            }
            else
            {
                 
                return RedirectToAction("Index", "Judete", new { eroare = 1 });
            }

        }
        public ActionResult Panouri(Calcule calcul)
        {
            ViewBag.panouri = _context.PanouSolar;
            
            return View(calcul);
        }
        public ActionResult SelectPanou(int id, Calcule calcul)
        {
            ViewBag.IdJudet = calcul.JudetId;
            calcul.PanouId = id;
            return View(calcul);
        }
        public ActionResult CalculatorDeCatePanouriEsteNevoie(Calcule calcul)
        {

            return View(calcul);
        }
        public ActionResult CalculatorCataEnergieProduceAcoperisul(Calcule calcul)
        {
            return View(calcul);
        }
        public ActionResult CalculeazaPanouri(Calcule calcul)
        {
            Judet judetselectat = _context.Judete.Find(calcul.JudetId);
            PanouSolar panousolarselectat = _context.PanouSolar.Find(calcul.PanouId);


            double rezultat = 0; 
            double CostTotal = 0;
            int i = 0;
            double procentaj = 0; // cu cate procente va fi  mai mare energie calculata fata de cea pe care o da utilizatorul
            double ArieNecesara = 0; // de ce arie va avea nevoie utilizatorul
            double pierdereTemp = 0; // pentru temperaturi
            double EnergieIan = 0;
            double EnergieFeb = 0;
            double EnergieMar = 0;
            double EnergieApr = 0;
            double EnergieMai = 0;
            double EnergieIun = 0;
            double EnergieIul = 0;
            double EnergieAug = 0;
            double EnergieSep = 0;
            double EnergieOct = 0;
            double EnergieNoi = 0;
            double EnergieDec = 0;
            double EnergieTotala = 0;
            int unghioptim = 37; // unghiul optim este de 37 de grade in Romania
            int pierderedepentruunghi = 0; // pentru fiecare 5 grade deviate de la unghiul optim se vor pierde 0,76% wati
            double procentpierdereunghi = 0; // procentul de pierdere al unghiurilor
            int PierderiInvertor = 5; // pierderi din eficienta invertorului in %
            int PierderiMurdarie = 5;  //pierderi prin murdarie (praf si alte tipuri de murdarie care apar in timp) in %
            int PierderiCabluCurentContinuu = 1; // poate aparea o mica scadere de tensiune intre sistemul de panouri solare si invertor cauzate de cabluri (in %)
            int PierderiCabluCurentAlternativ = 1; // si in conexiunea dintre  invertor si tablourile de electricitate pot aparea mici scaderi ale tensiunii ducand la o mica pierdere in eficienta (in %)
            int TolerantaProducatorului = 3; // majoritatea panoruilor solare au o toleranta de 3%
            int PierderiOptice = 8;
            double coeficienttemperatura = 0.5; // panourile solare au un coeficient de temperatura de aproximativ 0.4 pana la 0.5%; deci pentru feicare grad celsius peste 25 puterea de iesire ar scadea cu acel procent. Am ales o medie la 0.45%
            if (calcul.Unghi == unghioptim)
            {
                procentpierdereunghi = 0;
            }
            else
            {
                if (calcul.Unghi < unghioptim)
                {
                    pierderedepentruunghi = (int)((unghioptim - calcul.Unghi) / 5);
                    procentpierdereunghi = pierderedepentruunghi * 0.76;
                }
                else
                {
                    pierderedepentruunghi = (int)((calcul.Unghi - unghioptim) / 5);
                    procentpierdereunghi = pierderedepentruunghi * 0.76;
                }
            }

            panousolarselectat.RaportPerformantaPanou = (panousolarselectat.RaportPerformantaPanou - procentpierdereunghi - PierderiInvertor - PierderiMurdarie - PierderiCabluCurentContinuu 
                                                        - PierderiCabluCurentAlternativ - TolerantaProducatorului - PierderiOptice) / 100;                                                     // /100 pentru a nu fi in procente


            if (judetselectat.TemperaturaMedieIanuarie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieIanuarie - 25) * coeficienttemperatura;
                double raportPerformantaIan = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieIan = judetselectat.RadiatieSolaraIanuarie * panousolarselectat.AriePanou * raportPerformantaIan * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieIan = judetselectat.RadiatieSolaraIanuarie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieFebruarie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieFebruarie - 25) * coeficienttemperatura;
                double raportPerformantaFeb = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieFeb = judetselectat.RadiatieSolaraFebruarie * panousolarselectat.AriePanou * raportPerformantaFeb * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieFeb = judetselectat.RadiatieSolaraFebruarie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieMartie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieMartie - 25) * coeficienttemperatura;
                double raportPerformantaMar = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieMar = judetselectat.RadiatieSolaraMartie * panousolarselectat.AriePanou * raportPerformantaMar * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieMar = judetselectat.RadiatieSolaraMartie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieAprilie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieAprilie - 25) * coeficienttemperatura;
                double raportPerformantaApr = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieApr = judetselectat.RadiatieSolaraAprilie * panousolarselectat.AriePanou * raportPerformantaApr * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieApr = judetselectat.RadiatieSolaraAprilie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieMai > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieMai - 25) * coeficienttemperatura;
                double raportPerformantaMai = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieMai = judetselectat.RadiatieSolaraMai * panousolarselectat.AriePanou * raportPerformantaMai * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieMai = judetselectat.RadiatieSolaraMai * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieIunie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieIunie - 25) * coeficienttemperatura;
                double raportPerformantaIun = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieIun = judetselectat.RadiatieSolaraIunie * panousolarselectat.AriePanou * raportPerformantaIun * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieIun = judetselectat.RadiatieSolaraIunie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieIulie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieIulie - 25) * coeficienttemperatura;
                double raportPerformantaIul = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieIul = judetselectat.RadiatieSolaraIulie * panousolarselectat.AriePanou * raportPerformantaIul * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieIul = judetselectat.RadiatieSolaraIulie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieAugust > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieAugust - 25) * coeficienttemperatura;
                double raportPerformantaAug = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieAug = judetselectat.RadiatieSolaraAugust * panousolarselectat.AriePanou * raportPerformantaAug * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieAug = judetselectat.RadiatieSolaraAugust * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieSeptembrie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieSeptembrie - 25) * coeficienttemperatura;
                double raportPerformantaSep = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieSep = judetselectat.RadiatieSolaraSeptembrie * panousolarselectat.AriePanou * raportPerformantaSep * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieSep = judetselectat.RadiatieSolaraSeptembrie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieOctombrie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieOctombrie - 25) - coeficienttemperatura;
                double raportPerformantaOct = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieOct = judetselectat.RadiatieSolaraOctombrie * panousolarselectat.AriePanou * raportPerformantaOct * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieOct = judetselectat.RadiatieSolaraOctombrie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieNoiembrie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieNoiembrie - 25) * coeficienttemperatura;
                double raportPerformantaNoi = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieNoi = judetselectat.RadiatieSolaraNoiembrie * panousolarselectat.AriePanou * raportPerformantaNoi * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieNoi = judetselectat.RadiatieSolaraNoiembrie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieDecembrie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieDecembrie - 25) * coeficienttemperatura;
                double raportPerformantaDec = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieDec = judetselectat.RadiatieSolaraDecembrie * panousolarselectat.AriePanou * raportPerformantaDec * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieDec = judetselectat.RadiatieSolaraDecembrie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }
            
            EnergieTotala = EnergieIan + EnergieFeb + EnergieMar + EnergieApr + EnergieMai + EnergieIun + EnergieIul + EnergieAug + EnergieSep + EnergieOct + EnergieNoi + EnergieDec;

            while (rezultat < calcul.EnergieNecesara)
            {
                rezultat = rezultat + EnergieTotala;
                CostTotal = CostTotal + panousolarselectat.CostPanou;
                ArieNecesara = ArieNecesara + panousolarselectat.AriePanou;
                i++;
            }

            procentaj = ((rezultat - calcul.EnergieNecesara) / calcul.EnergieNecesara * 100);
            procentaj = Convert.ToDouble(String.Format("{0:0.00}", procentaj)); // doua zecimale
            ArieNecesara = Convert.ToDouble(String.Format("{0:0.00}", ArieNecesara));
            rezultat = Convert.ToDouble(String.Format("{0:0.00}", rezultat));
           

            ViewBag.NumarPanouri = i;
            ViewBag.CostTotal = CostTotal;
            ViewBag.Rezultat = rezultat;
            ViewBag.Procentaj = procentaj;
            ViewBag.ArieNecesara = ArieNecesara;
            ViewBag.Locatie = judetselectat.Nume;
            ViewBag.EnergieNecesara = calcul.EnergieNecesara;
            ViewBag.Unghi = calcul.Unghi;

            return View();
        }
        public ActionResult CalculeazaPutereAcoperis(Calcule calcul)
        {
            Judet judetselectat = _context.Judete.Find(calcul.JudetId);
            PanouSolar panousolarselectat = _context.PanouSolar.Find(calcul.PanouId);


            double rezultat = 0;
            double CostTotal = 0;
            int i = 0;
            double procentaj = 0; // cu cate procente va fi  mai mare energie calculata fata de cea pe care o da utilizatorul
            double ArieNecesara = 0; // de ce arie va avea nevoie utilizatorul
            double pierdereTemp = 0; // pentru temperaturi
            double EnergieIan = 0;
            double EnergieFeb = 0;
            double EnergieMar = 0;
            double EnergieApr = 0;
            double EnergieMai = 0;
            double EnergieIun = 0;
            double EnergieIul = 0;
            double EnergieAug = 0;
            double EnergieSep = 0;
            double EnergieOct = 0;
            double EnergieNoi = 0;
            double EnergieDec = 0;
            double EnergieTotala = 0;
            int unghioptim = 37; // unghiul optim este de 37 de grade in Romania
            int pierderedepentruunghi = 0; // pentru fiecare 5 grade deviate de la unghiul optim se vor pierde 0,76% wati
            double procentpierdereunghi = 0; // procentul de pierdere al unghiurilor
            int PierderiInvertor = 5; // pierderi din eficienta invertorului in %
            int PierderiMurdarie = 5;  //pierderi prin murdarie (praf si alte tipuri de murdarie care apar in timp) in %
            int PierderiCabluCurentContinuu = 1; // poate aparea o mica scadere de tensiune intre sistemul de panouri solare si invertor cauzate de cabluri (in %)
            int PierderiCabluCurentAlternativ = 1; // si in conexiunea dintre  invertor si tablourile de electricitate pot aparea mici scaderi ale tensiunii ducand la o mica pierdere in eficienta (in %)
            int TolerantaProducatorului = 3; // majoritatea panoruilor solare au o toleranta de 3%
            int PierderiOptice = 8;
            double coeficienttemperatura = 0.5; // panourile solare au un coeficient de temperatura de aproximativ 0.4 pana la 0.5%; deci pentru feicare grad celsius peste 25 puterea de iesire ar scadea cu acel procent.
            
            if (calcul.Unghi == unghioptim)
            {
                procentpierdereunghi = 0;
            }
            else
            {
                if (calcul.Unghi < unghioptim)
                {
                    pierderedepentruunghi = (int)((unghioptim - calcul.Unghi) / 5);
                    procentpierdereunghi = pierderedepentruunghi * 0.76;
                }
                else
                {
                    pierderedepentruunghi = (int)((calcul.Unghi - unghioptim) / 5);
                    procentpierdereunghi = pierderedepentruunghi * 0.76;
                }
            }


            panousolarselectat.RaportPerformantaPanou = (panousolarselectat.RaportPerformantaPanou - procentpierdereunghi - PierderiInvertor
                                                         - PierderiMurdarie - PierderiCabluCurentContinuu - PierderiCabluCurentAlternativ - TolerantaProducatorului - PierderiOptice)/100; // /100 pentru a nu fi in procente

            

            if (judetselectat.TemperaturaMedieIanuarie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieIanuarie - 25) * coeficienttemperatura ;
                double raportPerformantaIan = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieIan = judetselectat.RadiatieSolaraIanuarie * panousolarselectat.AriePanou * raportPerformantaIan * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieIan = judetselectat.RadiatieSolaraIanuarie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieFebruarie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieFebruarie - 25) * coeficienttemperatura;
                double raportPerformantaFeb = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieFeb = judetselectat.RadiatieSolaraFebruarie * panousolarselectat.AriePanou * raportPerformantaFeb * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieFeb =  judetselectat.RadiatieSolaraFebruarie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieMartie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieMartie - 25) * coeficienttemperatura;
                double raportPerformantaMar = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100) ;
                EnergieMar = judetselectat.RadiatieSolaraMartie * panousolarselectat.AriePanou * raportPerformantaMar * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieMar = judetselectat.RadiatieSolaraMartie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieAprilie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieAprilie - 25) * coeficienttemperatura;
                double raportPerformantaApr = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieApr = judetselectat.RadiatieSolaraAprilie * panousolarselectat.AriePanou * raportPerformantaApr * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieApr = judetselectat.RadiatieSolaraAprilie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieMai > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieMai - 25) * coeficienttemperatura;
                double raportPerformantaMai = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieMai = judetselectat.RadiatieSolaraMai * panousolarselectat.AriePanou * raportPerformantaMai * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieMai = judetselectat.RadiatieSolaraMai * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieIunie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieIunie - 25) * coeficienttemperatura;
                double raportPerformantaIun = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieIun = judetselectat.RadiatieSolaraIunie * panousolarselectat.AriePanou * raportPerformantaIun * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieIun = judetselectat.RadiatieSolaraIunie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieIulie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieIulie - 25) * coeficienttemperatura;
                double raportPerformantaIul = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieIul = judetselectat.RadiatieSolaraIulie * panousolarselectat.AriePanou * raportPerformantaIul * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieIul = judetselectat.RadiatieSolaraIulie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieAugust > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieAugust - 25) * coeficienttemperatura;
                double raportPerformantaAug = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieAug = judetselectat.RadiatieSolaraAugust * panousolarselectat.AriePanou * raportPerformantaAug * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieAug = judetselectat.RadiatieSolaraAugust * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieSeptembrie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieSeptembrie - 25) * coeficienttemperatura;
                double raportPerformantaSep = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieSep = judetselectat.RadiatieSolaraSeptembrie * panousolarselectat.AriePanou * raportPerformantaSep * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieSep = judetselectat.RadiatieSolaraSeptembrie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieOctombrie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieOctombrie - 25) * coeficienttemperatura;
                double raportPerformantaOct = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieOct = judetselectat.RadiatieSolaraOctombrie * panousolarselectat.AriePanou * raportPerformantaOct * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieOct = judetselectat.RadiatieSolaraOctombrie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieNoiembrie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieNoiembrie - 25) * coeficienttemperatura;
                double raportPerformantaNoi = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieNoi = judetselectat.RadiatieSolaraNoiembrie * panousolarselectat.AriePanou * raportPerformantaNoi * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieNoi = judetselectat.RadiatieSolaraNoiembrie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            if (judetselectat.TemperaturaMedieDecembrie > 25)
            {
                pierdereTemp = (judetselectat.TemperaturaMedieDecembrie - 25) * coeficienttemperatura;
                double raportPerformantaDec = (panousolarselectat.RaportPerformantaPanou - pierdereTemp / 100);
                EnergieDec = judetselectat.RadiatieSolaraDecembrie * panousolarselectat.AriePanou * raportPerformantaDec * panousolarselectat.RandamentPanou / 100;
                pierdereTemp = 0;
            }
            else
            {
                EnergieDec = judetselectat.RadiatieSolaraDecembrie * panousolarselectat.AriePanou * panousolarselectat.RaportPerformantaPanou * panousolarselectat.RandamentPanou / 100;
            }

            EnergieTotala = EnergieIan + EnergieFeb + EnergieMar + EnergieApr + EnergieMai + EnergieIun + EnergieIul + EnergieAug + EnergieSep + EnergieOct + EnergieNoi + EnergieDec;


            int panouriNecesare = 0;
            double ariePanouri = 0;
            while (calcul.Suprafata >= (ariePanouri + panousolarselectat.AriePanou))
            {
                ariePanouri = ariePanouri + panousolarselectat.AriePanou;
                panouriNecesare = panouriNecesare + 1;
            }
            
            CostTotal = panouriNecesare * panousolarselectat.CostPanou;

            double energieRezultata = panouriNecesare * EnergieTotala;

            energieRezultata = Convert.ToDouble(String.Format("{0:0.00}", energieRezultata)); // doua zecimale
            double sup = calcul.Suprafata;
            ariePanouri = Convert.ToDouble(String.Format("{0:0.00}", ariePanouri)); // doua zecimale
           
            ViewBag.NumarPanouri = panouriNecesare;
            ViewBag.CostTotal = CostTotal;
            ViewBag.Rezultat = rezultat;
            ViewBag.EnergieRezultata = energieRezultata;
            ViewBag.Unghi= calcul.Unghi;
            ViewBag.Suprafata = calcul.Suprafata;
            ViewBag.Locatie = judetselectat.Nume;
            ViewBag.ArieNecesara = ariePanouri;

            return View();
        }
    }
}