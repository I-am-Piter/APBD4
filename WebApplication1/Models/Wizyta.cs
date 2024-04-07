namespace WebApplication1.Models;

public class Wizyta
{
    public DateTime dataWizyty { get; set; }
    public Zwierz zwierze { get; set; }
    public string opisWizyty { get; set; }
    public double cenaWizyty { get; set; }
}