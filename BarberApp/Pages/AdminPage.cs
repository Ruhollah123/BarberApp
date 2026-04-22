using Entities.Models;
using Services.Interfaces;

namespace BarberApp.Pages
{
    internal class AdminPage(IProductService productService, IServicesService servicesService) : Page
    {
        public bool AddMode { get; set; }
        public bool SelectMode { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public User User { get; set; }

        private List<string> thingsToAdd = new List<string>()
        {
                "1. Add A Product",
                "2. Add A Service",
                "3. Manage User",
                "4. Update Schedule",
                "5. Back to menu",
        };

        public override ChangePageRequest ChangePage()
        {
            if (!AddMode && !SelectMode)
            {
                return new ChangePageRequest() { Page = "Home" };
            }

            return null;
        }

        public override void Draw()
        {
            Console.Clear();
            int nextX = 0;
            int nextY = 5;
            int paddingX = 0;
            int paddingY = 7;

            Window adminWindow = new("Manage", nextX, nextY, thingsToAdd);


            if (nextX + adminWindow.WindowWidth > Width)
            {
                nextX = 0;
                nextY += paddingY;
            }

            adminWindow.Draw();
            nextX += adminWindow.WindowWidth + 2;
            Console.Write("Select input corresponding to your desired action: ");
        }

        public override void ManageInput()
        {
            char choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1':
                    AddProducts();
                    break;

                case '2':
                    AddServices();
                    break;

                case '3':
                    ManageUser();
                    break;

                case '4':
                    ManageSchedule();
                    break;

                case '5':
                    AddMode = false;
                    SelectMode = false;
                    ShouldChangePage = true;
                    break;
            }
        }


        private void AddProducts()
        {
            Console.Clear();
            Console.WriteLine("---ADDING PRODUCT ---");

            Console.Write("\nEnter Product Name: ");
            var newProduct = Console.ReadLine();

            Console.Write("Enter Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal productPrice))
            {
                var product = new Product { Name = newProduct!, Price = productPrice, BarberShopId = 1 };
                productService.AddProductsAsync(product).Wait();
                Console.WriteLine("Product added!");
            }

            Console.WriteLine("Enter any key to go back to menu");
            Console.ReadKey();
        }

        private void AddServices()
        {
            Console.Clear();
            Console.WriteLine("---ADDING SERVICE ---");

            Console.Write("\nEnter Name: ");
            var serviceName = Console.ReadLine();

            Console.Write("Enter Descrption: ");
            var nameOfDescription = Console.ReadLine();

            Console.Write("How long does it take: ");
            var durationTime = Console.ReadLine();

            Console.Write("How much does it cost: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal theCost))
            {
                var service = new Service { Name = serviceName, Description = nameOfDescription, Duration = durationTime, Price = theCost };
                servicesService.AddServicesAsync(service);

                Console.WriteLine("Service added!");
            }


            Console.WriteLine("New Service Added!");
            Console.WriteLine("Enter any key to go back to menu");
            Console.ReadKey();
        }

        private void ManageUser()
        {
            Console.Clear();
            Console.WriteLine("--- MANAGING USERS ---");

            Console.Write("\nEnter Name: ");
            var userName = Console.ReadLine();

            Console.Write("Enter A Unique Username: ");
            var uniqueName = Console.ReadLine();

            Console.WriteLine("Enter Registration Date (YYYY-MM-DD): ");

            if (DateTime.TryParse(Console.ReadLine(), out DateTime userDate))
            {
                User.CreatedAt = userDate;
            }
            else
            {
                Console.WriteLine("Today's date will be set");
                User.CreatedAt = DateTime.Now;
            }

            Console.WriteLine("New User Added!");
            Console.WriteLine("Enter any key to go back to menu");
            Console.ReadKey();
        }

        private void ManageSchedule()
        {
            Console.Clear();
            Console.WriteLine("--- MANAGING SCHEDULE ---");

            Console.WriteLine("\n");

            List<string> scheduleInfo = new List<string>();

            scheduleInfo.Add("Time  |    Mon |    Tue   |     Wed    |    Thu   |     Fri ");
            scheduleInfo.Add("--------------------------------------------------------------");

            for (int hour = 9; hour <= 15; hour++)
            {
                string hourString = hour.ToString().PadLeft(2);

                string row = $"{hourString}:00 |";
                row += " [FREE] |   [FREE] |   [BOOKED] |   [FREE] |   [BOOKED]";
                scheduleInfo.Add(row);
            }
            Console.ReadKey();

        }
    }
}
