using DomainValidation.Validation;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Specifications.Clientes;

namespace NW.CursoMvc.Domain.Validation.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var cpfCliente = new ClienteDeveTerCpfValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaiorIdade = new ClienteDeveSerMaiorDeIdadeSpecification();

            base.Add("cpfCliente", new Rule<Cliente>(cpfCliente, "Cliente informou um CPF inválido."));
            base.Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um e-mail inválido."));
            base.Add("clienteMaiorIdade", new Rule<Cliente>(clienteMaiorIdade, "Cliente não tem maioridade para cadastro."));
        }
    }
}