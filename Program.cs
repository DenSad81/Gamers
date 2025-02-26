using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        List<Gamer> gamers = new List<Gamer>();
        CreaterOfGamers createrOfGamers = new CreaterOfGamers();
        Filter filter = new Filter();

        gamers = createrOfGamers.CreateGamers(random);

        ShowData(gamers);
        Console.WriteLine();

        ShowData(filter.GetTopByLevel(gamers));
        Console.WriteLine();

        ShowData(filter.GetTopByForse(gamers));
        Console.WriteLine();
    }

    public static void ShowData(List<Gamer> gamers)
    {
        foreach (var gamer in gamers)
            gamer.ShowData();
    }
}

public class Gamer
{
    private static int s_ids = 0;

    public Gamer(Names name, int growth, int weigfh)
    {
        Name = name;
        Level = growth;
        Forse = weigfh;
        Id = s_ids++;
    }

    public int Id { get; private set; }
    public Names Name { get; private set; }
    public int Level { get; private set; }
    public int Forse { get; private set; }

    public void ShowData() =>
        Console.WriteLine($"ID: {Id} Name: {Name} Level: {Level} Forse: {Forse}");
}

public class CreaterOfGamers
{
    public List<Gamer> CreateGamers(Random random)
    {
        int minLevel = 0;
        int maxLevel = 10;
        int minForse = 10;
        int maxForse = 120;
        int quantityOfGamers = 50;
        List<Gamer> gamers = new List<Gamer>();

        for (int i = 0; i < quantityOfGamers; i++)
        {
            Names tempName = (Names)random.Next(0, (int)Names.MaxValue);
            int tempLevel = random.Next(minLevel, maxLevel);
            int tempForse = random.Next(minForse, maxForse);

            gamers.Add(new Gamer(tempName, tempLevel, tempForse));
        }

        return gamers;
    }
}

public enum Names
{
    Pavel,
    Boris,
    Klaiv,
    ken,
    Pol,
    Chak,
    Ben,
    Den,
    Alex,
    Petr,
    Ger,
    Andre,
    Iosif,
    Donald,
    Mark,
    Abby,
    MaxValue
}

public class Filter
{
    public List<Gamer> GetTopByLevel(List<Gamer> gamers)
    {
        int qyantityGamers = 3;
        IEnumerable<Gamer> filtredGamers = gamers.OrderByDescending(gamer => gamer.Level).Take(qyantityGamers);

        return filtredGamers.ToList();
    }

    public List<Gamer> GetTopByForse(List<Gamer> gamers)
    {
        int qyantityGamers = 3;
        IEnumerable<Gamer> filtredGamers = gamers.OrderByDescending(gamer => gamer.Forse).Take(qyantityGamers);

        return filtredGamers.ToList();
    }
}