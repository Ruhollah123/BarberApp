using Entities.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace BarberApp.Pages
{
    internal class ServicePage : Page
    {
        public bool AddMode { get; set; }
        public bool SelectMode { get; set; }
        public char SelectedItem { get; set; }
        private Service? _selectedServiceId;
        public List<Appointment> SelectedAppointments { get; set; } = new List<Appointment>();

        private readonly IServicesService _serviceService;
        public List<Service> Services { get; set; } = new List<Service>();

        public ServicePage(IServicesService service, List<Appointment> appointments)
        {
            _serviceService = service;
            SelectedAppointments = appointments;

            Services = _serviceService.GetAllServicesAsync().Result;
        }
        public override ChangePageRequest ChangePage()
        {

            if (AddMode)
            {
                ShouldChangePage = true;
                AddMode = false;
                SelectMode = true;
                return new ChangePageRequest() { Page = "Booking-appointment" };

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
                    nextX = 0;
                    nextY += 7;
                }
            }

            Console.WriteLine("Enter A to book an appointment");
            Console.WriteLine("B to view appointments");
            Console.WriteLine("C to go back to menu");
        }

        public override void ManageInput()
        {
            var key = Console.ReadKey(true).KeyChar;

            if (SelectMode && int.TryParse(key.ToString(), out int input))
            {
                input -= 1;

                if (input <= Services.Count && input > 0)
                {
                    SelectMode = true;
                    ShouldChangePage = true;
                }
            }
            else
            {
                char choice = char.ToUpper(key);
                switch (choice)
                {
                    case 'A':
                        HandleServiceSelection();
                        ShouldChangePage = true;
                        SelectMode = true;
                        AddMode = true;
                        break;
                    case 'B':
                        MyBookedAppointments();
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

        private void HandleServiceSelection()
        {
            Console.Write("\nEnter a number between (1-4) to choose service: ");
            if (int.TryParse(Console.ReadLine(), out int selectedService))
            {
                _selectedServiceId = Services.FirstOrDefault(s => s.Id == selectedService);
                Console.WriteLine($"Appointment Added! Enter any key to continue.");
            }
        }

        private void MyBookedAppointments()
        {
            Console.Clear();
            Console.WriteLine("--- MY APPOINTMENTS ---");

            if (SelectedAppointments.Count == 0)
            {
                Console.WriteLine("No Appointments Available");
            }
            else
            {
                foreach (var item in SelectedAppointments)
                {
                    Console.WriteLine($"\n#{item.CustomerId} Date: {item.DateTime.ToString("g")} Address: Storgatan 1, Uddevalla 451 40");
                    Console.WriteLine("------------------------------------");
                }

                Console.Write("\nEnter a number to cancel appointment | Enter C to go back: ");
                if (int.TryParse(Console.ReadLine(), out int cancelAppoint))
                {
                    if (cancelAppoint > 0 && cancelAppoint == SelectedAppointments.Count)
                    {
                        var removed = SelectedAppointments[cancelAppoint - 1];
                        SelectedAppointments.RemoveAt(cancelAppoint - 1);
                        Console.WriteLine($"\nAppointment At {removed.DateTime:g} was removed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. No Appointment removed");
                    }
                }
                else
                {
                    ShouldChangePage = true;
                }
            }

            Console.ReadKey();
        }
    }
}
