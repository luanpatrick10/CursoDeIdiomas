using CursoDeIdiomas.Dominio.ObjetosDeDominio;

namespace CursoDeIdiomas.Dominio.Entidades
{
    public class Turma : Entidade, IAggregateRoot
    {
        public string Numero { get; private set; }
        public DateTime AnoLetivo { private get; set; }
        public int LimiteDeAlunos { get => 5; }
        public List<Aluno> Alunos { get; private set; }
        public Turma(string numero, DateTime anoLetivo, List<Aluno> alunos)
        {
            Numero = numero;
            AnoLetivo = anoLetivo;
            Alunos = alunos;
        }

        public override void ValidarEntidade()
        {
            ValidacoesDeDominio.ValidarSeNaoEhNulo(Numero, MensagensDeValidacoes.PropriedadeNula(nameof(Numero)));
            ValidacoesDeDominio.ValidarSeMenorOuIgualQue(Alunos.Count, LimiteDeAlunos, MensagensDeValidacoes.PropriedadeExcedendoOValorMaximo(nameof(Alunos)));
        }
    }
}
