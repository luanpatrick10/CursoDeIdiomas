using CursoDeIdiomas.Dominio.Entidades;

namespace CursoDeIdiomas.Dominio.Repositorios
{
    public interface IAlunoRepositorio
    {
        Task<ICollection<Aluno>> ObterAlunos();
        Task<Aluno> ObterPorId(int? id);

        Task<Aluno> CriarAluno(Aluno aluno);
        Task<Aluno> Atualizar(Aluno aluno);
        Task<Aluno> Deletar(Aluno aluno);
        Task<Aluno> AtualizarSemAdicionarTurmas(Aluno aluno);
    }
}
