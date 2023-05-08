using AutoMapper;
using CursoDeIdiomas.Dominio.Servicos;
using Moq;

namespace CursosDeIdiomas.Test.Servicos
{
    public class CadastroDeTurmaTest
    {
        private ICadastroDeTurmaServico _cadastroDeTurma;
        private readonly IMapper _mapper;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _cadastroDeTurma = new Mock<ICadastroDeTurmaServico>().Object;
        }
        [Test]
        public void TestaCadastrarTurma()
        {
        }
    }
}
