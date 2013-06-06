using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace ShoppingCenter
{
    public class ShoppingCenterMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            int n = int.Parse(Console.ReadLine());
            StringBuilder finalOutput = new StringBuilder();
            ShoppingCenter shopCenter = new ShoppingCenter();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] splitted = line.Split(' ');
                string command = splitted[0];
                string parameters = null;

                for (int j = 1; j < splitted.Length; j++)
                {
                    parameters += splitted[j];
                }

                string[] splititedParameters = parameters.Split(';');

                if (command == "AddProduct")
                {
                    finalOutput.AppendLine(shopCenter.AddProduct(splititedParameters[0],
                        double.Parse(splititedParameters[1]), splititedParameters[2]));
                }
                else if (command == "DeleteProducts" && splititedParameters.Length == 2)
                {
                    finalOutput.AppendLine(shopCenter.DeleteProduct(splititedParameters[0], splititedParameters[1]));
                }
                else if (command == "DeleteProducts" && splititedParameters.Length == 1)
                {
                    finalOutput.AppendLine(shopCenter.DeleteProduct(splititedParameters[0]));
                }
                else if (command == "FindProductsByName")
                {
                    finalOutput.AppendLine(shopCenter.FindProductsByName(splititedParameters[0]));
                }
                else if (command == "FindProductsByPriceRange")
                {
                    finalOutput.AppendLine(shopCenter.FindProductsByPriceRange(double.Parse(splititedParameters[0]),
                        double.Parse(splititedParameters[1])));
                }
                else if (command == "FindProductsByProducer")
                {
                    finalOutput.AppendLine(shopCenter.FindProductsByProducer(splititedParameters[0]));
                }
            }

            Console.WriteLine(finalOutput);
        }
    }

    public class ShoppingCenter
    {
        public Dictionary<string, List<Product>> Products { get; private set; }

        private Dictionary<double, List<Product>> productByPrice = new Dictionary<double, List<Product>>();

        public ShoppingCenter()
        {
            this.Products = new Dictionary<string, List<Product>>();
        }

        public string AddProduct(string name, double price, string producer)
        {
            List<Product> products;
            if (this.Products.ContainsKey(name))
            {
                products = this.Products[name];
                this.Products.Remove(name);
            }
            if (this.Products.ContainsKey(producer))
            {
                products = this.Products[producer];
                this.Products.Remove(producer);                
            }
            if (this.productByPrice.ContainsKey(price))
            {
                products = this.productByPrice[price];
                this.productByPrice.Remove(price);
            }
            else
            {
                products = new List<Product>();
                Product productToAdd = new Product(name, producer, price);
                products.Add(productToAdd);
                this.Products.Add(name, products);
                this.Products.Add(producer, products);
                this.productByPrice.Add(price, products);
            }

            return "Product Added";
        }

        public string DeleteProduct(string name, string producer)
        {
            int productsDeleted = 0;

            foreach (var keyVal in this.Products)
            {
                foreach (var item in keyVal.Value)
                {
                    if (item.Name == name && item.Producer == producer)
                    {
                        productsDeleted++;
                        this.Products.Remove(keyVal.Key);
                    }
                }
            }

            if (productsDeleted == 0)
            {
                return "No products found";
            }

            return productsDeleted + " products deleted";
        }

        public string DeleteProduct(string producer)
        {
            int productsDeleted = 0;
            
            if (this.Products.ContainsKey(producer))
            {
                productsDeleted++;
                this.Products.Remove(producer);
            }

            if (productsDeleted == 0)
            {
                return "No products found";
            }

            return productsDeleted + " products deleted";
        }

        public string FindProductsByName(string name)
        {
            StringBuilder output = new StringBuilder();
            int productsFound = 0;
            if (this.Products.ContainsKey(name))
            {
                var productList = this.Products[name].OrderBy(x => x.ToString());
                foreach (var product in productList)
                {
                    output.AppendLine(product.ToString());
                    productsFound++;
                }
            }
            if (productsFound == 0)
            {
                return "No products found";
            }

            return output.ToString();
        }

        public string FindProductsByPriceRange(double priceFrom, double priceTo)
        {
            StringBuilder output = new StringBuilder();
            int productsFound = 0;
            List<Product> priceditems = new List<Product>();
            foreach (var listProducts in this.Products.Values)
            {
                foreach (var product in listProducts)
                {
                    if (product.Price >= priceFrom && product.Price <= priceTo)
                    {
                        priceditems.Add(product);
                        productsFound++;
                    }
                }
            }

            var orderedItems = priceditems.OrderBy(x => x.ToString());

            foreach (var item in orderedItems)
            {
                output.AppendLine(item.ToString());
            }
            if (productsFound == 0)
            {
                return "No products found";
            }
            return output.ToString();
        }

        public string FindProductsByProducer(string producer)
        {
            StringBuilder output = new StringBuilder();

            if (this.Products.ContainsKey(producer))
            {
                var productList = this.Products[producer].OrderBy(x => x.ToString());
                foreach (var product in productList)
                {
                    output.AppendLine(product.ToString());
                }
            }

            return output.ToString();  
        }
    }

    public class Product
    {
        public string Name { get; private set; }

        public string Producer { get; private set; }

        public double Price { get; private set; }

        public int Count { get; set; }

        public Product(string name, string producer, double price)
        {
            this.Count = 1;
            this.Name = name;
            this.Producer = producer;
            this.Price = price;
        }

        public override string ToString()
        {
            return "{" + this.Name + ";" + this.Producer + ";" + this.Price.ToString("0.00") + "}";
        }
    }
}