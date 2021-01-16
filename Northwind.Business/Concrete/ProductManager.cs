using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.ValudationRules.FluentValidation;
using Northwind.DataAcces.Abstract;
using Northwind.DataAcces.Concrete;
using Northwind.DataAcces.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
                _productDal.Add(product);
            
        }

        public void Delete(Product product)
        {
            try
            {
            _productDal.Delete(product);
            }
            catch
            {
                throw new Exception("Deletion Failed");
            }

        }

        public  List<Product> GetAll()
        {
            //Business Code
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string key)
        {
            return _productDal.GetAll(p=>p.ProductName.ToLower().Contains(key.ToLower()));
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
          
        }
    }
}
