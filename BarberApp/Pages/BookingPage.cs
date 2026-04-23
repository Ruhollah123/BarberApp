using Entities.Models;
using Services.Interfaces;

namespace BarberApp.Pages
{
    internal class BookingPage : Page
    {
        private bool isBooking = false;
        public bool SelectMode { get; set; }
        private readonly IAppointmentService _service;
        private List<Appointment> _appointments;
        private Service? _selectedServiceId;
        public int weekOffset = 0;
        public BookingPage(IAppointmentService appointmentService, List<Appointment> appointments, Service selectedServiceId)
        {
            _service = appointmentService;
            _appointments = appointments;
            _selectedServiceId = selectedServiceId;
        }

        public override ChangePageRequest ChangePage()
        {
            if (SelectMode)
            {
                return new ChangePageRequest() { Page = "Home" };
            }

            return new ChangePageRequest() { Page = "Booking-appointment" };
        }

        public override void Draw()
        {
            Console.Clear();

            int nextX = 6;
            int nextY = 0;
            int paddingX = 0;
            int paddingY = 7;

            List<string> scheduleInfo = new List<string>();
            DateTime baseMonday = new DateTime(2026, 4, 27);
            DateTime currentMonday = baseMonday.AddDays(weekOffset * 7);
            string header = "Time       ";

            for (int i = 0; i < 5; i++)
            {
                DateTime day = currentMonday.AddDays(i);
                header += $" {day.ToString("ddd (d MM)      ", System.Globalization.CultureInfo.InvariantCulture)}";
            }
            scheduleInfo.Add(header);
            scheduleInfo.Add(new string('-', 95));


            for (int hour = 9; hour <= 15; hour++)
            {
                string hourString = hour.ToString().PadLeft(2);
                string row = $"{hourString}:00 |";

                for (int dayOffset = 0; dayOffset < 5; dayOffset++)
                {
                    DateTime checkDate = currentMonday.AddDays(dayOffset);
                    bool isBooked = _appointments.Any(a => a.DateTime.Date == checkDate.Date && a.DateTime.Hour == hour);

                    string status = isBooked ? "       [BOOKED]" : "       [FREE]";
                    row += $"{status}    |";
                }

                scheduleInfo.Add(row);
            }

            Window scheduleWindow = new Window("Schedule", X, Y, scheduleInfo);
            scheduleWindow.Draw();
            
            nextX += scheduleWindow.WindowWidth + 2;

            if (nextX + scheduleWindow.WindowWidth > Width)
            {
                nextX = 0;
                nextY += paddingY;
            }
            if (!isBooking)
            {
                Console.WriteLine("[F] Next Week | [K] Last Week");
                Console.WriteLine("Enter [B] To Book An Appoinntment | Enter C to go back to menu");
            }
        }
        public override void ManageInput()
        {
            var key = Console.ReadKey(true);
            if (!isBooking)
            {
                if (key.Key == ConsoleKey.B)
                {
                    SelectedAppointment();
                }
                else if (key.Key == ConsoleKey.C)
                {
                    SelectMode = true;
                    ShouldChangePage = true;
                }
                else if (key.Key == ConsoleKey.F)
                {
                    weekOffset++;
                    Draw();
                }
                else if (key.Key == ConsoleKey.K)
                {
                    weekOffset--;
                    Draw();
                }
            }
            else
            {
                if (key.Key == ConsoleKey.C)
                {
                    isBooking = false;
                    ShouldChangePage = true;
                    SelectMode = true;
                }
            }
        }

        private void SelectedAppointment()
        {
            Console.WriteLine("\n--- BOOKING-MODE ---");
            Console.Write("Enter day: ");
            var dayEntered = Console.ReadLine();

            Console.Write("Enter Time: ");
            var timeEntered = Console.ReadLine();

            if (DateTime.TryParse($"{dayEntered} {timeEntered}", out DateTime bookedDate))
            {
                var newAppointment = _service.AddAppointmentsAsync(1, bookedDate).Result;

                if (newAppointment != null)
                {
                    _appointments.Add(newAppointment);
                    Console.WriteLine($"Service: {_selectedServiceId} Added To Cart");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid date format");
                Console.WriteLine("Enter any key to continue");
                Console.ReadKey();
            }
        }

    }
}