using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NW.CursoMvc.Domain.Entities;

// MSTest
// NUnit
// XUnit

namespace NW.CursoMvc.Domain.Tests.Entity
{
    [TestClass]
    public class ClienteTests
    {
        /* AAA -> Arrange (Objeto em si, vai testar a entidade), 
                  Act (Ação que você esta testando),
                  Assert (Saber se o resultado esperado deu certo ou não). */

        [TestMethod]
        public void Cliente_ValidarConsistencia_True()
        {
            // Arrange
            var cliente = new Cliente()
            {
                CPF = "30390600822",
                Email = "cliente@cliente.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            // Act
            var result = cliente.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Cliente_ValidarConsistencia_False()
        {
            // Arrange
            var cliente = new Cliente()
            {
                CPF = "30390600821",
                Email = "cliente@hotmail..com",
                DataNascimento = new DateTime(2016, 01, 01)
            };

            // Act
            var result = cliente.IsValid();

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um e-mail inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente não tem maioridade para cadastro."));
        }
    }
}
