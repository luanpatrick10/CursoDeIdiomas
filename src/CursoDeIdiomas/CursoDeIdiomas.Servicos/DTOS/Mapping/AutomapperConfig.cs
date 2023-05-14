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
            CreateMap<AtualizarAlunoDTO, Aluno>().ForMember(aluno => aluno.TurmasCadastradas, map => map.MapFrom(novoAlunoDTO => novoAlunoDTO.TurmasCadastradas));
            CreateMap<Turma, TurmaDTO>().ReverseMap().ForMember(turma => turma.Alunos, map => map.MapFrom(turmaDTO => turmaDTO.Alunos));
            CreateMap<Aluno, AlunoDTO>().ReverseMap().ForMember(aluno => aluno.TurmasCadastradas, map => map.MapFrom(alunoDTO => alunoDTO.TurmasCadastradas));
            CreateMap<NovaTurmaDTO, Turma>();
        }
    }
}
