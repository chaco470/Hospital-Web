using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Hospital {

    public class Turno {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string MailUsuario { get; set; }   
        [Required]
        public string Especialidad { get; set; }


        [Required]
        public string Especialista {get;set;}
    }
        
}