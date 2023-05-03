namespace CursoDeIdiomas.Servicos.DTOS
{
    public class NovaTurmaDTO
    {
        public NovaTurmaDTO()
        {
        }
        public NovaTurmaDTO(int id, string numero, DateTime anoLetivo)
        {
            Id = id;
            Numero = numero;
            AnoLetivo = anoLetivo;
        }
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime AnoLetivo { get; set; }
        public int LimiteDeAlunos { get => 5; }
    }
}
