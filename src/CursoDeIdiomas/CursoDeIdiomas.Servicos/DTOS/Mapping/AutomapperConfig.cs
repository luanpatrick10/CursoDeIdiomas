using AutoMapper;
using CursoDeIdiomas.Dominio.Entidades;

namespace CursoDeIdiomas.Servicos.DTOS.Mapping
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {

            CreateMap<ReferenciaDeTurmasDTO, Turma>().ForMember(turma => turma.Id, map => map.MapFrom(referernciaDeTurma => referernciaDeTurma.Id));
            CreateMap<NovoAlunoDTO, Aluno>().ForMember(aluno => aluno.TurmasCadastradas, map => map.MapFrom(novoAlunoDTO => novoAlunoDTO.TurmasCadastradas));

            //CreateMap<ICollection<Aluno>, ICollection<AlunoDTO>>().ReverseMap();
            //CreateMap<ICollection<Turma>, ICollection<TurmaDTO>>().ReverseMap();
            //CreateMap<Aluno, AlunoDTO>().ReverseMap();
            //CreateMap<Turma, TurmaDTO>().ReverseMap();
            //CreateMap<NovaTurmaDTO, Turma>();
        }
    }
}
