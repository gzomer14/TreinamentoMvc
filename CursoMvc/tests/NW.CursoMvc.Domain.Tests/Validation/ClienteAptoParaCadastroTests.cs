using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Domain.Validation.Clientes;
using Rhino.Mocks;

namespace NW.CursoMvc.Domain.Tests.Validation
{
    [TestClass]
    public class ClienteAptoParaCadastroTests
    {
        [TestMethod]
        public void ClienteApto_IsValid_True()
        {
            // Arrange
            var cliente = new Cliente()
            {
                CPF = "30390600822",
                Email = "cliente@cliente.com"
            };

            // Act
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(null);
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(null);

            var validationReturn = new ClienteAptoParaCadastroValidation(repo).Validate(cliente);

            // Assert
            Assert.IsTrue(validationReturn.IsValid);
        }

        [TestMethod]
        public void ClienteApto_IsValid_False()
        {
            // Arrange
            var cliente = new Cliente()
            {
                CPF = "30390600821",
                Email = "cliente@cliente..com"
            };

            // Act
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(cliente);
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(cliente);

            var validationReturn = new ClienteAptoParaCadastroValidation(repo).Validate(cliente);

            // Assert
            Assert.IsFalse(validationReturn.IsValid);
            Assert.IsTrue(validationReturn.Erros.Any(e=>e.Message == "CPF já cadastrado! Esqueceu sua senha?"));
            Assert.IsTrue(validationReturn.Erros.Any(e=>e.Message == "E-mail já cadastrado! Esqueceu sua senha?"));
        }
    }
}