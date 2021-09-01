using StoreManagementSystem.Helper;
using StoreManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.IRepository
{
    public interface IProduct
    {
        public Task<MessageHelper> AddProduct(Product objCreate);
        public Task<Product> LoadProduct(int id);
        public Task<MessageHelper> EditProduct(Product model);
        public Task<MessageHelper> EditDeletedProduct(Product model);
        public Task<MessageHelper> DeActivateProduct(int id);
    }
}
