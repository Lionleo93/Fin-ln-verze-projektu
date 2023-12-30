namespace Finální_verze_projektu
{
    using System;

    class Program
    {
        static void Main()
        {
            PojistovaciManager pojistovaciManager = new PojistovaciManager();
            UzivatelskeRozhrani uzivatelskeRozhrani = new UzivatelskeRozhrani(pojistovaciManager);
            uzivatelskeRozhrani.Spustit();
        }
    }
}
