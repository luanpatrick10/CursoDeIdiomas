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
            int[] multiplicadores1 = GerarMultiplicadores(2, 9).Reverse().ToArray();
            int[] multiplicadores2 = GerarMultiplicadores(2, 10).Reverse().ToArray();

            int resto = CalcularDigitoVerificador(digitos, multiplicadores1, 9);
            if (resto != digitos[9])
                return false;

            resto = CalcularDigitoVerificador(digitos, multiplicadores2, 10);
            if (resto != digitos[10])
                return false;

            return true;
        }
        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

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

        #region Métodos privados
        private static string RemoverPontuacao(string texto)
        {
            return new string(texto.Where(char.IsDigit).ToArray());
        }

        private static bool EhCPFValido(string cpf)
        {
            if (cpf.Length != 11 || !cpf.All(char.IsDigit) || TodosDigitosIguais(cpf))
                return false;

            return true;
        }

        private static bool TodosDigitosIguais(string texto)
        {
            char primeiroDigito = texto[0];

            foreach (char digito in texto)
            {
                if (digito != primeiroDigito)
                    return false;
            }

            return true;
        }

        private static int[] GerarMultiplicadores(int inicio, int fim)
        {
            return Enumerable.Range(inicio, fim - inicio + 1).ToArray();
        }

        private static int CalcularSoma(int[] digitos, int[] multiplicadores)
        {
            int soma = 0;

            for (int i = 0; i < digitos.Length - 2; i++)
            {
                soma += digitos[i] * multiplicadores[i];
            }

            return soma;
        }

        private static int CalcularDigitoVerificador(int[] digitos, int[] multiplicadores, int posicao)
        {
            int soma = CalcularSoma(digitos, multiplicadores);
            int resto = (soma * 10) % 11 % 10;

            return resto;
        }
        #endregion
    }
}
