namespace CursoDeIdiomas.Dominio.Validadores
{
    public static class ValidadorDeStrings
    {
        public static bool ValidarCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = RemoverPontuacao(cpf);

            if (!EhCPFValido(cpf))
                return false;

            int[] digitos = cpf.Select(c => int.Parse(c.ToString())).ToArray();
            int[] multiplicadores1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int resto = CalcularDigitoVerificador(digitos, multiplicadores1);
            if (resto != digitos[9])
                return false;

            resto = CalcularDigitoVerificador(digitos, multiplicadores2);
            if (resto != digitos[10])
                return false;

            return true;
        }

        #region Métodos privados

        private static string RemoverPontuacao(string texto)
        {
            return new string(texto.Where(char.IsDigit).ToArray());
        }

        private static bool EhCPFValido(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit) || TodosDigitosIguais(cpf))
            {
                return false;
            }

            return true;
        }

        private static bool TodosDigitosIguais(string texto)
        {
            char primeiroDigito = texto[0];

            foreach (char digito in texto)
            {
                if (digito != primeiroDigito)
                {
                    return false;
                }
            }

            return true;
        }

        private static int[] GerarMultiplicadores(int inicio, int fim)
        {
            int tamanhoArray = fim - inicio + 1;
            int[] multiplicadores = new int[tamanhoArray];

            for (int i = 0; i < tamanhoArray; i++)
            {
                multiplicadores[i] = fim--;
            }

            return multiplicadores;
        }

        private static int CalcularSoma(int[] digitos, int[] multiplicadores)
        {
            int soma = 0;

            for (int i = 0; i < digitos.Length && i < multiplicadores.Length; i++)
            {
                soma += digitos[i] * multiplicadores[i];
            }

            return soma;
        }

        private static int CalcularDigitoVerificador(int[] digitos, int[] multiplicadores)
        {
            int soma = 0;
            for (int i = 0; i < multiplicadores.Length; i++)
            {
                soma += digitos[i] * multiplicadores[i];
            }

            int resto = soma % 11;
            int digito = 11 - resto;
            if (resto < 2)
            {
                digito = 0;
            }

            return digito;
        }

        #endregion

        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                var enderecoEmail = new System.Net.Mail.MailAddress(email);
                return enderecoEmail.Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
