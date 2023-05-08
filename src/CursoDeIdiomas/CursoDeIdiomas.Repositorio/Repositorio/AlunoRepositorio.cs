using CursoDeIdiomas.Dominio.Entidades;
using CursoDeIdiomas.Dominio.Repositorios;
using CursoDeIdiomas.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Repositorio.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private ApplicationDbContext _applicationDbContext;
        public AlunoRepositorio(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Aluno> Atualizar(Aluno aluno)
        {
            _applicationDbContext.Update(aluno);
            await _applicationDbContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> CriarAluno(Aluno aluno)
        {
            _applicationDbContext.Add(aluno);
            await _applicationDbContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> Deletar(Aluno aluno)
        {
            _applicationDbContext.Remove(aluno);
            await _applicationDbContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<ICollection<Aluno>> ObterAlunos()
        {
            return await _applicationDbContext.Alunos.ToListAsync();
        }

        public async Task<Aluno> ObterPorId(int? id)
        {
            return await _applicationDbContext.Alunos.FindAsync(id);
        }
    }
}
