using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Core.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);

        //Upsert for update or insert a new basket if it doesn't exist
        Task<ShoppingCart> UpsertBasket(ShoppingCart shoppingCart);
        Task DeleteBasket(string userName);

    }
}
