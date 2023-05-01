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
            builder.HasKey(Aluno => Aluno.Id);
            builder.Property(Aluno => Aluno.Cpf).IsRequired();
            builder.Property(Aluno => Aluno.Nome).IsRequired();
            builder.Property(Aluno => Aluno.Email).IsRequired();
            builder.HasMany(Aluno => Aluno.TurmasCadastradas);
        }
    }
}
