using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.IService;
using Entities;
using DAL;

namespace BLL.Service
{
    public class ProductService:IProductservice
    {
        public List<Product> GetAllProducts()
        {
            return DALProduct.GetAllProducts();
        }
        public Product GetProductById(int id)
        {
            return DALProduct.GetProductById(id);
        }
        public void AddProduct(Product product)
        {
            DALProduct.AddProduct(product);
        }
        public void UpdateProduct(Product product) {
            DALProduct.UpdateProduct(product);
        }
        public void DeleteProduct(int id)
        {
            DALProduct.DeleteProduct(id);

        }
    }
}
