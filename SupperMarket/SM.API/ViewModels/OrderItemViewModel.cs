using SM.DomainLayer.ValueObjects;

namespace SM.API.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Price Price { get; set; }
    }
}