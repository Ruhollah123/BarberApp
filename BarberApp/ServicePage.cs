using Entities.Models;

namespace BarberApp
{
    internal class ServicePage : Page
    {
        public List<Service> Services { get; set; } = new List<Service>
        {
            new Service { Name = "Hårklippning Standard", Description = "Klassisk klippning inklusive tvätt och styling.", Duration = "45 min", Price = 550m },
            new Service { Name = "Skäggtrimning", Description = "Trimning och formning av skägg med maskin och kniv.", Duration = "30 min", Price = 350m },
            new Service { Name = "Lyxpaket", Description = "Hårklippning och skäggtrimning samt varm handduk.", Duration = "75 min", Price = 850m },
            new Service { Name = "Maskinklippning", Description = "Enkel klippning med bara maskin över hela huvudet.", Duration = "20 min", Price = 250m }
        };

        public bool AddMode { get; set; }
        public bool SelectMode { get; set; }
        public char SelectedItem { get; set; }
        public override ChangePageRequest ChangePage()
        {
            ShouldChangePage = true;
            return new ChangePageRequest() { Page = "View-appointments" };
        }

        public override void Draw()
        {
            int nextX = X;
            int nextY = Y;



            for (int i = 0; i < Services.Count; i++)
            {

                List<string> showInfo = new List<string>()
                {
                    $"Name: {Services[i].Name}",
                    $"Description: {Services[i].Description}",
                    $"Duration: {Services[i].Duration}",
                    $"Price: {Services[i].Price}",
                };
                Window productWindow = new(Services[i].Name, nextX, nextY, showInfo);

                if (nextX + productWindow.WindowWidth > Width)
                {
                    nextX = 0;
                    productWindow.Left = nextX;
                    nextY += 5;
                    productWindow.Top = nextY;
                }

                productWindow.Draw();
                nextX += productWindow.WindowWidth + 2;
            }
        }

        public override void ManageInput()
        {
            var key = Console.ReadKey().KeyChar;

            if (int.TryParse(key.ToString(), out int input))
            {
                input -= 1;

                if (input <= Services.Count && input >= 0)
                {
                    ShouldChangePage = true;
                }
            }
            //else
            //{
            //    SelectedItem = Console.ReadKey(true).KeyChar;
            //    switch (SelectedItem.ToString())
            //    {
            //        case "A":
            //            SelectMode = true;
            //            break;
            //        case "B":
            //            SelectMode = true;
            //            break;
            //        case "C":
            //            SelectMode = true;
            //            break;
            //    }
            //}

        }
    }
}
