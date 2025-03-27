namespace apbd_cw_3;

public class KontenerNaPłyn : Kontener, IHazardNotifier
{
    private const double  niebezpŁadunekPojemnosc= 0.5;
    private const double bezpŁadunekPojemnosc = 0.9;
    public bool czyBezpieczny { get; set;}

    public KontenerNaPłyn(double wysokosc, double glebokosc,double masaWlasna, double maxLadownosc, bool czyBezpieczny)
        : base("L", wysokosc, glebokosc, masaWlasna, maxLadownosc )
    {
        this.czyBezpieczny = czyBezpieczny;
    }

    public override void Zaladuj(double waga)
    {
        double ileMoznaZaladowac = czyBezpieczny ? maxLadownosc * bezpŁadunekPojemnosc : maxLadownosc * niebezpŁadunekPojemnosc;
        if (masaLadunku + waga > ileMoznaZaladowac)
        {
            Notify("Próba przeładowania kontenera! Uwaga!");
            throw new OverfillException($"Przekroczona maksymalna ładowność kontenera.");
        }
        base.Zaladuj(waga);
    }

    public override void Informacje()
    {
        base.Informacje();
        Console.WriteLine(czyBezpieczny ? "Ładunek bezpieczny" : "Ładunek niebezpieczny \n");
    }
    
    public void Notify(string wiadomosc)
    {
        Console.WriteLine($"{numerSeryjny} : {wiadomosc}");
    }

}