using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prima.Models
{
    public class PanouSolar
    {
        [Key]
        public int PanouId { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti numele panoului!")]
        [StringLength(500)]
        public string NumePanou { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti latimea panoului!")]
        [Range(1,99999,ErrorMessage = "Trebuie ca latimea sa fie mai mare ca 0")]
        public double Latime { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti inaltimea panoului!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca inaltimea sa fie mai mare ca 0")]
        public double Inaltime { get; set; }

        public double AriePanou { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti puterea maxima a panoului!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca inaltimea sa fie mai mare ca 0")]
        public double PutereMaxima { get; set; }

        public double RandamentPanou { get; set; }

        [Required(ErrorMessage = "Trebuie sa introduceti pretul panoului!")]
        [Range(1, 99999, ErrorMessage = "Trebuie ca pretul panoului sa fie mai mare ca 0")]
        public double CostPanou { get; set; }

        [Required]
        public double RaportPerformantaPanou { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public virtual ICollection<Calcule> CalculePanouri { get; set; }
    }
}