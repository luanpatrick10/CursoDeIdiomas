using CursoDeIdiomas.Dominio.Repositorios;
using CursoDeIdiomas.Repositorio.Contexto;
using CursoDeIdiomas.Repositorio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.UI.InjecaoDeDependencia
{
    public static class RegistroDeRepositorios
    {
        public static IServiceCollection RegistrarRepositorios(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            services.AddScoped<ITurmaRepositorio, TurmaRepositorio>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
            return services;
        }
    }
}
