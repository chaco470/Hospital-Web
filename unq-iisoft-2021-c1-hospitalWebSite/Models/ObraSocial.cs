using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Hospital
{
    public class ObraSocial
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string PaginaWeb { get; set; }
        
        public List<Plan> Planes { get; set; }
        [Required]
        public string Estado { get; set; }



    }
}