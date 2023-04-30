using CursoDeIdiomas.Dominio.Entidades;
using CursoDeIdiomas.Dominio.Repositorios;
using CursoDeIdiomas.Dominio.Servicos;

namespace CursoDeIdiomas.Servicos.Servicos
{
    public class CadastroDeTurmaServico : ICadastroDeTurmaServico
    {
        private ITurmaRepositorio _turmaRepositorio;
        public CadastroDeTurmaServico(ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }

        public async Task<Turma> Atualizar(Turma turma)
        {
            turma.ValidarEntidade();
            return await _turmaRepositorio.Atualizar(turma);
        }

        public async Task<Turma> Criar(Turma turma)
        {
            turma.ValidarEntidade();
            return await _turmaRepositorio.CriarTuma(turma);
        }

        public async Task<Turma> Deletar(Turma turma)
        {
            turma.ValidarEntidade();
            return await _turmaRepositorio.Deletar(turma);
        }
        public async Task<Turma> ObterPorId(int? id)
        {
            return await _turmaRepositorio.ObterPorId(id);
        }
        public async Task<IEnumerable<Turma>> ObterTodos()
        {
            return await _turmaRepositorio.ObterTurmas();
        }
    }
}
