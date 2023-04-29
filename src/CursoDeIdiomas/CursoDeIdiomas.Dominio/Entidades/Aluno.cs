using CursoDeIdiomas.Dominio.ObjetosDeDominio;
using CursoDeIdiomas.Dominio.Validadores;

namespace CursoDeIdiomas.Dominio.Entidades
{
    public class Aluno : Entidade, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public List<Turma> TurmasCadastradas { get; private set; }
        public int QuantidadeMinimaDeTurma { get => 1; }
        public Aluno(string nome, string cpf, string email, List<Turma> turmas)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            TurmasCadastradas = turmas;
            ValidarEntidade();
        }

        public override void ValidarEntidade()
        {
            ValidacoesDeDominio.ValidarSeNaoEhVazioOuNulo(Nome, MensagensDeValidacoes.PropriedadeNulaOuVazio);
            ValidacoesDeDominio.ValidarSeMaiorOuIgualQue(TurmasCadastradas.Count, QuantidadeMinimaDeTurma, MensagensDeValidacoes.PropriedadeMenorQueValorMinimo(nameof(TurmasCadastradas)));
            ValidacoesDeDominio.ValidarSeVerdadeiro(ValidadorDeStrings.ValidarCPF(Cpf), MensagensDeValidacoes.PropriedadeInvalida(nameof(Cpf)));
            ValidacoesDeDominio.ValidarSeVerdadeiro(ValidadorDeStrings.ValidarEmail(Email), MensagensDeValidacoes.PropriedadeInvalida(nameof(Cpf)));
        }
    }
}
