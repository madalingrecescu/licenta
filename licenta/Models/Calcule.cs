using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prima.Models
{
    public class Calcule
    {
        public int Id { get; set; }

        
        public double EnergieNecesara { get; set; }
        public double Suprafata { get; set; }
        public int JudetId { get; set; }
        public virtual Judet Judet { get; set; }
        public int PanouId { get; set; }
       
        public virtual PanouSolar PanouSolar { get; set; }
        public double Unghi { get; set; }

    }
}