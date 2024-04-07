using WebApplication1.Models;

namespace WebApplication1.DB;

public class DB
{
    public static List<Zwierz> Zwierze = new List<Zwierz>()
    {
        new Zwierz{id = 0, imie = "fafik",kategoria = "pies",kolorsiersci = "bialy", masa = 15},
        new Zwierz{id = 1,imie = "rudy",kategoria = "kot",masa = 2,kolorsiersci = "rudy"}
    };

    public static List<Wizyta> Wizyty = new()
    {
        new Wizyta
        {
            dataWizyty = new DateTime(2023, 3, 11, 10, 30, 0), cenaWizyty = 12, opisWizyty = "kontrola",
            zwierze = Zwierze[0]
        },
        new Wizyta
        {
            dataWizyty = new DateTime(2024, 3, 11, 10, 30, 0), cenaWizyty = 123, opisWizyty = "kontrola",
            zwierze = Zwierze[0]
        }
    };
}