using AutoMapper;
using Sistema_Inventario.DtoModels;
using Sistema_Inventario.Entidades;

namespace Sistema_Inventario.Utilis
{
    public class InventarioMapper : Profile
    {
        public InventarioMapper()
        {
            CreateMap<Empresa, EmpresaDto>().ReverseMap();
            CreateMap<Sucursal, SucursalDto>().ReverseMap();
            CreateMap<Bodega, BodegaDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();  
            CreateMap<Proveedor, ProveedorDto>().ReverseMap();
            CreateMap<Ajuste, AjusteDto>().ReverseMap();
            CreateMap<Compra, CompraDto>().ReverseMap();
            CreateMap<Venta, VentaDto>().ReverseMap();
        }
    }
}
