namespace WebApplication1.Models;

public class Zwierz
{
    int id;
    string imie;
    string kategoria;
    double masa;
    string kolorsiersci;

    public Zwierz(int id, string imie, string kategoria, double masa, string kolorsiersci)
    {
        this.id = id;
        this.imie = imie;
        this.kategoria = kategoria;
        this.masa = masa;
        this.kolorsiersci = kolorsiersci;
    }

    public int getId()
    {
        return id;
    }

    public string getImie()
    {
        return imie;
    }
    
    public string getKategoria()
    {
        return kategoria;
    }

    public double getMass()
    {
        return masa;
    }

    public string getKolorSiersci()
    {
        return kolorsiersci;
    }
}