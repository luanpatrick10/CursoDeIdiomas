namespace CursoDeIdiomas.Dominio.ObjetosDeDominio
{
    public class ExcecoesDeDominio : Exception
    {
        public ExcecoesDeDominio()
        {
        }

        public ExcecoesDeDominio(string mensagem) : base(mensagem)
        {
        }

        public ExcecoesDeDominio(string mensagem, Exception exception) : base(mensagem, exception)
        {
        }
    }
}
