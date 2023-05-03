namespace CursoDeIdiomas.Servicos.DTOS
{
    public class NovoAlunoDTO
    {
        public NovoAlunoDTO()
        {
        }
        public NovoAlunoDTO(string nome, string cpf, string email, IEnumerable<ReferenciaDeTurmasDTO> turmasCadastradas)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            TurmasCadastradas = turmasCadastradas;
        }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public IEnumerable<ReferenciaDeTurmasDTO> TurmasCadastradas { get; set; }
        public int QuantidadeMinimaDeTurma { get => 1; }
    }
}
