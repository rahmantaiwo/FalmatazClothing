﻿namespace FalmatazClothing.Entities
{
    public class Product : Auditability
    {
        public string Name { get; set; }
        public Guid MaterialTypeId {  get; set; }
        public MaterialType MaterialType { get; set; }
        public string ImageProduct { get; set; }
        public decimal Price { get; set; }
    }
}
