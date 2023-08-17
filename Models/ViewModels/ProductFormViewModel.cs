namespace OnlineMenu.Models.ViewModels
{
    public class ProductFormViewModel
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
