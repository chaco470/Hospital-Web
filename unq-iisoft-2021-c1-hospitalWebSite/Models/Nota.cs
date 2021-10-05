using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Hospital {
    public class Nota {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Cuerpo { get; set; }
        [Required]
        public string Fecha { get; set; }
        [Required]
        public string URLImagen { get; set; }
        [Required]
        public string URLNotaCompleta { get; set; }
    }
}