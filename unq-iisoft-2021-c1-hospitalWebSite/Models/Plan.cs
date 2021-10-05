using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Hospital {

    public class Plan {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public ObraSocial ObraSocial { get; set; }
        [Required]
        public bool Activo { get; set; }
    }


}