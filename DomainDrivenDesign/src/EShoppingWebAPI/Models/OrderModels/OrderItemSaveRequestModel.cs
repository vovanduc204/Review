namespace EShoppingWebAPI.Models.OrderModels
{
    public class OrderItemSaveRequestModel
    {
        public int? ProductId { get; set; }

        public PriceSaveRequestModel Price { get; set; }
    }
}