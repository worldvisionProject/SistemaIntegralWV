namespace WordVision.ec.Application.Features.Identity.Usuarios.Queries.GetById
{
    public class GetUsuarioByIdResponse
    {
        public int OID { get; set; }
        public string DisplayName { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }
        public string Company { get; set; }
        public string PhysicalDeliveryOfficeName { get; set; }
        public string Department { get; set; }
        public string UserName { get; set; }
        public string UserNameRegular { get; set; }
        public string Cedula { get; set; }

        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public int IdEmpresa { get; set; }

        public int Nivel { get; set; }
        public int ReportaA { get; set; }
        public int IdEstrutura { get; set; }
    }
}
