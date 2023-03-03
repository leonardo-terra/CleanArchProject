using Domain.Validation;

namespace Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Name must have at least 3 characters");
            
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
            DomainExceptionValidation.When(description.Length < 10, "Description must have at least 3 characters");

            DomainExceptionValidation.When(price < 0, "Invalid Price.");
            
            DomainExceptionValidation.When(stock < 0, "Invalid Stock.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Image is required");
            DomainExceptionValidation.When(image.Length < 10, "Description must have at least 10 characters");
        }
    }
}
