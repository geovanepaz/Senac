using Senac.BemStar.Domain.DTOS;
using Senac.BemStar.Domain.Entities;

namespace Senac.BemStar.Application.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoDTO>> ObterTodosAsync();
        Task<AlunoDTO> ObterPorIdAsync(int id);
        Task<AlunoDTO> CriarAsync(AlunoDTO alunoDto);
        Task<AlunoDTO> AtualizarAsync(int id, AlunoDTO alunoDto);
        Task<bool> ExcluirAsync(int id);
    }
}
