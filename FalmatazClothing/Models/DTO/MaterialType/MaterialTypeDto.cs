using FalmatazClothing.Entities;
using System.ComponentModel.DataAnnotations;

namespace FalmatazClothing.Models.DTO.MaterialType
{
    public class MaterialTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
