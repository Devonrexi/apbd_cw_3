namespace apbd_cw_3;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    private const double ileZostawicLadunku = 0.05;
    public double cisnienie { get; set; }
    
    public KontenerNaGaz(double wysokosc, double glebokosc,double masaWlasna, double maxLadownosc, double cisnienie)
        : base("G", wysokosc, glebokosc, masaWlasna, maxLadownosc)
    {
        this.cisnienie = cisnienie;
    }

    public override void Zaladuj(double waga)
    {
        double ileMoznaZaladowac = maxLadownosc * 0.95;
        if (masaLadunku + waga > ileMoznaZaladowac)
        {
            Notify("Próba przeładowania kontenera!");
            throw new OverfillException($"Przekroczona dozwolona pojemność kontenera");
        }
        base.Zaladuj(waga);
    }

    public override void Rozladuj()
    {
        masaLadunku = masaLadunku * ileZostawicLadunku;
    }

    public void Notify(string wiadomosc)
    {
        Console.WriteLine($"{numerSeryjny} : {wiadomosc} \n");
    }
    
}