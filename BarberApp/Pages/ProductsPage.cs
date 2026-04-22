using Entities.Models;
using Services.Interfaces;
using System.Runtime.InteropServices;

namespace BarberApp.Pages
{
    internal class ProductsPage : Page
    {
        public bool AddMode { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        private readonly IProductService _productService;
        private List<Product> _products;

        public ProductsPage(IProductService service, List<Product> products)
        {
            _productService = service;
            _products = products;

            Products = _productService.GetAllProductsAsync().Result;
        }

        public override ChangePageRequest ChangePage()
        {
            if (ShouldChangePage)
            {
                return new ChangePageRequest() { Page = "Home" };
            }
            return null;
        }

        public override void Draw()
        {
            Console.Clear();

            int nextX = 0;
            int nextY = 0;

            for (int i = 0; i < Products.Count; i++)
            {
                List<string> showProducts = new List<string>()
                {
                    $"{Products[i].Id}",
                    $"Name: {Products[i].Name}",
                    $"Price: {Products[i].Price} kr",
                };

                Window productsWindow = new Window(Products[i].Name, nextX, nextY, showProducts);

                productsWindow.Draw();

                nextX += productsWindow.WindowWidth + 2;

                if (nextX + productsWindow.WindowWidth > Width)
                {
                    nextX = 0;
                    nextY += 5;
                }

            }

            Console.WriteLine("Enter A to add products to cart");
            Console.WriteLine("Enter C to go back to menu");
        }

        public override void ManageInput()
        {
            var key = Console.ReadKey(true).KeyChar;
            if (int.TryParse(key.ToString(), out int productInput))
            {
                productInput -= 1;

                if (productInput <= Products.Count && productInput > 0)
                {
                    ShouldChangePage = true;
                }
            }
            else
            {
                char optionChosen = char.ToUpper(key);
                switch (optionChosen)
                {
                    case 'A':
                        SelectedProduct();
                        AddMode = true;
                        ShouldChangePage = false;
                        break;
                    case 'C':
                        AddMode = false;
                        ShouldChangePage = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void SelectedProduct()
        {
            Console.Write("\nChoose The Product: ");
            if (int.TryParse(Console.ReadLine(), out int productChosen))
            {
                var product = Products.FirstOrDefault(p => p.Id == productChosen);

                if (product != null)
                {
                    _products.Add(product);
                    Console.WriteLine($"\n{product.Name} Added To Cart!");
                }
                else
                {
                    Console.WriteLine("\nProduct not found");
                }
            }

            Console.WriteLine("Enter any key to continue!");
            Console.ReadKey();
        }
    }
}
