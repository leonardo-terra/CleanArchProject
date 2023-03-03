using Domain.Validation;

namespace Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id");
            ValidateDomain(name, description, price, stock, image);
            Id = id;
        }
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);

        }

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

            Name = name; Description = description; Price = price; Stock = stock; Image = image;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;

        }
    }
}
