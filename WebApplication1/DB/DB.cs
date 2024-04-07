using WebApplication1.Models;

namespace WebApplication1.DB;

public class DB
{
    public static List<Zwierz> Zwierze= new List<Zwierz>();


    public DB()
    {
        Zwierze.Add(new Zwierz(0,"fafik","pies",15,"bialy"));
        Zwierze.Add(new Zwierz(1,"rudy","kot", 2,"rudy"));
    }
}