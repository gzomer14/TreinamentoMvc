using AutoMapper;
using NW.CursoMvc.Application.ViewModels;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel >();
            CreateMap<Cliente, ClienteEnderecoViewModel >();
            CreateMap<Endereco, EnderecoViewModel >();
            CreateMap<Endereco, ClienteEnderecoViewModel>();
            
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Fornecedor, FornecedorProdutoViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Produto, FornecedorProdutoViewModel>();

            CreateMap<CarrinhoCompras ,CarrinhoComprasViewModel >();
            CreateMap<CarrinhoCompras, ClienteViewModel>();
            CreateMap<ItensCarrinho, CarrinhoComprasViewModel>();
            CreateMap<ItensCarrinho, ProdutoViewModel>();
            CreateMap<ItensCarrinho, ItensCarrinhoViewModel>();

            CreateMap<HistoricoCompras, HistoricoComprasViewModel>();
        }
    }
}