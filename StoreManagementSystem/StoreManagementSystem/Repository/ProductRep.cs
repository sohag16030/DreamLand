using StoreManagementSystem.DbContexts;
using StoreManagementSystem.Helper;
using StoreManagementSystem.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Repository
{
    public class ProductRep : IProduct
    {
        private readonly MyDbContext _context;
        public ProductRep(MyDbContext context)
        {
            _context = context;
        }

        public async Task<MessageHelper> AddProduct(Models.Product objCreate)
        {
            var count = _context.Products.Where(x => x.ProductName.Trim().ToLower() == objCreate.ProductName.Trim().ToLower() && x.ProductId != objCreate.ProductId).Count();
            if (count > 0)
                throw new Exception($"{objCreate.ProductName}Product exist");

            var countExUser = _context.Users.Where(x => x.UserName.Trim().ToLower() == objCreate.UserName.Trim().ToLower()).Count();
            if (countExUser == 0)
                throw new Exception($"{objCreate.UserName}InValid User");

            var productObj = new Models.Product
            {
                UserId = (from x in _context.Users where x.UserName.Trim().ToLower() == objCreate.UserName.Trim() && x.Active == true select x.UserId).FirstOrDefault(),
                UserName = objCreate.UserName,
                ProductName = objCreate.ProductName,
                ProductPrice = objCreate.ProductPrice,
                Active = true,
                LastActionDateTime = DateTime.UtcNow
            };

            await _context.Products.AddAsync(productObj);
            await _context.SaveChangesAsync();

            var msg = new MessageHelper();
            msg.Message = "Product Created Successfully";
            msg.statuscode = 200;

            return msg;
        }

        public async Task<MessageHelper> DeActivateProduct(int id)
        {
            var exitProduct =await Task.FromResult((from a in _context.Products where a.ProductId == id select a).FirstOrDefault());
         
            exitProduct.Active = false;

            _context.Products.Update(exitProduct);
            _context.SaveChanges();

            var msg = new MessageHelper();
            msg.Message = "Deleted successfully";
            msg.statuscode = 200;
            return msg;
        }

        public async Task<MessageHelper> EditProduct(Models.Product model)
        {
            var countExProduct = _context.Products.Where(x => x.ProductName.Trim().ToLower() == model.ProductName.Trim().ToLower() && x.ProductId != model.ProductId).Count();
            if (countExProduct > 0)
                throw new Exception($"{model.ProductName}Product exist");

            var exitProduct = await Task.FromResult((from a in _context.Products where a.ProductId == model.ProductId select a).FirstOrDefault());
            exitProduct.ProductName = model.ProductName;
            exitProduct.ProductPrice = model.ProductPrice;

             _context.Products.Update(exitProduct);
             _context.SaveChanges();

            var msg = new MessageHelper();
            msg.Message = "updated successfully";
            msg.statuscode = 200;
            return msg;
        }
        public async Task<MessageHelper> EditDeletedProduct(Models.Product model)
        {
            var countExProduct = _context.Products.Where(x => x.ProductName.Trim().ToLower() == model.ProductName.Trim().ToLower() && x.ProductId != model.ProductId).Count();
            if (countExProduct > 0)
                throw new Exception($"{model.ProductName}Product exist");

            var exitProduct = await Task.FromResult((from a in _context.Products where a.ProductId == model.ProductId select a).FirstOrDefault());
            exitProduct.ProductName = model.ProductName;
            exitProduct.ProductPrice = model.ProductPrice;
            exitProduct.Active = model.Active;

            _context.Products.Update(exitProduct);
            _context.SaveChanges();

            var msg = new MessageHelper();
            msg.Message = "updated successfully";
            msg.statuscode = 200;
            return msg;
        }


        public async Task<Models.Product> LoadProduct(int id)
        {
            var product = await Task.FromResult((from a in _context.Products where id == a.ProductId select a).FirstOrDefault());
            return product;
        }
    }
}
