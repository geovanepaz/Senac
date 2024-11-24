using Microsoft.EntityFrameworkCore;
using Senac.BemStar.Domain.Entities;
using Senac.BemStar.Domain.Interfaces;
using Senac.BemStar.Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Senac.BemStar.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly BemStarContext _context;

        public AlunoRepository(BemStarContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno>> ObterTodosAsync()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno> ObterPorIdAsync(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task<Aluno> CriarAsync(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task AtualizarAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExcluirAsync(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
