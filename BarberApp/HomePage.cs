using System;
using System.Collections.Generic;
using System.Text;

namespace BarberApp
{
    internal class HomePage : Page
    {
        public override ChangePageRequest ChangePage()
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {

            List<string> menuContent = new List<string>()
            {
                "1. Home",
                "2. Book an appointment",
                "3. View appointments",
                "4. Services",
                "5. Shop",
                "6. Cart",
                "7. Log in"
            };


            Window theMenu = new Window("Menu", X, Y, menuContent);
            theMenu.Draw();
        }

        public override void ManageInput()
        {
            throw new NotImplementedException();
        }
    }
}
