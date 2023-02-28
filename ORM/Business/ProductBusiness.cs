using ORM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Business
{
    public class ProductBusiness
    {
        private ProductBusiness manager = new ProductBusiness();
        public List<Product> GetAll()
        {
            return manager.GetAll();
        }
        public void Add(Product product) 
        {
            manager.Add(product);
        }
    }
}
