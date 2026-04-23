using Entities.Models;
using Services.Interfaces;

namespace BarberApp.Pages
{
    internal class ProductsPage : Page
    {
        public bool AddMode { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        private readonly IProductService _productService;
        private readonly IAppointmentService _appointmentService;
        private List<Product> _products;
        private List<Appointment> _appointments;


        public ProductsPage(IProductService service, IAppointmentService appointmentService, List<Product> products, List<Appointment> apointments)
        {
            _productService = service;
            _products = products;
            _appointments = apointments;
            _appointmentService = appointmentService;

            Products = _productService.GetAllProductsAsync().Result;
            Appointments = _appointmentService.GetAllAppointmentsAsync().Result;
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
            Console.WriteLine("Enter B to view statistics");
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
                    case 'B':
                        ShowStatistics();
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

        private void ShowStatistics()
        {
            Console.Clear();
            Console.WriteLine("Enter X To View Most Sold Product");
            Console.WriteLine("Enter K To View Total Revenue");
            Console.WriteLine("Enter P To View Busiest hours ");

            var key = char.ToUpper(Console.ReadKey(true).KeyChar);
            switch (key)
            {
                case 'X':
                    var freshProducts = _productService.GetAllProductsAsync().Result;
                    var topProduct = freshProducts
                        .GroupBy(p => p.Name)
                        .OrderByDescending(g => g.Count())
                        .Select(g => new { Name = g.Key, Amount = g.Count() })
                        .FirstOrDefault();
                    Console.WriteLine($"\nMost Sold Product: {topProduct?.Name} ({topProduct?.Amount} units)");
                    Console.ReadKey();
                    break;

                case 'K':
                    var productsRevenue = _productService.GetAllProductsAsync().Result;

                    decimal totalRevenu = productsRevenue.Sum(p => p.Price);
                    Console.WriteLine($"\nTotal Revenue: {totalRevenu} kr.");
                    Console.ReadKey();
                    break;

                case 'P':
                    var appointmentsHours = _appointmentService.GetAllAppointmentsAsync().Result;
                    var busyHour = _appointments
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
