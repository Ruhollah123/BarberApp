using Entities.Models;

namespace BarberApp
{
    internal class CartPage : Page
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public override ChangePageRequest ChangePage()
        {
            return new ChangePageRequest() { Page = "Cart-page" };
        }

        public override void Draw()
        {
            Console.Clear();
            int nextX = 0;
            int nextY = 7;
            int rowHeight = 7;

            List<string> showCart = new List<string>()
            {
                "",
                "",
                ""
            };
            Window cartWindow = new("Cart-Page", X, Y, showCart);
            cartWindow.Draw();

            if (nextX + cartWindow.WindowWidth > Width)
            {
                nextX = 0;
                nextY += rowHeight;
            }

            Console.ReadKey();
        }

        public override void ManageInput()
        {

        }
    }
}
