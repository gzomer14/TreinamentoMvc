using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NW.CursoMvc.Application.ViewModels
{
    public class FornecedorProdutoViewModel
    {
        public FornecedorProdutoViewModel()
        {
            FornecedorId = Guid.NewGuid();
            ProdutoId = Guid.NewGuid();
        }

        //Fornecedor

        [Key]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo cpf")]
        [MaxLength(11, ErrorMessage = "Máximo 11 caracteres")]
        [DisplayName("CPF")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Preencha o campo email")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime dataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool ativo { get; set; }

        //Produto

        [Key]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Nome do produto")]
        public string nomeProd { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [DisplayName("Descrição")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor")]
        [DisplayName("Valor")]
        public double valor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Peso")]
        [DisplayName("Peso")]
        public double peso { get; set; }
    }
}