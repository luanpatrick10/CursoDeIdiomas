using CursoDeIdiomas.Dominio.ObjetosDeDominio;

namespace CursoDeIdiomas.Dominio.Entidades
{
    public class Turma : Entidade, IAggregateRoot
    {
        public string Numero { get; private set; }
        public DateTime AnoLetivo { get; private set; }
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
            ValidarAlunos();
        }
        private void ValidarAlunos()
        {
            foreach (Aluno aluno in Alunos)
            {
                if (Alunos.Exists(alunoNaLista => alunoNaLista.Id == aluno.Id))
                    throw new ExcecoesDeDominio($"O aluno {aluno.Nome}, já esta cadastrado nessa turma");
            }
        }
    }
}
