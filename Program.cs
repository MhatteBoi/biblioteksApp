namespace bibliotekApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool tool = true;
            Bibliotek bibliotek = new Bibliotek();
            Lånetagare lånetagare = new Lånetagare(123,"test");
            bokClass bok = new bokClass("test", "tester");


            //lägg till böcker i lager så 
            bibliotek.läggTillBok("harry potter","jk rowling");
            bibliotek.läggTillBok("sagan om ringen","tolkien");
            bibliotek.läggTillBok("the martian","andy weir");
            bibliotek.läggTillLåneTagare("Mhattias", 1234567);






            Console.WriteLine("Hej välkommen till biblioteket! ");
            Console.WriteLine("är du en anställd eller är du bara här för att lämna tillbaka eller låna en bok?\n");
            Console.WriteLine("ange admin eller medlem");
            string inputUser = Console.ReadLine();
            Console.WriteLine("================================================================================================\n");
            //Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("");


            if (inputUser == "admin") 
            { 

                do
                {
                    
                    Console.WriteLine("välj vad du vill göra genom att trycka på respektive nr! 0 för att avsluta");
                    Console.WriteLine("======================================\n");
                    Console.WriteLine("1: lägg till bok.\n");
                    Console.WriteLine("2: lägg till lånetagare.\n");
                    Console.WriteLine("3: visa böcker i lager.\n");
                    Console.WriteLine("4: visa lånetagare och böcker de lånar.\n");
                    Console.WriteLine("5: Låna ut bok.\n");
                    Console.WriteLine("0 Avsluta");
                    Console.WriteLine("======================================\n");
                    int input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("vilken bok vill du lägga in? ange titel och författare.");
                            Console.WriteLine("Titel:");
                            string titel = Console.ReadLine(); 
                            Console.WriteLine("Författare:");
                            string författare = Console.ReadLine();
                            bibliotek.läggTillBok(titel, författare);
                            Thread.Sleep(1000);
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Ange namn och personnummer.\n ");
                            Console.WriteLine("Namn:");
                            string namn = Console.ReadLine();
                            Console.WriteLine();
                            Console.WriteLine("Personnummer");
                            int personNum = int.Parse(Console.ReadLine());

                            bibliotek.läggTillLåneTagare(namn, personNum);

                            break;

                        case 3:
                            Console.Clear();

                            bibliotek.CountBöcker();
                            Thread.Sleep(2000);

                            break;

                        case 4:
                            bibliotek.SeLånetgare();
                            Thread.Sleep(2000);

                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine("För att kunna låna ut måste man va medlemm i biblioteket!");
                            Console.WriteLine("Ange personnummer sedan titeln på boken du vill låna!\n");
                            Console.WriteLine("Personnummer:");
                            if (int.TryParse(Console.ReadLine(), out int perNum))
                            {
                                // Valid input, you can proceed with perNum
                                Console.WriteLine("Bok titel:");
                                string bokTitel = Console.ReadLine();
                                bibliotek.LånaUtBok(perNum, bokTitel);
                                Thread.Sleep(2000);
                            }
                            else
                            {
                                Console.WriteLine("Invalid personnummer. Please enter a valid integer.");
                                // You might want to handle this case appropriately, e.g., ask the user to enter the information again.
                            }

                            break;

                        case 0:
                            Console.Clear();
                            tool = false;
                            break;
                    }

                }
                while (tool);
            }
            else if (inputUser == "medlem")
            {
                do 
                {
                    Console.WriteLine("Välj vad du vill göra genom att trycka på respektive nr! 0 för att avsluta.");
                    Console.WriteLine("======================================\n");
                    Console.WriteLine("1: Lämna tillbaka bok.\n");
                    Console.WriteLine("2: Kolla vilka böcker du har lånat.\n");
                    Console.WriteLine("3: visa böcker i lager.\n");
                    Console.WriteLine("0 Avsluta");
                    int input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("för att lämna tillbaka din lånade bok ange ditt personnummer och bok titel!\n");
                            Console.WriteLine("personnummer:");
                            int personNum = int.Parse(Console.ReadLine());
                            Console.WriteLine("\n");
                            Console.WriteLine("Bok titel: ");
                            string bokTitel = Console.ReadLine();

                            bibliotek.LämnaTillbakaBok(personNum, bokTitel);

                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("ange ditt namn för att se vilka böcker du lånar.");
                            string namn = Console.ReadLine();
                            bibliotek.LånetagaresBöcker(namn);

                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("böcker i lager är:");
                            bibliotek.CountBöcker();
                            break;

                        case 0:
                            Console.Clear();
                            tool = false;
                            break;
                    }
                }
                while(tool);
            }
            else { Console.WriteLine("fel ange om du är admin eller medlem!"); }
        }
    }
}
