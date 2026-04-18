using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberApp
{
    internal class HomePage : Page
    {
        public int SelectedItem { get; set; }
        public User? User { get; set; }
        public override ChangePageRequest ChangePage()
        {
            if (ShouldChangePage)
            {
                switch (SelectedItem)
                {
                    case 1:
                        return new ChangePageRequest() { Page = "welcome"};
                    case 2:
                        return new ChangePageRequest() { Page = "appointment-times"};
                    case 3:
                        return new ChangePageRequest() { Page = "viewing-appointments"};
                    case 4:
                        return new ChangePageRequest() { Page = "services"};
                    case 5:
                        return new ChangePageRequest() { Page = "Products"};
                    case 6:
                        return new ChangePageRequest() { Page = "Cart"};
                    case 7:
                        if (User == null)
                        {
                            return new ChangePageRequest() { Page = "Log-in" };
                        }
                        else
                        {
                            return new ChangePageRequest() { Page = "Log-out" };
                        }
                }
            }
            return null;
        }

        public override void Draw()
        {


            List<string> menuContent = new List<string>()
            {
                "1. Home",
                "2. Book an appointment",
                "3. View appointments",
                "4. Services",
                "5. Buy Products",
                "6. Cart",
                "7. Log in"
            };
            

            Window theMenu = new Window("Menu", X, Y, menuContent);
            theMenu.Draw();
        }

        public override void ManageInput()
        {
            //var input = ConsoleKey.1;
        }
    }
}
