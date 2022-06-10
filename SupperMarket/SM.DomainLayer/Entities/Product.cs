namespace SM.DomainLayer.Entities
{
    public class Product 
    {
        public Product()
        {

        }
        public Product(string name, string description, decimal price, string pictureUrl, Category category, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
            Category = category;
            CategoryId = categoryId;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUrl { get; private set; }
        public Category Category { get; private set; }
        public int CategoryId { get; private set; }

    }
}