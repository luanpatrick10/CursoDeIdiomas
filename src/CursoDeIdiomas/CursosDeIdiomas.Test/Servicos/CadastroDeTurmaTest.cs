using CursoDeIdiomas.Dominio.Entidades;
using CursoDeIdiomas.Dominio.Servicos;
using Moq;

namespace CursosDeIdiomas.Test.Servicos
{
    public class CadastroDeTurmaTest
    {
        private ICadastroDeTurmaServico _cadastroDeTurma;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _cadastroDeTurma = new Mock<ICadastroDeTurmaServico>().Object;
        }
        [Test]
        public void TestaCadastrarTurma()
        {
            Task.Run(() =>
            {
                Turma turma = new Turma(1, "Turma A", DateTime.Now, null);
                _cadastroDeTurma.Criar(turma);
            }).Wait();
        }
    }
}
