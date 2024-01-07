using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotekApp
{
    public class bokClass
    {
        private string titel;
        public string Titel
        {
            get
            {
                if (Status)
                {
                    return "LÅNAD\n";
                }
                return titel;
            }
            set
            {
                titel = value;
            }
        }

        private string författare;
        public string Författare
        {
            get
            {
                if (Status)
                {
                    return $"{titel} {författare}\n";
                }
                return författare;
            }
            set
            {
                författare = value;
            }
        }


        public bool Status { get; set; }
        

        public bokClass(string titel, string författare) 
        {
            this.Titel = titel;
            this.Status = false;
            this.Författare = författare;
        }

        
    }

    public class Bibliotek
    {
        private List<bokClass> böckerLager;             // 2 privata listor för biblioteket att kunna hantera
        private List<Lånetagare> låneTagarLista;
        Lånetagare Lånetagare { get; set; }

        public Bibliotek()
        {
            böckerLager = new List<bokClass>();
            låneTagarLista = new List<Lånetagare>();


        }

        //metoder


        //lägga till medlemmar i biblioteket
        public void läggTillLåneTagare(string namn, int personNR)
        {

            Lånetagare nyLånetagare = new Lånetagare(personNR, namn);
            låneTagarLista.Add(nyLånetagare);
        }


        // lägg till böcker i lager på biblioteket
        public void läggTillBok(string titel, string författare) // metod för att lägga till böcker
        {
            bokClass nyBok = new bokClass(titel, författare);
            böckerLager.Add(nyBok);

        }


        //se vilka böcker som finns i lager
        public void CountBöcker()
        {
            Console.WriteLine("böcker i lager: \n");

            foreach (var bok in böckerLager)    // foreach-loop som itererar över varje bok i listan och skriver ut dess egenskaper (titel och författare)
            {
                Console.WriteLine($"titel: {bok.Titel}, författare: {bok.Författare}. \n");
            }
        }


        // se vilka medlemmar som är med i biblioteket
        public void SeLånetgare()
        {

            Console.WriteLine("Biblioteks medlemmar");
            foreach (var lt in låneTagarLista)
            {
                Console.Write("Namn: " + lt.namn + ", Lånade böcker: ");

                if (lt.lånadeBöcker.Count == 0)
                {
                    Console.WriteLine("Inga lånade böcker.");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", lt.lånadeBöcker));
                }
            }

        }


        public void LånaUtBok(int personNrCheck, string titelCheck)
        {
            Lånetagare lånetagare = låneTagarLista?.Find(x => x.personNr == personNrCheck);
            bokClass bokAttLåna = böckerLager?.Find(x => x.Titel == titelCheck && !x.Status);

            if (lånetagare != null && bokAttLåna != null)
            {
                lånetagare.lånadeBöcker.Add(titelCheck);
                bokAttLåna.Status = true;
                Console.WriteLine($"{lånetagare.namn} har lånat boken {titelCheck}.");
            }
            else
            {
                Console.WriteLine("Lånetagaren eller boken kunde inte hittas eller är redan utlånad.");
            }

        }

        public void LämnaTillbakaBok(int personNrCheck, string titelCheck)
        {

            // Hitta lånetagaren med det angivna personnumret
            Lånetagare lånetagare = låneTagarLista.Find(x => x.personNr == personNrCheck);

            // Kontrollera om lånetagaren hittades
            if (lånetagare != null)
            {
                // Hitta den lånade boken i lånetagarens lista
                string bokAttLämna = lånetagare.lånadeBöcker.Find(x => x == titelCheck);

                // Kontrollera om den lånade boken hittades och inte är redan lämnad tillbaka
                if (bokAttLämna != null)
                {
                    // Markera boken som tillgänglig
                    bokClass bok = böckerLager.Find(x => x.Titel == titelCheck);
                    if (bok != null)
                    {
                        bok.Status = false;
                    }

                    lånetagare.lånadeBöcker.Remove(bokAttLämna); // Ta bort boken från lånetagarens lista
                    Console.WriteLine($"{lånetagare.namn} har lämnat tillbaka boken {titelCheck}.");
                }
                else
                {
                    Console.WriteLine($"{lånetagare.namn} har inte lånat boken {titelCheck} eller boken är redan lämnad tillbaka.");
                }
            }
            else
            {
                Console.WriteLine($"Lånetagaren med personnummer {personNrCheck} kunde inte hittas.");
            }

        }


        public void LånetagaresBöcker(string namnCheck)
        {
            //välj lånetagare och visa hens böcker

            //hitta lånetagare
            Lånetagare Lånetagare = låneTagarLista.Find(x => x.namn == namnCheck);
            if (Lånetagare != null) 
            {
                Console.WriteLine($"böcker som {Lånetagare.namn} har lånat");
                //loopa igenom lånetagarens lånade böcker
                foreach (var bokTitel in Lånetagare.lånadeBöcker) 
                {
                    Console.WriteLine(bokTitel);

                }
            
            }
            else if (Lånetagare.lånadeBöcker.Count == 0)  // har lånetagare inga böcker så skriv ut det som meddelande

            {
                Console.WriteLine("lånetagare {namnCheck} har inga lånade böcker!");
            }
            else { Console.WriteLine($"lånetagare med {namnCheck} kunde icke sa nicke hittas!"); }
        }
    }
}
