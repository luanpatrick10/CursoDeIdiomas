using CursoDeIdiomas.Dominio.Entidades;

namespace CursoDeIdiomas.Servicos.DTOS
{
    public class TurmaDTO
    {
        public TurmaDTO()
        {
        }
        public TurmaDTO(int id, string numero, DateTime anoLetivo, ICollection<Aluno> alunos)
        {
            Id = id;
            Numero = numero;
            AnoLetivo = anoLetivo;
            Alunos = alunos;
        }
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime AnoLetivo { get; set; }
        public int LimiteDeAlunos { get => 5; }
        public ICollection<Aluno> Alunos { get; set; }
    }
}
