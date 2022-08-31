using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prima.Models
{
    public class Judet
    {
        public int JudetId { get; set; }
        [Required(ErrorMessage = "Trebuie sa introduceti numele judetului!")]
        [StringLength(100)]
        public string Nume { get; set; }
        //imagine
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public double RadiatieSolara { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna ianuarie!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraIanuarie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna februarie!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraFebruarie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna martie!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraMartie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna aprilie!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraAprilie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna mai!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraMai { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna iunie!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraIunie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna iulie!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraIulie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna august!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraAugust { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna septembrie!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraSeptembrie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna octombrie!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraOctombrie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna noiemrie!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraNoiembrie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti radiatia solara din luna decembrie!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca radiatia solara sa fie mai mare ca 0")]
        public double RadiatieSolaraDecembrie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna ianuarie!")]
        public double TemperaturaMedieIanuarie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna februarie!")]
        public double TemperaturaMedieFebruarie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna martie!")]
        public double TemperaturaMedieMartie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna aprilie!")]
        public double TemperaturaMedieAprilie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna mai!")]
        public double TemperaturaMedieMai { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna iunie!")]
        public double TemperaturaMedieIunie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna iulie!")]
        public double TemperaturaMedieIulie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna august!")]
        public double TemperaturaMedieAugust { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna septembrie!")]
        public double TemperaturaMedieSeptembrie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna octombrie!")]
        public double TemperaturaMedieOctombrie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna noiembrie!")]
        public double TemperaturaMedieNoiembrie { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti temperatura maxima medie din luna decembrie!")]
        public double TemperaturaMedieDecembrie { get; set; }
        public virtual ICollection<Calcule> CalculeJudete { get; set; }
    }
}
