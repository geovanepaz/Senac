using AutoMapper;
using Senac.BemStar.Domain.DTOS;
using Senac.BemStar.Domain.Entities;

public class MapeamentoProfile : Profile
{
    public MapeamentoProfile()
    {
        // Mapear de Aluno para AlunoDTO e vice-versa
        CreateMap<Aluno, AlunoDTO>().ReverseMap();
    }
}
