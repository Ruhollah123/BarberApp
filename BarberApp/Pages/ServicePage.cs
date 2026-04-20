using Entities.Models;

namespace BarberApp.Pages
{
    internal class ServicePage : Page
    {
        public List<Service> Services { get; set; } = new List<Service>
        {
            new Service { Id = 1, Name = "Hårklippning Standard", Description = "Klassisk klippning inklusive tvätt och styling.", Duration = "45 min", Price = 550m },
            new Service {Id = 2, Name = "Skäggtrimning", Description = "Trimning och formning av skägg med maskin och kniv.", Duration = "30 min", Price = 350m },
            new Service {Id = 3, Name = "Lyxpaket", Description = "Hårklippning och skäggtrimning samt varm handduk.", Duration = "75 min", Price = 850m },
        };

        public bool AddMode { get; set; }
        public bool SelectMode { get; set; }
        public char SelectedItem { get; set; }
        public override ChangePageRequest ChangePage()
        {

            if (AddMode)
            {
                ShouldChangePage = true;
                AddMode = false;
                SelectMode = true;
                return new ChangePageRequest() { Page = "Book-an-Appointment" };

            }
            else if (AddMode)
            {
                return new ChangePageRequest() { Page = "View-appointments" };
            }
            else
            {
                return new ChangePageRequest() { Page = "Home" };
            }
        }

        public override void Draw()
        {
            Console.Clear();
            int nextX = 0;
            int nextY = 0;


            for (int i = 0; i < Services.Count; i++)
            {

                List<string> showInfo = new List<string>()
                {
                    $"{Services[i].Id}",
                    $"Name: {Services[i].Name}",
                    $"Desc: {Services[i].Description}",
                    $"Duration: {Services[i].Duration}",
                    $"Price: {Services[i].Price} kr",
                };
                Window serviceWindow = new(Services[i].Name, nextX, nextY, showInfo);

                serviceWindow.Draw();
                nextX += serviceWindow.WindowWidth + 2;

                if (nextX + serviceWindow.WindowWidth > Width)
                {
                    nextX = 58;
                    nextY += 0;
                }
            }

            Console.WriteLine("Enter A to book an appointment");
            Console.WriteLine("B to view appointments");
            Console.WriteLine("C to go back to menu");
        }

        public override void ManageInput()
        {
            var key = Console.ReadKey(true).KeyChar;

            if (int.TryParse(key.ToString(), out int input))
            {
                input -= 1;

                if (input <= Services.Count && input >= 0)
                {
                    ShouldChangePage = true;
                }
            }
            else
            {
                char choice = char.ToUpper(key);
                switch (choice)
                {
                    case 'A':
                        AddMode = true;
                        ShouldChangePage = true;
                        break;
                    case 'B':
                        SelectMode = true;
                        ShouldChangePage = true;
                        break;
                    case 'C':
                        AddMode = false;
                        SelectMode = false;
                        ShouldChangePage = true;
                        break;
                }
            }

        }
    }
}
