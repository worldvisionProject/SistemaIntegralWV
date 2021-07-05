using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
    public interface IFormularioRepository
    {
        IQueryable<Formulario> Formularios { get; }

        Task<List<Formulario>> GetListAsync();

        Task<Formulario> GetByIdAsync(int DocumentoId);

        Task<Formulario> GetByIdFormularioAsync(int DocumentoId);
        Task<int> InsertAsync(Formulario formulario);

        Task UpdateAsync(Formulario formulario);

        //Task DeleteAsync(Documento Documento);
    }
}
