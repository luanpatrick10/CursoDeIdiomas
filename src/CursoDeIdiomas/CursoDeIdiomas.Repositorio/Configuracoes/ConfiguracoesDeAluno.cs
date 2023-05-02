using CursoDeIdiomas.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIdiomas.Repositorio.Configuracoes
{
    public class ConfiguracoesDeAluno : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");
            builder.HasKey(aluno => aluno.Id);
            builder.Property(aluno => aluno.Cpf).IsRequired();
            builder.Property(aluno => aluno.Nome).IsRequired();
            builder.Property(aluno => aluno.Email).IsRequired();
            builder.HasMany(aluno => aluno.TurmasCadastradas);
        }
    }
}
