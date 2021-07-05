using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Domain.Entities.Identity
{
	public class UsuariosActiveDirectory
	{
		[Key]
		public int OID { get; set; }

		public string CreadoPor { get; set; }

		//public DateTime FechaCreado { get; set; }

		public string ActualizadoPor { get; set; }

		//public DateTime FechaActualizado { get; set; }

		public string UserNameId { get; set; }

		//public int LiderAreaId { get; set; }

		public string DisplayName { get; set; }

		public string TelephoneNumber { get; set; }

		public string Mobile { get; set; }

		public string Mail { get; set; }

		public string Title { get; set; }

		public string Manager { get; set; }

		public string Company { get; set; }

		public string PhysicalDeliveryOfficeName { get; set; }

		public string Department { get; set; }

		public string UserName { get; set; }

		public string UserNameAD { get; set; }

		[Required]
		public string UserNameRegular { get; set; }

		//public bool Enabled { get; set; }

		//public bool EsGerencia { get; set; }

		//public bool EsLider { get; set; }

		public string Cedula { get; set; }

		//public int OptimisticLockField { get; set; }

		//public int GCRecord { get; set; }

		public string ApellidoPaterno { get; set; }
		public string ApellidoMaterno { get; set; }
		public string PrimerNombre { get; set; }
		public string SegundoNombre { get; set; }
	}
}
