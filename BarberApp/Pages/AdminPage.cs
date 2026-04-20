namespace BarberApp.Pages
{
    internal class AdminPage : Page
    {
        public bool AddMode { get; set; }
        public bool SelectMode { get; set; }

        private List<string> thingsToAdd = new List<string>()
        {
                "1. Add Products",
                "2. Manage User",
                "3. Update Schedule",
                "4. Back to menu",
        };

        public override ChangePageRequest ChangePage()
        {
            if (AddMode)
            {
                return new ChangePageRequest() { Page = "Add-product" };
            }
            else if (SelectMode)
            {
                return new ChangePageRequest() { Page = "Manage-User" };
            }
            else if (!AddMode && !SelectMode)
            {
                return new ChangePageRequest() { Page = "Home" };
            }
            else
            {
                return new ChangePageRequest() { Page = "Update-schedule" };
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
            var key = Console.ReadKey(true).KeyChar;

            if (int.TryParse(key.ToString(), out int input))
            {
                input -= 1;

                if (input <= thingsToAdd.Count && input >= 0)
                {
                    ShouldChangePage = true;
                }
            }
            else
            {
                char choice = char.ToUpper(key);
                switch (choice)
                {
                    case '1':
                        AddMode = true;
                        ShouldChangePage = true;
                        break;
                    case '2':
                        SelectMode = true;
                        ShouldChangePage = true;
                        break;

                    case '3':
                        SelectMode = true;
                        ShouldChangePage = true;
                        break;
                    case '4':
                        AddMode = false;
                        SelectMode = false;
                        ShouldChangePage = true;
                        break;
                }
            }
        }
    }
}
