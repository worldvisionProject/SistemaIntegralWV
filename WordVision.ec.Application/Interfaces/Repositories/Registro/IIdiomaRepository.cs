using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
    public interface IIdiomaRepository
    {

        IQueryable<Idioma> Idiomas { get; }

        Task<List<Idioma>> GetListAsync();

        Task<Idioma> GetByIdAsync(int idiomaId);

        Task<List<Idioma>> GetByIdFormularioAsync(int formularioId);

        Task<int> InsertAsync(Idioma idioma);

        Task UpdateAsync(Idioma idioma);

        Task DeleteAsync(Idioma idioma);
    }
}
