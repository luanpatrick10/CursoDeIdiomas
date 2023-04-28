using CursoDeIdiomas.Dominio.ObjetosDeDominio;

namespace CursoDeIdiomas.Dominio.Entidades
{
    public class Aluno : Entidade, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public Aluno(string nome, string cpf, string email)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }
    }
}
