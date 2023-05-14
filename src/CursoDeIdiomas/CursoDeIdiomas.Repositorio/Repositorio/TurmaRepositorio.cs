using CursoDeIdiomas.Dominio.Entidades;
using CursoDeIdiomas.Dominio.Repositorios;
using CursoDeIdiomas.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Repositorio.Repositorio
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private ApplicationDbContext _applicationDbContext;
        public TurmaRepositorio(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Turma> Atualizar(Turma turma)
        {
            _applicationDbContext.Update(turma);
            await _applicationDbContext.SaveChangesAsync();
            return turma;
        }

        public async Task<Turma> CriarTuma(Turma turma)
        {
            _applicationDbContext.Add(turma);
            await _applicationDbContext.SaveChangesAsync();
            return turma;
        }

        public async Task<Turma> Deletar(Turma turma)
        {
            _applicationDbContext.Remove(turma);
            await _applicationDbContext.SaveChangesAsync();
            return turma;
        }

        public async Task<Turma> ObterPorId(int? id)
        {
            return await _applicationDbContext.Turmas.FindAsync(id);
        }

        public async Task<ICollection<Turma>> ObterTurmas()
        {
            return await _applicationDbContext.Turmas.ToListAsync();
        }
    }
}
