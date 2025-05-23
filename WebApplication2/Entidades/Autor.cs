﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        public required string Nombre { get; set; }
        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}
