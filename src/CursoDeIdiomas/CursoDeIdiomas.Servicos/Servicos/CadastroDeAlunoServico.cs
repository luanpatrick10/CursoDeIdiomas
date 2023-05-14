using CursoDeIdiomas.Dominio.Entidades;
using CursoDeIdiomas.Dominio.ObjetosDeDominio;
using CursoDeIdiomas.Dominio.Repositorios;
using CursoDeIdiomas.Dominio.Servicos;

namespace CursoDeIdiomas.Servicos.Servicos
{
    public class CadastroDeAlunoServico : ICadastroDeAlunoServico
    {
        private IAlunoRepositorio _alunoRepositorio;
        public CadastroDeAlunoServico(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }
        public async Task<Aluno> Atualizar(Aluno aluno)
        {
            aluno.ValidarEntidade();
            await _alunoRepositorio.Atualizar(aluno);
            return aluno;
        }

        public async Task<Aluno> Criar(Aluno aluno)
        {
            aluno.ValidarEntidade();
            await _alunoRepositorio.CriarAluno(aluno);
            return aluno;
        }

        public async Task<Aluno> Deletar(int id)
        {
            Aluno aluno = await _alunoRepositorio.ObterPorId(id);
            ValidarSeAlunoNaoEstaMatriculadoEmTurmas(aluno);
            await _alunoRepositorio.Deletar(aluno);
            return aluno;
        }

        public async Task<Aluno> ObterPorId(int? id)
        {
            return await _alunoRepositorio.ObterPorId(id);
        }

        public async Task<ICollection<Aluno>> ObterTodos()
        {
            return await _alunoRepositorio.ObterAlunos();
        }

        public async Task CancelarMatriculaDoAluno(int id)
        {
            Aluno aluno = await _alunoRepositorio.ObterPorId(id);
            aluno.AlterarTurmasCadastradas(new List<Turma>());
            await _alunoRepositorio.AtualizarSemAdicionarTurmas(aluno);
        }

        #region Métodos privados
        private void ValidarSeAlunoNaoEstaMatriculadoEmTurmas(Aluno aluno)
        {
            if (aluno.TurmasCadastradas.Count() > 0)
                throw new ExcecoesDeDominio("Esse aluno não pode ser excluido(a) pois está matriculado em alguma turma");
        }
        #endregion
    }
}
