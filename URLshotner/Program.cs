class Program
{
    static void Main(string[] args)
    {
        string apiKey = "3dcd51995df8dcc2ca58c5565ddfca919f937e39";

        BitlyShortener shortener = new BitlyShortener(apiKey);

        Console.WriteLine("--- Encurtador de URL ---");
        Console.WriteLine("");
        Console.Write("URL:");
        string longUrl = Console.ReadLine();

        string shortUrl = shortener.ShortenUrl(longUrl);

        Console.WriteLine("URL encurtada: " + shortUrl);
    }
}
