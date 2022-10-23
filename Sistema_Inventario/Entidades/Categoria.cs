﻿using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.Entidades
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Descripcion { get; set; }

        public int? Estado { get; set; }
    }
}
