using AutoMapper;
using Senac.BemStar.Application.Interfaces;
using Senac.BemStar.Domain.DTOS;
using Senac.BemStar.Domain.Entities;
using Senac.BemStar.Domain.Interfaces;

namespace Senac.BemStar.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlunoDTO>> ObterTodosAsync()
        {
            var alunos = await _alunoRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<AlunoDTO>>(alunos);
        }

        public async Task<AlunoDTO> ObterPorIdAsync(int id)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(id);
            return _mapper.Map<AlunoDTO>(aluno);
        }

        public async Task<AlunoDTO> CriarAsync(AlunoDTO alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            var alunoCriado = await _alunoRepository.CriarAsync(aluno);
            return _mapper.Map<AlunoDTO>(alunoCriado);
        }

        public async Task<AlunoDTO> AtualizarAsync(int id, AlunoDTO alunoDto)
        {
            var alunoExistente = await _alunoRepository.ObterPorIdAsync(id);
            if (alunoExistente == null)
                throw new KeyNotFoundException("Aluno não encontrado.");

            var alunoAtualizado = _mapper.Map(alunoDto, alunoExistente);
            await _alunoRepository.AtualizarAsync(alunoAtualizado);

            return _mapper.Map<AlunoDTO>(alunoAtualizado);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(id);
            if (aluno == null)
                throw new KeyNotFoundException("Aluno não encontrado.");

            return await _alunoRepository.ExcluirAsync(aluno);
        }


    }
}
