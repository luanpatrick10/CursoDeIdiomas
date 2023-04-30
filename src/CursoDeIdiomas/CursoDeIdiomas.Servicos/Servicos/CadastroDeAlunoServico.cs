using CursoDeIdiomas.Dominio.Entidades;
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

        public async Task<Aluno> Deletar(Aluno aluno)
        {
            aluno.ValidarEntidade();
            await _alunoRepositorio.Deletar(aluno);
            return aluno;
        }

        public async Task<Aluno> ObterPorId(int? id)
        {
            return await _alunoRepositorio.ObterPorId(id);
        }

        public async Task<IEnumerable<Aluno>> ObterTodos()
        {
            return await _alunoRepositorio.ObterAlunos();
        }
    }
}
