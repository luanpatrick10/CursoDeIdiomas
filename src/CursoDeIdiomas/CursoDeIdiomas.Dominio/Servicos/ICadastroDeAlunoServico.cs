using CursoDeIdiomas.Dominio.Entidades;

namespace CursoDeIdiomas.Dominio.Servicos
{
    public interface ICadastroDeAlunoServico : ICrudServico<Aluno>
    {
        Task CancelarMatriculaDoAluno(int id);
    }
}
