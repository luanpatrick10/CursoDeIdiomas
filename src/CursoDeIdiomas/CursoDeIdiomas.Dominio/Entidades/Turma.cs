using CursoDeIdiomas.Dominio.ObjetosDeDominio;

namespace CursoDeIdiomas.Dominio.Entidades
{
    public class Turma : Entidade, IAggregateRoot
    {
        public string Numero { get; private set; }
        public DateTime AnoLetivo { private get; set; }
        public Turma(string numero, DateTime anoLetivo)
        {
            Numero = numero;
            AnoLetivo = anoLetivo;
        }
    }
}
