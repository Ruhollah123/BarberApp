namespace BarberApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            app.Run();

        }
    }
}


//// Hämtar från databasen
//List<string> categoriesText = new List<string> { "Byxor", "Tröjor", "Skor", "Skjortor", "xxxxxxxxxxxxxxxxxxxxxxx" };
////foreach(var text in categoriesText)
////{
////    Console.WriteLine(text);
////}

//// Detta hämtas från databas
//List<string> cartText = new List<string> { "1 st Blå byxor", "1 st Grön tröja", "1 st Röd skjorta" };
//var windowCart = new Window("Din varukorg", 30, 6, cartText);
//windowCart.Draw();

//var windowCategories = new Window("Kategorier", 2, 6, categoriesText);
//windowCategories.Draw();

//List<string> topText = new List<string> { "# The Cut-Algorithm #", "Allt inom kläder" };
//var windowTop = new Window("", 2, 1, topText);
//windowTop.Draw();

//windowTop.Left = 45;
//windowTop.Draw();

//Console.WriteLine("Nån annan text");