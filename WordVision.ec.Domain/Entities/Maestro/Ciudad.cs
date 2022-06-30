using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class Ciudad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdProvincia { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

       // [Required]
        [StringLength(10)]
        public string Codigo { get; set; }

        [StringLength(2)]
        public string CodigoArea { get; set; }

        [Required]
        public int Estado { get; set; }

        public Provincia Provincias { get; set; }


    }
}
