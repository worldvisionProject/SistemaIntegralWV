namespace WordVision.ec.Web.Areas.Valoracion.Models
{
    public class CompetenciaViewModel
    {
        public int Id { get; set; }
        public int IdNivel { get; set; }

        public string NombreCompetencia { get; set; }

        public string Comportamiento { get; set; }

        public int IdCompetencia { get; set; }

        public int Padre { get; set; }
    }
}
