using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Equipos
    {
        [Key]
        public int EquipoId { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Sistema Operativo es obligatorio")]
        public string SistemaOperativo { get; set; }

        public int Memoria { get; set; }
        public int Disco { get; set; }

        [Required(ErrorMessage = "El Procesador es obligatorio")]
        public string Procesador { get; set; }

        [Required(ErrorMessage = "El Area es obligatorio")]
        public string Area { get; set; }
    }
}
