namespace CursoDeIdiomas.Dominio.ObjetosDeDominio
{
    public class ValidacoesDeDominio
    {
        public static void ValidarSeNaoEhNulo(string valor, string mensagem)
        {
            if (valor == null)
                throw new ExcecoesDeDominio(mensagem);
        }

        public static void ValidarSeNaoEhVazio(string valor, string mensagem)
        {
            if (valor == "")
                throw new ExcecoesDeDominio(mensagem);
        }

        public static void ValidarSeNaoEhVazioOuNulo(string valor, string mensagem)
        {
            ValidarSeNaoEhVazio(valor, mensagem);
            ValidarSeNaoEhNulo(valor, mensagem);
        }

        public static void ValidarSeMaiorQue(int valor, int valorEsperado, string mensagem)
        {
            if (valor < valorEsperado)
                throw new ExcecoesDeDominio(mensagem);
        }

        public static void ValidarSeMaiorOuIgualQue(int valor, int valorEsperado, string mensagem)
        {
            if (valor < valorEsperado)
                throw new ExcecoesDeDominio(mensagem);
        }

        public static void ValidarSeMenorOuIgualQue(int valor, int valorMaximo, string mensagem)
        {
            if (valor > valorMaximo)
                throw new ExcecoesDeDominio(mensagem);
        }

        public static void ValidarSeVerdadeiro(bool valor, string mensagem)
        {
            if (!valor)
                throw new ExcecoesDeDominio(mensagem);
        }
    }
}
