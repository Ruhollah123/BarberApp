namespace BarberApp
{
    internal class HomePage : Page
    {
        public int SelectedItem { get; set; }
        public override ChangePageRequest ChangePage()
        {
            if (ShouldChangePage)
            {
                switch (SelectedItem)
                {
                    case 1:
                        return new ChangePageRequest() { Page = "Services" };
                    case 2:
                        return new ChangePageRequest() { Page = "Book-An-Appointment" };
                    case 3:
                        return new ChangePageRequest() { Page = "Products" };
                    case 4:
                        return new ChangePageRequest() { Page = "Cart" };
                    case 5:
                        if (App.CurrentUser == null)
                        {
                            return new ChangePageRequest() { Page = "Log-in" };
                        }
                        else if (App.CurrentUser.Name == "admin")
                        {
                            return new ChangePageRequest() { Page = "admin" };
                        }
                        else
                        {
                            return new ChangePageRequest() { Page = "Log-out" };
                        }
                        break;
                }
            }

            return null;
        }

        public override void Draw()
        {
            //Console.Clear();
            int positionX = X;
            int positionY = Y;

            List<string> menuContent = new List<string>()
            {
                "1. Services",
                "2. Book An Appointment",
                "3. Buy Products",
                "4. Cart",
            };


            Window theMenu = new("Menu", positionX, positionY, menuContent);

            if (positionX + theMenu.WindowWidth > Width)
            {
                positionX = 0;
                theMenu.Left = positionX;

                positionY += 10;
                theMenu.Top = positionY;
            }

            if (App.CurrentUser?.Customer?.Role?.Name == "admin")
            {
                menuContent.Add("5. Admin");
            }

            if (App.CurrentUser == null)
            {
                menuContent.Add("5. Log in");
            }
            else
            {
                menuContent.Add("6. Log out");
            }

            theMenu.Draw();
        }

        public override void ManageInput()
        {
            SelectedItem = Console.ReadKey().KeyChar;
            switch (SelectedItem)
            {
                case '1':
                    SelectedItem = 1;
                    ShouldChangePage = true;
                    break;
                case '2':
                    SelectedItem = 2;
                    ShouldChangePage = true;
                    break;
                case '3':
                    SelectedItem = 3;
                    ShouldChangePage = true;
                    break;
                case '4':
                    SelectedItem = 4;
                    ShouldChangePage = true;
                    break;
                case '5':
                    SelectedItem = 5;
                    ShouldChangePage = true;
                    break;
                default:
                    ShouldChangePage = false;
                    break;
            }
        }
    }
}