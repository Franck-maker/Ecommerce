namespace Basket.Application.Responses
{
    public record class ShoppingCartResponse
    {
        public string UserName { get; init; }
        public List<ShoppingCartItemResponse> Items { get; init; }

        public ShoppingCartResponse()
        {
            UserName = string.Empty;
            Items = new List<ShoppingCartItemResponse>();
        }

        //Constructor with UserName only
        public ShoppingCartResponse(string userName) : this(userName, new List<ShoppingCartItemResponse>())
        {
           
        }

        //Full constructor
        public ShoppingCartResponse(string userName, List<ShoppingCartItemResponse> items)
        {
            userName = userName ?? string.Empty;
            items = items ?? new List<ShoppingCartItemResponse>();
        }

        public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity); 

    }
}
