using CursoDeIdiomas.Dominio.Servicos;
using CursoDeIdiomas.Servicos.Servicos;

namespace CursoDeIdiomas.UI.InjecaoDeDependencia
{
    public static class RegistroDeServicos
    {
        public static IServiceCollection RegistrarServicos(this IServiceCollection services)
        {
            services.AddScoped<ICadastroDeAlunoServico, CadastroDeAlunoServico>();
            services.AddScoped<ICadastroDeTurmaServico, CadastroDeTurmaServico>();
            return services;
        }
    }
}
