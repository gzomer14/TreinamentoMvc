using DomainValidation.Validation;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Domain.Specifications.Clientes;

namespace NW.CursoMvc.Domain.Validation.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var emailDuplicado = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, "CPF já cadastrado! Esqueceu sua senha?"));
            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado,"E-mail já cadastrado! Esqueceu sua senha?"));
        }
    }
}