namespace CursoDeIdiomas.Dominio.ObjetosDeDominio
{
    public abstract class Entidade
    {
        public int Id { get; set; }
        public abstract void ValidarEntidade();
    }
}
