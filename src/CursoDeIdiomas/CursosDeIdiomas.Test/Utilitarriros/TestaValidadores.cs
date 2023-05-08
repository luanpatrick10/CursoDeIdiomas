using CursoDeIdiomas.Dominio.Validadores;

namespace CursosDeIdiomas.Test.Utilitarriros
{
    public class TestaValidadores
    {
        [Test]
        public void ValidarCPF_CPFVazio_RetornaFalso()
        {
            string cpf = "";
            bool resultado = ValidadorDeStrings.ValidarCPF(cpf);
            Assert.IsFalse(resultado);
        }

        [Test]
        public void ValidarCPF_CPFNulo_RetornaFalso()
        {
            string cpf = null;
            bool resultado = ValidadorDeStrings.ValidarCPF(cpf);
            Assert.IsFalse(resultado);
        }

        [Test]
        public void ValidarCPF_CPFTodosDigitos_RetornaFalso()
        {
            string cpf = "00000000000";
            bool resultado = ValidadorDeStrings.ValidarCPF(cpf);
            Assert.IsFalse(resultado);
        }

        [Test]
        public void ValidarCPF_CPFIgual11_RetornaFalso()
        {
            string cpf = "11111111111";
            bool resultado = ValidadorDeStrings.ValidarCPF(cpf);
            Assert.IsFalse(resultado);
        }

        [Test]
        public void ValidarCPF_CPFValido_RetornaVerdadeiro()
        {
            string cpf = "529.982.247-25";
            bool resultado = ValidadorDeStrings.ValidarCPF(cpf);
            Assert.IsTrue(resultado);
        }

        [Test]
        public void ValidarCPF_CPFInvalido_RetornaFalso()
        {
            string cpf = "123.456.789-00";
            bool resultado = ValidadorDeStrings.ValidarCPF(cpf);
            Assert.IsFalse(resultado);
        }
    }
}
