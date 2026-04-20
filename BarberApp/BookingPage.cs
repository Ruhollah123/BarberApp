namespace BarberApp
{
    internal class BookingPage : Page
    {
        private bool isBooking = false;
        public bool SelectMode { get; set; }
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

            scheduleInfo.Add("Time  |    Mon |    Tue   |     Wed    |    Thu   |     Fri ");
            scheduleInfo.Add("--------------------------------------------------------------");

            for (int hour = 9; hour <= 15; hour++)
            {
                string hourString = hour.ToString().PadLeft(2);

                string row = $"{hourString}:00 |";
                row += " [FREE] |   [FREE] |   [BOOKED] |   [FREE] |   [BOOKED]";
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
                Console.WriteLine("Enter B to book an apointment");
                Console.WriteLine("Enter C to go back to menu");
            }
            else
            {
                Console.WriteLine("--- BOOKING-MODE ---");
                Console.Write("Enter day: ");
                var dayEntered = Console.ReadLine();

                Console.Write("Enter Time: ");
                var timeEntered = Console.ReadLine();

                Console.WriteLine("Time Booked!");
                Console.WriteLine("\nEnter B to book another appointment");
                Console.WriteLine("Enter C to go back to menu");

            }
        }
        public override void ManageInput()
        {
            var key = Console.ReadKey(true);
            if (!isBooking)
            {
                if (key.Key == ConsoleKey.B)
                {
                    isBooking = true;
                    ShouldChangePage = false;
                }
                else if (key.Key == ConsoleKey.C)
                {
                    SelectMode = true;
                    ShouldChangePage = true;
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
    }
}
