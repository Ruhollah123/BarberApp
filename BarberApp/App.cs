using BarberApp.Pages;
using EFCore;
using EFCore.Repositories;
using Entities.Models;
using Services;

namespace BarberApp
{
    public class App
    {
        public Page Page { get; set; }
        public static User? CurrentUser { get; set; }
        public List<Product> SelectedProducts { get; set; } = new List<Product>();
        public List<Appointment> SelectedAppointments { get; set; } = new List<Appointment>();
        public Service service { get; set; }

        public readonly BarberAppDbContext _context = new();
        public App()
        {

        }

        public async Task Run()
        {
            await ChangePage(new ChangePageRequest { Page = "Home" });

            while (true)
            {
                Console.Clear();
                DrawHeader();
                Page.Draw();
                Page.ManageInput();
                if (Page.ShouldChangePage)
                {
                    ChangePageRequest? request = Page.ChangePage();
                    if (request != null)
                    {
                        await ChangePage(request);
                    }
                }
            }
        }

        private void DrawHeader()
        {
            List<string> listTitles = new() { "    === Welcome to ===", "=== The Cut-Algorithm === " };
            string longestItem = listTitles.OrderBy(s => s.Length).First();
            int x = (Console.WindowWidth - longestItem.Length) / 2 - 4;
            Window window = new Window("", 0, 0, listTitles);
            window.Draw();


        }

        private async Task ChangePage(ChangePageRequest changePageRequest)
        {
            var servicesService = new ServicesService(new ServicesRepository(_context));
            var productsService = new ProductService(new ProductRepository(_context));
            var appointmentService = new Services.AppointmentService(new AppointmentRepository(_context));
            var orderService = new OrderService(new OrderRepository(_context));

            switch (changePageRequest.Page)
            {
                case "Home":
                    Page = new HomePage();
                    break;

                case "Services":
                    Page = new ServicePage(servicesService, SelectedAppointments);
                    break;

                case "Booking-appointment":

                    Page = new BookingPage(appointmentService, SelectedAppointments, service);
                    break;

                case "Products":
                    Page = new ProductsPage(productsService, SelectedProducts, SelectedAppointments);
                    break;

                case "Cart-page":
                    Page = new CartPage(SelectedProducts, SelectedAppointments);
                    switch (changePageRequest.Action)
                    {
                        case RequestAction.Get:
                            break;
                    }
                    break;

                case "Log-in":
                    Page = new LoginPage();
                    break;

                case "admin":
                    Page = new AdminPage(productsService, servicesService);
                    break;
                default:

                    break;
            }
        }
    }
}
