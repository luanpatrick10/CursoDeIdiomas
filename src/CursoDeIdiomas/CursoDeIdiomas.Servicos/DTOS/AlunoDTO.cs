namespace CursoDeIdiomas.Servicos.DTOS
{
    public class AlunoDTO
    {
        public AlunoDTO()
        {
        }
        public AlunoDTO(string nome, string cpf, string email, IEnumerable<TurmaDTO> turmasCadastradas)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            TurmasCadastradas = turmasCadastradas;
        }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public IEnumerable<TurmaDTO> TurmasCadastradas { get; set; }
        public int QuantidadeMinimaDeTurma { get => 1; }
    }
}
