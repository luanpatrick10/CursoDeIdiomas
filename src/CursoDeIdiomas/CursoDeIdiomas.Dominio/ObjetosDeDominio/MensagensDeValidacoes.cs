namespace CursoDeIdiomas.Dominio.ObjetosDeDominio
{
    public class MensagensDeValidacoes
    {
        public static string PropriedadeNula(string nomeDaPropriedade)
        {
            return $"A propriedade {nomeDaPropriedade} não pode ser nula.";
        }

        public static string PropriedadeExcedendoOValorMaximo(string nomeDaPropriedade)
        {
            return $"A propriedade {nomeDaPropriedade} não pode ser maior que seu limite.";
        }

        public static string PropriedadeMenorQueValorMinimo(string nomeDaPropriedade)
        {
            return $"A propriedade {nomeDaPropriedade} não pode ser menor que seu valor minimo.";
        }
        public static string CpfInvalido = "Cpf inválido.";
        public static string PropriedadeInvalida(string nomeDaPropriedade)
        {
            return $"Propriedade {nomeDaPropriedade} inválida.";
        }

        public static string PropriedadeNulaOuVazio = "Essa propriedade não pode ser nula ou vazia.";

    }
}
