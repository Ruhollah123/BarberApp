using Entities.Models;
using Services.Interfaces;

namespace BarberApp.Pages
{
    internal class ProductsPage : Page
    {
        public bool AddMode { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        private List<Product> _cart;
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        private readonly IProductService _productService;
        private readonly IAppointmentService _appointmentService;
        private List<Appointment> _appointments;

        public ProductsPage(IProductService service, IAppointmentService appointmentService, List<Product> cart, List<Appointment> apointments)
        {
            _productService = service;
            _cart= cart;
            Appointments = apointments;
            _appointmentService = appointmentService;
        }

        public override ChangePageRequest ChangePage()
        {
            if (ShouldChangePage)
            {
                return new ChangePageRequest() { Page = "Home" };
            }
            return null;
        }

        public override async void Draw()
        {
            Console.Clear();

            if (Products.Count == 0)
            {
                Products = await _productService.GetAllProductsAsync();
                Appointments = await _appointmentService.GetAllAppointmentsAsync();

            }
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
            Console.WriteLine("Enter B to view statistics");
            Console.WriteLine("Enter C to go back to menu");
        }

        public override async void ManageInput()
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
                switch (char.ToUpper(key))
                {
                    case 'A':
                        SelectedProduct();
                        AddMode = true;
                        ShouldChangePage = false;
                        break;
                    case 'B':
                        await ShowStatistics();
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

        private async Task ShowStatistics()
        {

            Console.Clear();
            Console.WriteLine("Enter X To View Most Sold Product");
            Console.WriteLine("Enter K To View Total Revenue");
            Console.WriteLine("Enter P To View Busiest hours ");

            var key = char.ToUpper(Console.ReadKey(true).KeyChar);
            switch (key)
            {
                case 'X':
                    Console.Clear();
                    var freshProducts = await _productService.GetAllProductsAsync();
                    var topProduct = freshProducts
                        .GroupBy(p => p.Name)
                        .OrderByDescending(g => g.Count())
                        .Select(g => new { Name = g.Key, Amount = g.Count() })
                        .FirstOrDefault();
                    Console.WriteLine($"\nMost Sold Product: {topProduct?.Name} ({topProduct?.Amount} units)");
                    break;

                case 'K':
                    var productsRevenue = await _productService.GetAllProductsAsync();

                    decimal totalRevenu = productsRevenue.Sum(p => p.Price);
                    Console.WriteLine($"\nTotal Revenue: {totalRevenu} kr.");
                    Console.ReadKey();
                    break;

                case 'P':
                    var appointmentsHours = await _appointmentService.GetAllAppointmentsAsync();
                    var busyHour = appointmentsHours
                        .GroupBy(a => a.DateTime.Hour)
                        .OrderByDescending(g => g.Count())
                        .Select(g => new { Hour = g.Key, Count = g.Count() })
                        .FirstOrDefault();
                    Console.WriteLine($"\nBusiest Time: {busyHour?.Hour}:00 ({busyHour?.Count} bookings)");
                    Console.ReadKey();
                    break;

                default:
                    break;
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
                    _cart.Add(product);
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
