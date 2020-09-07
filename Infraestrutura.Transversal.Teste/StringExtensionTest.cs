using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Infraestrutura.Transversal.Teste
{
    [TestClass]
    public class StringExtensionTest
    {
        [TestMethod]
        public void StringExtension_IsValidEmail_Valido()
        {
            //Arrange
            const string input = "usuario@domain.com.br";

            //Act
            var result = input.IsValidEmail();

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void StringExtension_IsValidEmail_Invalido_EmailIncompleto()
        {
            //Arrange
            const string input = "@dominio.com";

            //Act
            var result = input.IsValidEmail();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StringExtension_IsValidEmail_Invalido_SemArroba()
        {
            //Arrange
            const string input = "userdominio.com";

            //Act
            var result = input.IsValidEmail();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StringExtension_IsValidEmail_Invalido_SemDominio()
        {
            //Arrange
            const string input = "user@.com";

            //Act
            var result = input.IsValidEmail();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StringExtension_IsValidEmail_Invalido_SemExtensao()
        {
            //Arrange
            const string input = "user@dominio";

            //Act
            var result = input.IsValidEmail();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StringExtension_IsValidEmail_Invalido_EmailVazio()
        {
            //Arrange
            const string input = null;

            //Act
            input.IsValidEmail();
        }

        [TestMethod]
        public void StringExtension_IsValidSenha_Valido()
        {
            //Arrange
            const string input = "Abcd#123";

            //Act
            var result = input.IsValidPassword();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StringExtension_IsValidSenha_Invalido_MenosDeOitoCaracteres()
        {
            //Arrange
            const string input = "gTe3%4r";

            //Act
            var result = input.IsValidEmail();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StringExtension_IsValidSenha_Invalido_SemNumero()
        {
            //Arrange
            const string input = "Abcd#abcD";

            //Act
            var result = input.IsValidEmail();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StringExtension_IsValidSenha_Invalido_SemCaracterEspecial()
        {
            //Arrange
            const string input = "AbcD1234";

            //Act
            var result = input.IsValidEmail();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StringExtension_IsValidSenha_Invalido_SemLetraMaiuscula()
        {
            //Arrange
            const string input = "abcd#1234";

            //Act
            var result = input.IsValidEmail();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StringExtension_IsValidSenha_Invalido_SemLetraMinuscula()
        {
            //Arrange
            const string input = "ABCD#1234";

            //Act
            var result = input.IsValidEmail();

            //Assert
            Assert.IsFalse(result);
        }
    }
}
