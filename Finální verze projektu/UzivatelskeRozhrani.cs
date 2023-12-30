using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finální_verze_projektu
{
    public class UzivatelskeRozhrani
    {
        private readonly PojistovaciManager pojistovaciManager;

        public UzivatelskeRozhrani(PojistovaciManager manager)
        {
            pojistovaciManager = manager;
        }
        // Spustí hlavní smyčku programu
        public void Spustit()
                {
                Console.WriteLine(" --------------------");
                Console.WriteLine("|Evidence pojistenych|");
                Console.WriteLine(" --------------------");

                while (true)
                {
                    Console.WriteLine("\nVyberte si akci:");
                    Console.WriteLine("1. Přidat nového pojištěného");
                    Console.WriteLine("2. Vypsat všechny pojištěné");
                    Console.WriteLine("3. Vyhledat pojištěného");
                    Console.WriteLine("4. Konec");


                    if (int.TryParse(Console.ReadLine(), out int volba))
                    {
                        switch (volba)
                        {
                            case 1:
                                PridatNovehoPojistence();
                                break;
                            case 2:
                                UkazVsechnyPojistence();
                                break;
                            case 3:
                                VyhledejPojistence();
                                break;
                            case 4:
                                Console.WriteLine("Konec...");
                                return;
                            default:
                                Console.WriteLine("Neplatná volba, vyberte z možností 1 až 4.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Neplatný vstupní kód.");
                    }
                }
            }
        // Vyhledá pojištěnce dle jména a příjmení
            private void VyhledejPojistence()
            {
                Console.Write("\nZadejte jméno pro vyhledávání:");
                string najdiJmeno = Console.ReadLine().Trim().ToLower();
                Console.Write("\nZadejte příjmení pro vyhledávání:");
                string najdiPrijmeni = Console.ReadLine().Trim().ToLower();
                var shoda = pojistovaciManager.VyhledejPojistence(najdiJmeno, najdiPrijmeni);

                if (shoda != null)
                {
                    Console.WriteLine($"{shoda.Jmeno}    {shoda.Prijmeni}   {shoda.Telefon}    {shoda.Vek}");
                }
                else
                {
                    Console.WriteLine($"Nikdo s těmito údaji nebyl nalezen!");
                }
            }
        
        // Metoda pro zobrazení všech pojištěnců
        private void UkazVsechnyPojistence()
            {
                Console.WriteLine("\nVýpis všech pojištění:");

                var pojisteni = pojistovaciManager.DostatVsechnyPojisteni();

                foreach (var pojisteny in pojisteni)
                {
                    Console.WriteLine($" {pojisteny.Jmeno} {pojisteny.Prijmeni} {pojisteny.Telefon} {pojisteny.Vek}");
                }

            }
        // Metoda pro přidání nového pojištěnce
        private void PridatNovehoPojistence()
            {
                Console.WriteLine("\nPřidat nového pojištěného:");

                Console.WriteLine("Zadejte křestní jméno:");
                string jmeno = Console.ReadLine().Trim().ToLower();
                if (!string.IsNullOrEmpty(jmeno))
                {
                   jmeno = char.ToUpper(jmeno[0]) + jmeno.Substring(1);
                }
            Console.WriteLine("Zadejte příjmení:");
                string prijmeni = Console.ReadLine().Trim().ToLower();
                if (!string.IsNullOrEmpty(prijmeni))
                    {
                     prijmeni = char.ToUpper(prijmeni[0]) + prijmeni.Substring(1);
                    }

            Console.WriteLine("Zadejte telefonní číslo:");
                string telefon = Console.ReadLine().Trim();

                Console.WriteLine("Zadejte věk:");
                if (!int.TryParse(Console.ReadLine(), out int vek))
                {
                    Console.WriteLine("Neplatná hodnota pro věk, zadejte znovu");
                    return;
                }

                pojistovaciManager.PridatPojistence(new Pojisteny
                {
                    Jmeno = jmeno,
                    Prijmeni = prijmeni,
                    Telefon = telefon,
                    Vek = vek
                });

                Console.WriteLine("Data úspěšně uložena!");
        }
    }
}
