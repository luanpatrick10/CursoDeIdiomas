using CursoDeIdiomas.Dominio.Entidades;

namespace CursoDeIdiomas.Servicos.DTOS.Mapping
{
    public static class TurmaDTOMapping
    {
        public static Turma TurmaDTOToTurma(this TurmaDTO turmaDTO)
        {
            return new Turma(turmaDTO.Id, turmaDTO.Numero, turmaDTO.AnoLetivo, turmaDTO.Alunos.AlunosDToToAlunos());
        }

        public static TurmaDTO TurmaToTurmaDTO(this Turma turma)
        {
            return new TurmaDTO(turma.Id, turma.Numero, turma.AnoLetivo, turma.Alunos.AlunosToAlunosDTO());
        }

        public static ICollection<TurmaDTO> TurmasToTurmasDTO(this IEnumerable<Turma> turmas)
        {
            List<TurmaDTO> turmaDTO = new List<TurmaDTO>();
            foreach (Turma turma in turmas)
            {
                turmaDTO.Add(turma.TurmaToTurmaDTO());
            }
            return turmaDTO;
        }

        public static ICollection<Turma> TurmasDTOToTurmas(this IEnumerable<TurmaDTO> turmasDTO)
        {
            List<Turma> turma = new List<Turma>();
            foreach (TurmaDTO turmaDTO in turmasDTO)
            {
                turma.Add(turmaDTO.TurmaDTOToTurma());
            }
            return turma;
        }
    }
}
