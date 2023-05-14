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
            await AdicionarTurmasCadastradas(aluno);
            _applicationDbContext.Update(aluno);
            await _applicationDbContext.SaveChangesAsync();
            return aluno;
        }
        public async Task<Aluno> AtualizarSemAdicionarTurmas(Aluno aluno)
        {
            _applicationDbContext.Update(aluno);
            await _applicationDbContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> CriarAluno(Aluno aluno)
        {
            await AdicionarTurmasCadastradas(aluno);
            _applicationDbContext.Alunos.Add(aluno);
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
            return await _applicationDbContext.Alunos.Include(aluno => aluno.TurmasCadastradas).IgnoreAutoIncludes().ToListAsync();
        }

        public async Task<Aluno> ObterPorId(int? id)
        {
            return _applicationDbContext.Alunos.Include(aluno => aluno.TurmasCadastradas).ToList().FirstOrDefault(aluno => aluno.Id == id);
        }
        private async Task AdicionarTurmasCadastradas(Aluno aluno)
        {
            ICollection<Turma> turmas = new List<Turma>();
            foreach (Turma turma in aluno.TurmasCadastradas)
            {
                var turmaConsultada = await _applicationDbContext.Turmas.FirstAsync(x => x.Id == turma.Id);
                turmas.Add(turmaConsultada);
            }
            aluno.AlterarTurmasCadastradas(turmas);
        }
    }
}
