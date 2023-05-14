namespace CursoDeIdiomas.Servicos.DTOS
{
    public class NovaTurmaDTO
    {
        public NovaTurmaDTO()
        {
        }
        public NovaTurmaDTO(string numero, DateTime anoLetivo)
        {
            Numero = numero;
            AnoLetivo = anoLetivo;
        }
        public string Numero { get; set; }
        public DateTime AnoLetivo { get; set; }
        public int LimiteDeAlunos { get => 5; }
    }
}
