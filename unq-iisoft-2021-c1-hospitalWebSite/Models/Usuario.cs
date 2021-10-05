using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Hospital {


     public class Usuario {

        [Key]
        public string Mail { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Contraseña { get; set; }

        public string ObraSocial { get; set; }
        
        
    }

}