using ORM.Business;
using ORM.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Presentation
{
    public class Display
    {
        private ProductBusiness productBusiness = new ProductBusiness();
        private void Show()
        {
            Console.WriteLine(new string('-',40));
            Console.WriteLine(new string(' ',18)+"Menu"+new string(' ',18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List All entries");
            Console.WriteLine("2. Add new Entry");
            Console.WriteLine("3. Delete Entry by ID");
            Console.WriteLine("4. Exit");
        }

        public void Input()
        {
            var operation = -1;
            do
            {
                Show();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAll(); break;
                    case 2: Add(); break;
                    case 3: Delete(); break;
                    default: break;
                }
            }
            while (operation != 4);
        }

        public Display()
        {
            Input();
        }

        private void Add()
        {
            Product product = new Product();
            Console.WriteLine("Enter name: ");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter stock: ");
            product.Stock = int.Parse(Console.ReadLine());
            productBusiness.Add(product);
        }

        private void Delete()
        {
            Console.WriteLine("Enter Id to delete");
            int id = int.Parse(Console.ReadLine());
            //productBusiness.Delete(id);
            Console.WriteLine("Done");
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Menu" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            List<Product> products = productBusiness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine("{0} {1} {2} {3}",item.Id,item.Name,item.Price,item.Stock);
            }
        }
    }
}
