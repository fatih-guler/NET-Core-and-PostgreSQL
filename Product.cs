using System;
using System.ComponentModel.DataAnnotations;

namespace netcore_postgre
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyDate { get; set; }        
    }
}