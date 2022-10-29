using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.DtoModels
{
    public class EmpresaDto
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Nit { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

    }
}
