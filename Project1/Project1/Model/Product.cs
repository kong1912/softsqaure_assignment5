using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Project1.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{get; set;}
        public int Price {  get; set;}
        public string Category { get; set; }
        public string? Subcategory { get; set; }


    }
}
