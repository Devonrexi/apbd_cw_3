namespace apbd_cw_3;

public abstract class Kontener
{
    private static int licznik = 0;
    public double masaLadunku {get;set;}
    public double wysokosc { get; set; }
    public double masaWlasna { get; set; }
    public double glebokosc { get; set; }
    public string numerSeryjny { get; set; }
    public double maxLadownosc { get; set; }

    public Kontener(string kodRodzajuKontenera, double wysokosc, double glebokosc,double masaWlasna, double maxLadownosc)
    {
        licznik++;
        this.numerSeryjny = $"KON-{kodRodzajuKontenera}-{licznik}";
        this.wysokosc = wysokosc;
        this.glebokosc = glebokosc;
        this.masaWlasna = masaWlasna;
        this.maxLadownosc = maxLadownosc;
        this.masaLadunku = 0;
    }

    public virtual void Zaladuj(double waga)
    {
        var test = masaLadunku + waga;
        if (test > maxLadownosc)
        {
            throw new OverfillException($"Przekroczona maksymalną pojemność kontenera.");
        }

        masaLadunku = test;
    }

    public virtual void Rozladuj()
    {
        masaLadunku = 0;
    }

    public virtual void Informacje()
    {
        Console.WriteLine($"Numer seryjny: {numerSeryjny},");
        Console.WriteLine($"Maksymalna ładowność: {maxLadownosc} kg,");
        Console.WriteLine($"Waga kontenera: {masaWlasna} kg,");
        Console.WriteLine($"Wysokość kontenera: {wysokosc} cm,");
        Console.WriteLine($"Głębokość kontenera: {glebokosc} cm,");
        Console.WriteLine($"Obecna waga ładunku: {masaLadunku} kg,\n");
    }

}