namespace CursoDeIdiomas.Servicos.DTOS
{
    public class AlunoDTO
    {
        public AlunoDTO()
        {
            TurmasCadastradas = new List<TurmaDTO>();
        }
        public AlunoDTO(string nome, string cpf, string email, ICollection<TurmaDTO> turmasCadastradas)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            TurmasCadastradas = turmasCadastradas;
        }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public ICollection<TurmaDTO> TurmasCadastradas { get; set; }
        public int QuantidadeMinimaDeTurma { get { return 1; } }
    }
}
