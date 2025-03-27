namespace apbd_cw_3;

public class KontenerChłodniczy : Kontener
{
    public string typProduktu { get; set; }
    public double temperatura { get; set; }
    private string? przechowywanyProdukt;
    
    private static Dictionary<string, double> minimalneTemperatury = new Dictionary<string, double>
    {
        { "bananas", 13.3 },
        { "chocolate", 18 },
        { "fish", 2 },
        { "meat", -15 },
        { "ice cream", -18 },
        { "frozen pizza", -30 },
        { "cheese", 7.2 },
        { "sausages", 5 },
        { "butter", 20.5 },
        { "eggs", 19 }
    };
    
    public KontenerChłodniczy(double wysokosc, double glebokosc,double masaWlasna, double maxLadownosc, string typProduktu, double temperatura)
        : base("C", wysokosc, glebokosc, masaWlasna, maxLadownosc)
    {
        this.typProduktu = typProduktu;
        this.temperatura = temperatura;
        if (minimalneTemperatury.ContainsKey(this.typProduktu))
        {
            double minimalna = minimalneTemperatury[this.typProduktu];
            if (temperatura < minimalna)
            {
                throw new Exception($"Temperatura kontenera jest zbyt niska dla '{typProduktu}' (min: {minimalna}C).");
            }
        }
        else
        {
            throw new Exception($"Nieznany typ produktu: {typProduktu}.");
        }
    }

    public override void Zaladuj(double waga)
    {
        if (przechowywanyProdukt != null && przechowywanyProdukt != typProduktu)
        {
            throw new Exception($"Kontener już przechowuje inny typ produktu: {przechowywanyProdukt}.");
        }
        przechowywanyProdukt = typProduktu;
        base.Zaladuj(waga);
    }

    public override void Rozladuj()
    {
        base.Rozladuj();
        this.przechowywanyProdukt = null;
    }
    
    public override void Informacje()
    {
        base.Informacje();
        Console.WriteLine($"Produkt: {typProduktu}, Temperatura w kontenerze: {temperatura}C \n");
    }
}