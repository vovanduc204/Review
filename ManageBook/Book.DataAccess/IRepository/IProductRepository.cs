﻿using Book.Models;

namespace Book.DataAccess.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}