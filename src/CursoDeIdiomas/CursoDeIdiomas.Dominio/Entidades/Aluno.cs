using CursoDeIdiomas.Dominio.ObjetosDeDominio;
using CursoDeIdiomas.Dominio.Validadores;

namespace CursoDeIdiomas.Dominio.Entidades
{
    public class Aluno : Entidade, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public ICollection<Turma> TurmasCadastradas { get; private set; } = new List<Turma>();
        public int QuantidadeMinimaDeTurma { get => 1; }
        public Aluno()
        {
        }
        public Aluno(string nome, string cpf, string email, ICollection<Turma> turmasCadastradas)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            TurmasCadastradas = turmasCadastradas;
            ValidarEntidade();
        }

        public override void ValidarEntidade()
        {
            ValidacoesDeDominio.ValidarSeNaoEhVazioOuNulo(Nome, MensagensDeValidacoes.PropriedadeNulaOuVazio);
            ValidacoesDeDominio.ValidarSeMaiorOuIgualQue(TurmasCadastradas.Count(), QuantidadeMinimaDeTurma, MensagensDeValidacoes.PropriedadeMenorQueValorMinimo(nameof(TurmasCadastradas)));
            ValidacoesDeDominio.ValidarSeVerdadeiro(ValidadorDeStrings.ValidarCPF(Cpf), MensagensDeValidacoes.PropriedadeInvalida(nameof(Cpf)));
            ValidacoesDeDominio.ValidarSeVerdadeiro(ValidadorDeStrings.ValidarEmail(Email), MensagensDeValidacoes.PropriedadeInvalida(nameof(Cpf)));
            ValidarSeNaoTemTurmasDuplicado();
        }
        public void AlterarTurmasCadastradas(ICollection<Turma> turmasCadastradas)
        {
            ValidarEntidade();
            TurmasCadastradas = turmasCadastradas;
        }
        private void ValidarSeNaoTemTurmasDuplicado()
        {
            foreach (Turma turma in TurmasCadastradas)
            {
                if (TurmasCadastradas.Where(turmaCadastrada => turmaCadastrada.Id == turma.Id).Count() > 1)
                    throw new ExcecoesDeDominio($"A turma {turma.Numero}, já esta cadastrado com esse aluno cadastrado.");
            }
        }
    }
}
