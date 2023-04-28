namespace CursoDeIdiomas.Dominio.ObjetosDeDominio
{
    public class Validacoes
    {
        public static void ValidarSeNulo(string valor, string mensagem)
        {
            if (valor == null)
                throw new ExcecoesDeDominio(mensagem);
        }

    }
}
