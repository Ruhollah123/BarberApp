using Entities.Models;

namespace BarberApp
{
    internal class LoginPage : Page
    {
        public override ChangePageRequest ChangePage()
        {
            return new ChangePageRequest() { Page = "user" };
        }

        public override void Draw()
        {
            Console.Clear();
            List<string> userList = new List<string>() { "Enter your name: " + new string(' ', 20) };
            Window userWindow = new Window("Login", X, Y, userList);
            userWindow.Draw();
            Console.SetCursorPosition(X + 19, Y + 1);
            var UserName = Console.ReadLine();

            App.CurrentUser = new User
            {
                Name = UserName,
                Customer = new Customer {
                Role = new Role { Name = (UserName.ToLower() == "admin" ? "admin" : "customer")}
                }
            };

            ShouldChangePage = true;
        }

        public override void ManageInput()
        {
            throw new NotImplementedException();
        }
    }
}