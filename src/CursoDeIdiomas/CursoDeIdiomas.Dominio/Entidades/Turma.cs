using CursoDeIdiomas.Dominio.ObjetosDeDominio;

namespace CursoDeIdiomas.Dominio.Entidades
{
    public class Turma : Entidade, IAggregateRoot
    {
        public string Numero { get; private set; }
        public DateTime AnoLetivo { get; private set; }
        public int LimiteDeAlunos { get => 5; }
        public ICollection<Aluno> Alunos { get; private set; }

        public Turma()
        {
            Alunos = new HashSet<Aluno>();
        }
        public Turma(int id, string numero, DateTime anoLetivo, ICollection<Aluno> alunos)
        {
            Id = id;
            Numero = numero;
            AnoLetivo = anoLetivo;
            Alunos = alunos;
        }

        public override void ValidarEntidade()
        {
            ValidacoesDeDominio.ValidarSeNaoEhNulo(Numero, MensagensDeValidacoes.PropriedadeNula(nameof(Numero)));
            ValidacoesDeDominio.ValidarSeMenorOuIgualQue(Alunos.Count(), LimiteDeAlunos, MensagensDeValidacoes.PropriedadeExcedendoOValorMaximo(nameof(Alunos)));
            ValidarSeNaoTemAlunoDuplicado();
        }
        private void ValidarSeNaoTemAlunoDuplicado()
        {
            foreach (Aluno aluno in Alunos)
            {
                if (Alunos.First(alunoNaLista => alunoNaLista.Id == aluno.Id) != null)
                    throw new ExcecoesDeDominio($"O aluno {aluno.Nome}, já esta cadastrado nessa turma");
            }
        }
    }
}
