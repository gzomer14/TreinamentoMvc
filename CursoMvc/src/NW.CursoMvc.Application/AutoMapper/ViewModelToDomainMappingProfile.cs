using AutoMapper;
using NW.CursoMvc.Application.ViewModels;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClienteEnderecoViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ClienteEnderecoViewModel, Endereco>();

            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<FornecedorProdutoViewModel, Fornecedor>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<FornecedorProdutoViewModel, Produto>();
        }
    }
}