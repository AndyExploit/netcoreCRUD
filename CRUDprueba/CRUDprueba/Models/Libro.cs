using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDprueba.Models
{
    public class Libro
    {
        [Key] //con este key y que el nombre sea Id queda el campo como primario y autoincremental
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser almenos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(50, ErrorMessage = "El {0} debe ser almenos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        public string Precio { get; set; }
    }
}
