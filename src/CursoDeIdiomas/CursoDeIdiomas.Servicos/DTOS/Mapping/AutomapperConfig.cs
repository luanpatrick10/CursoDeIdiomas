using AutoMapper;
using CursoDeIdiomas.Dominio.Entidades;

namespace CursoDeIdiomas.Servicos.DTOS.Mapping
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
            CreateMap<NovoAlunoDTO, Aluno>();

            CreateMap<Turma, TurmaDTO>().ReverseMap();
            CreateMap<NovaTurmaDTO, Turma>();
        }
    }
}
