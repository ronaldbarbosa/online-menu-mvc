using System.ComponentModel.DataAnnotations;

namespace OnlineMenu.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
