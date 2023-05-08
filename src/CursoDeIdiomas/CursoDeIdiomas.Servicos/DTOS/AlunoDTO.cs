namespace CursoDeIdiomas.Servicos.DTOS
{
    public class AlunoDTO
    {
        public AlunoDTO()
        {
            TurmasCadastradas = new HashSet<ReferenciaDeTurmasDTO>();
        }
        public AlunoDTO(string nome, string cpf, string email, ICollection<ReferenciaDeTurmasDTO> turmasCadastradas)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            TurmasCadastradas = turmasCadastradas;
        }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public ICollection<ReferenciaDeTurmasDTO> TurmasCadastradas { get; set; }
        public int QuantidadeMinimaDeTurma { get => 1; }
    }
}
