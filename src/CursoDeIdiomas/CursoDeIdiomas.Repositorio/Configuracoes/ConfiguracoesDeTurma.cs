using CursoDeIdiomas.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIdiomas.Repositorio.Configuracoes
{
    public class ConfiguracoesDeTurma : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turmas");
            builder.HasKey(turma => turma.Id);
            builder.Property(turma => turma.Numero).IsRequired();
            builder.Property(turma => turma.AnoLetivo).IsRequired();
            builder.HasMany(turma => turma.Alunos);
        }
    }
}
