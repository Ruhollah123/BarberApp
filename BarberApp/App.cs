using Entities.Models;

namespace BarberApp
{
    public class App
    {
        public Page Page { get; set; }
        public static User? CurrentUser { get; set; }

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
            switch (changePageRequest.Page)
            {
                case "Home":
                    Page = new HomePage();
                    break;

                case "Services":
                    Page = new ServicePage();
                    break;

                case "Booking-appointment":
                    Page = new BookingPage();
                    break;

                case "Products":
                    Page = new ProductsPage();
                    break;

                case "Cart-page":
                    Page = new CartPage();
                    switch (changePageRequest.Page)
                    {

                    }
                    break;

                case "Log-in":
                    Page = new LoginPage();
                    break;

                case "admin":
                    Page = new AdminPage();
                    break;
                default:

                    break;
            }
        }
    }
}
