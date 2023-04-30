using CursoDeIdiomas.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Repositorio.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions opcoes) : base(opcoes) { }

        public DbSet<Turma> Tumas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

    }
}
