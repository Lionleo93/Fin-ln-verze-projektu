using Finální_verze_projektu;
using System;
using System.Collections.Generic;
using System.Linq;

// Třída pro správu pojištěnců
public class PojistovaciManager
{
    private readonly List<Pojisteny> pojisteni;

    public PojistovaciManager()
    {
        pojisteni = new List<Pojisteny>();
    }
    // Přidá nového pojištěnce
    public void PridatPojistence(Pojisteny pojisteny)
    {
        pojisteni.Add(pojisteny);
    }

    // Získá všechny pojištěnce
    public List<Pojisteny> DostatVsechnyPojisteni()
    {
        return pojisteni.ToList();
    }
    // Hledá pojištěnce podle jména
    public Pojisteny VyhledejPojistence(string najdiJmeno, string najdiPrijmeni)
    {
        return pojisteni.FirstOrDefault(p => p.Jmeno.Equals(najdiJmeno, StringComparison.OrdinalIgnoreCase) && p.Prijmeni.Equals(najdiPrijmeni, StringComparison.OrdinalIgnoreCase));
    }


}   

