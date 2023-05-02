using CursoDeIdiomas.Dominio.Entidades;

namespace CursoDeIdiomas.Servicos.DTOS.Mapping
{
    public static class AlunoDTOMapping
    {
        public static Aluno AlunoDTOAluno(this AlunoDTO alunoDTO)
        {
            return new Aluno(alunoDTO.Nome, alunoDTO.Cpf, alunoDTO.Email, alunoDTO.TurmasCadastradas.TurmasDTOToTurmas());
        }
        public static AlunoDTO AlunoToAlunoDTO(this Aluno aluno)
        {
            return new AlunoDTO(aluno.Nome, aluno.Cpf, aluno.Email, aluno.TurmasCadastradas.TurmasToTurmasDTO());
        }
        public static ICollection<AlunoDTO> AlunosToAlunosDTO(this IEnumerable<Aluno> alunos)
        {
            List<AlunoDTO> alunosDTO = new List<AlunoDTO>();
            foreach (Aluno aluno in alunos)
            {
                alunosDTO.Add(aluno.AlunoToAlunoDTO());
            }
            return alunosDTO;
        }
        public static ICollection<Aluno> AlunosDToToAlunos(this IEnumerable<AlunoDTO> alunosDTO)
        {
            List<Aluno> alunos = new List<Aluno>();
            foreach (AlunoDTO alunoDTO in alunosDTO)
            {
                alunos.Add(alunoDTO.AlunoDTOAluno());
            }
            return alunos;
        }
    }
}
