using Entities.Models;

namespace BarberApp
{
    internal class ProductsPage : Page
    {
        public bool AddMode { get; set; }
        public List<Product> Products { get; set; } = new List<Product>()
        {
            new Product { Id = 1, Name = "Matte Wax Professional", Price = 189.00m },
            new Product { Id = 2, Name = "Shampoo Deep Clean 500ml", Price = 249.00m },
            new Product { Id = 3, Name = "Conditioner Silk Smooth", Price = 229.00m },
            new Product { Id = 4, Name = "Beard Oil Sandalwood", Price = 159.00m },
            new Product { Id = 5, Name = "Argan Oil Hair Treatment", Price = 349.00m },
            new Product { Id = 6, Name = "Sea Salt Spray Volume", Price = 199.00m }
        };

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

            int nextX = 6;
            int nextY = 0;
            int windowHeight = 5;

            for (int i = 0; i < Products.Count; i++)
            {

                List<string> showProducts = new List<string>()
                {
                    $"{Products[i].Id}",
                    $"Name: {Products[i].Name}",
                    $"Price: {Products[i].Price} kr",
                };

                Window productsWindow = new Window(Products[i].Name, nextX, nextY, showProducts);

                if (nextX + productsWindow.WindowWidth > Width)
                {
                    nextX = 0;
                    nextY += windowHeight;
                }

                productsWindow.Draw();
                nextX += productsWindow.WindowWidth + 2;
            }

            Console.WriteLine("Enter A to add products to cart");
            Console.WriteLine("Enter C to go back to menu");
        }

        public override void ManageInput()
        {
            var key = Console.ReadKey().KeyChar;
            if (int.TryParse(key.ToString(), out int productInput))
            {
                productInput -= 1;

                if (productInput <= Products.Count && productInput >= 0)
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
    }
}
