using AutoMapper;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Models;
using primeiraApi.ValueObjects;

namespace primeiraApi.Mapping;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<ClienteRequestDto, Cliente>()
            .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => new Cpf(src.Cpf)));

        CreateMap<Cliente, ClienteResponseDto>()
            .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf.ToString()));

        CreateMap<AdministradorRequestDto, Administrador>();
        CreateMap<AdministradorUpdateRequestDto, Administrador>();
        CreateMap<Administrador, AdministradorResponseDto>();

        CreateMap<ProdutoRequestDto, Produto>();
        CreateMap<Produto, ProdutoResponseDto>();

        CreateMap<PedidoItemRequestDto, PedidoProduto>();
        CreateMap<PedidoProduto, PedidoItemResponseDto>()
            .ForMember(dest => dest.ProdutoNome, opt => opt.MapFrom(src => src.Produto != null ? src.Produto.Nome : string.Empty));

        CreateMap<Pedido, PedidoResponseDto>()
            .ForMember(dest => dest.ClienteNome, opt => opt.MapFrom(src => src.Cliente != null ? src.Cliente.Nome : string.Empty))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Itens.Sum(i => i.Quantidade * i.PrecoUnitario)));
    }
}
