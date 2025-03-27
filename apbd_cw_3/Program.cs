namespace apbd_cw_3;

 class Program
    {
        static void Main(string[] args)
        {
            var kontenery = new List<Kontener>();
            var statki = new List<Kontenerowiec>();

            Console.WriteLine($"------Tworzymy kontenery różnych typów--------"); 
            
            var gaz1 = new KontenerNaGaz(250, 400, 100, 5000, 5);
            gaz1.Informacje();
            var plyn1 = new KontenerNaPłyn(200, 400, 100, 10000, true);
            plyn1.Informacje();
            var plyn2 = new KontenerNaPłyn(250, 370, 100, 10000, false);
            plyn2.Informacje();
            var chlod1 = new KontenerChłodniczy(200, 400, 100, 7000, "cheese", 8);
            chlod1.Informacje();
            var chlod2 = new KontenerChłodniczy(250, 370, 100, 7000, "meat", -10);
            chlod2.Informacje();

            kontenery.AddRange(new Kontener[] { gaz1, plyn1, plyn2, chlod1, chlod2 });

            Console.WriteLine($"--------Ładuje towary----------"); 
            gaz1.Zaladuj(4000);
            plyn1.Zaladuj(3000);
            plyn2.Zaladuj(2000);
            chlod1.Zaladuj(1000);
            chlod2.Zaladuj(500);

            Console.WriteLine($"--------Tworze statki---------"); 
            var statek1 = new Kontenerowiec("Prom", 20, 10, 100);
            var statek2 = new Kontenerowiec("Prom2", 25, 10, 100);

            statki.Add(statek1);
            statki.Add(statek2);

            Console.WriteLine($"--------Ładuje kontener pojedynczy na statek----------"); 
            statek1.ZaladujKontener(gaz1);
            statek1.ZaladujKontener(chlod1);

            Console.WriteLine($"--------Ładuje liste kontenerow na statek----------"); 
            var lista = new List<Kontener> { plyn1, plyn2 };
            statek1.ZaladujKontenery(lista);

            Console.WriteLine($"--------Usuwam kontener----------"); 
            statek1.UsunKontener(plyn1.numerSeryjny);

            Console.WriteLine($"--------Rozładowanie kontenera---------"); 
            statek1.RozladujKontener(chlod1.numerSeryjny);

            Console.WriteLine($"--------Wymiana kontenera----------"); 
            var nowyChlod = new KontenerChłodniczy(200, 400, 100, 7000, "fish", 2);
            statek1.ZastapKontener(chlod1.numerSeryjny, nowyChlod);

            Console.WriteLine($"-------Przenosze kontener miedzy statkami----------"); 
            statek1.PrzeniesKontenerDo(gaz1.numerSeryjny, statek2);

            Console.WriteLine($"--------Zastapiony kontener---------"); 
            nowyChlod.Informacje();

            Console.WriteLine($"--------Informacje o statkach----------"); 
            Console.WriteLine("\nInformacje o statku 1:");
            statek1.Informacje();

            Console.WriteLine("\nInformacje o statku 2:");
            statek2.Informacje();
            
            try
            {
                plyn2.Zaladuj(99999); // test przekroczenia limitu
            }
            catch (OverfillException e)
            {
                Console.WriteLine( e.Message);
            }
        }
    }
