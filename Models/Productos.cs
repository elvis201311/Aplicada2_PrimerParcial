using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models
{
     public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La existencia es obligatoria")]
        [Range(minimum:1,maximum:int.MaxValue,ErrorMessage = "La existencia debe ser mayor a 0")]
        public int Existencia { get; set; }
        [Required(ErrorMessage = "El costo es obligatorio")]
        [Range(minimum:1,maximum:int.MaxValue,ErrorMessage = "El costo debe ser mayor a 0")]
        public decimal Costo { get; set; }
        public decimal ValorInventario { get; set; }

    }
}
