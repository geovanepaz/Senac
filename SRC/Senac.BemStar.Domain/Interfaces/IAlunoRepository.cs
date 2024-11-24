using Senac.BemStar.Domain.Entities;

namespace Senac.BemStar.Domain.Interfaces
{
    public interface IAlunoRepository
    {


        public Task<IEnumerable<Aluno>> ObterTodosAsync();

        public Task<Aluno> ObterPorIdAsync(int id);

        public Task<Aluno> CriarAsync(Aluno aluno);

        public Task AtualizarAsync(Aluno aluno);

        public Task<bool> ExcluirAsync(Aluno aluno);
    }
}
