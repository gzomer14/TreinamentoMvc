using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NW.CursoMvc.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            ProdutoId = Guid.NewGuid();
        }

        [Key]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
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

        [ScaffoldColumn(false)]
        public Guid FornecedorId { get; set; }
    }
}