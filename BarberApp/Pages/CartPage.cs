using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BarberApp.Pages
{
    public class CartPage : Page
    {
        public List<Service> Services { get; set; } = new List<Service>();
        public List<Product> SelectedProducts { get; set; } = new List<Product>();
        public List<Appointment> SelectedAppointments { get; set; } = new List<Appointment>();
        public bool AddMode { get; set; }

        public CartPage(List<Product> products, List<Appointment> appointments)
        {
            SelectedProducts = products;
            SelectedAppointments = appointments;
        }

        public override ChangePageRequest ChangePage()
        {
            if (AddMode)
            {
                return new ChangePageRequest() { Page = "Cart-page" };
            }
            else if (!AddMode)
            {
                return new ChangePageRequest() { Page = "Home" };
            }

            return null;
        }

        public override void Draw()
        {
            Console.Clear();

            int nextX = 0;
            int nextY = 7;
            int rowHeight = 7;

            decimal total = 0;
            List<string> showCart = new List<string>();

            foreach (var app in SelectedAppointments)
            {
                showCart.Add($"Appointment: {app.DateTime.ToString("g")}");
            }

            foreach (var product in SelectedProducts)
            {
                showCart.Add($"Product: {product.Name} - {product.Price} kr");
                total += product.Price;
            }

            foreach (var line in showCart)
            {
                Console.WriteLine(line);
            }

            showCart.Add("---------------");
            showCart.Add($"Total: {total} kr");


            Window cartWindow = new("Cart-Page", X, Y, showCart);
            cartWindow.Draw();

            if (nextX + cartWindow.WindowWidth > Width)
            {
                nextX = 0;
                nextY += rowHeight;
            }

            Console.WriteLine("Enter C to go back to menu");
            Console.WriteLine("Enter X to continue with the payment!");
        }

        public override void ManageInput()
        {
            var key = char.ToUpper(Console.ReadKey(true).KeyChar);

            switch (key)
            {
                case 'X':
                    SelectPaymentMethod();
                    break;

                case 'C':
                    AddMode = false;
                    ShouldChangePage = true;
                    break;
            }
        }

        private void SelectPaymentMethod()
        {
            Console.Clear();
            Console.WriteLine("--- CHOOSE PAYMENT-METHOD ---");

            Console.WriteLine("1. Card-Payment");
            Console.WriteLine("2. Swish");

            Console.WriteLine("-----------");
            Console.WriteLine("Choose (1-2): ");

            var input = Console.ReadKey(true).KeyChar;

            if (input == '1')
            {
                Console.Write("Enter your credit card-number: ");
                var cardNumber = Console.ReadLine();

                Console.Write("Enter your CVC-number: ");
                var cvcNumber = Console.ReadLine();
            }
            else if (input == '2')
            {
                Console.Write("Enter your Swish-Number: ");
                var swishNumber = Console.ReadLine();

                Console.Write($"\nYou are paying with {swishNumber}, are you sure (y/n): ");
                var confirmingWithSwish = Console.ReadKey(true);

            }

            Console.WriteLine("\nPayment Succeeded!");
            Console.WriteLine("Your cart is now empty!");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            ClearCart();
        }

        private void ClearCart()
        {
            SelectedProducts.Clear();
            SelectedAppointments.Clear();

            AddMode = false;
            ShouldChangePage = true;
        }
    }
}