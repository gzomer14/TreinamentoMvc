using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW.CursoMvc.Domain.Entities
{
    public class Fornecedor
    {

        public Fornecedor()
        {
            FornecedorId = Guid.NewGuid();
            Produtos = new List<Produto>();
        }
        [Key]
        public Guid FornecedorId { get; set; }

        public string nome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public DateTime dataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool ativo { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

    }
}