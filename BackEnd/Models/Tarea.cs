using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
