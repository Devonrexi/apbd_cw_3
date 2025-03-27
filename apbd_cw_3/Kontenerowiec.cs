namespace apbd_cw_3;

public class Kontenerowiec
{
    public string nazwa { get; set; }
    public double maxPredkosc { get; set; }
    public int maxIloscKontenerow { get; }
    public double maxWaga { get; set; } 
    private List<Kontener> kontenery { get; set; }

    public Kontenerowiec(string nazwa, double maxPredkosc, int maxIloscKontenerow, double maxWaga)
    {
        this.nazwa = nazwa;
        this.maxPredkosc = maxPredkosc;
        this.maxIloscKontenerow = maxIloscKontenerow;
        this.maxWaga = maxWaga * 1000; 
        this.kontenery = new List<Kontener>();
    }

    public void ZaladujKontener(Kontener k)
    {
        if (kontenery.Count >= maxIloscKontenerow)
        { throw new Exception("Przekroczono maksymalną ilość kontenerów na statku.");}

        double aktualnaWaga = 0;
        foreach (var kont in kontenery)
            aktualnaWaga += kont.masaLadunku + kont.masaWlasna;

        if (aktualnaWaga + k.masaLadunku + k.masaWlasna > maxWaga)
            throw new Exception("Przekroczono maksymalną wagę ładunku na statku.");

        kontenery.Add(k);
    }

    public void ZaladujKontenery(List<Kontener> lista)
    {
        foreach (var k in lista)
        {
            ZaladujKontener(k);
        }
    }
    
    public void UsunKontener(string numerSeryjny)
    {
        kontenery.RemoveAll(k => k.numerSeryjny == numerSeryjny);
    }
    
    public void RozladujKontener(string numerSeryjny)
    {
        var kont = kontenery.FirstOrDefault(k => k.numerSeryjny == numerSeryjny);
        if (kont != null) {kont.Rozladuj();}
    }

    public void ZastapKontener(string numerSeryjny, Kontener nowy)
    {
        UsunKontener(numerSeryjny);
        ZaladujKontener(nowy);
    }
    
    public void PrzeniesKontenerDo(string numerSeryjny, Kontenerowiec docelowy)
    {
        var kont = kontenery.FirstOrDefault(k => k.numerSeryjny == numerSeryjny);
        if (kont != null)
        {
            kontenery.Remove(kont);
            docelowy.ZaladujKontener(kont);
        }
    }
    
    public void Informacje()
    {
        Console.WriteLine($"Kontenerowiec: {nazwa}, Prędkość: {maxPredkosc} węzłów, Maks kontenery: {maxIloscKontenerow}, Maks waga: {maxWaga / 1000} ton");
        Console.WriteLine("Lista kontenerów:");
        foreach (var kont in kontenery)
        {
            kont.Informacje();
            Console.WriteLine("----------------------------");
        }
    }
    
}