using CursoDeIdiomas.Dominio.Entidades;

namespace CursoDeIdiomas.Dominio.Repositorios
{
    public interface ITurmaRepositorio
    {
        Task<IEnumerable<Turma>> ObterTurmas();
        Task<Turma> ObterPorId(int? id);

        Task<Turma> CriarTuma(Turma turma);
        Task<Turma> Atualizar(Turma turma);
        Task<Turma> Deletar(Turma turma);
    }
}
