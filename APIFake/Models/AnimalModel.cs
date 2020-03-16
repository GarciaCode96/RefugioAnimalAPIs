using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIFake.Models
{
    public class AnimalModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
    }

    public class AnimalCreateModel
    {
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }
        [Required]
        public DateTime Fecha_Nacimiento { get; set; }
    }
}
