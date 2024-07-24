//aula 226
class Program
{
    static async void Main(string[] args)
    {
        Console.WriteLine("Streans Assíncronas\n");
        //var meses = new List<string>() { "Janeiro", "Fevereiro", "Março", "Abril" };
        await foreach (var me in GerarMeses())
        {
            Console.WriteLine(me);
        }
        Console.ReadLine();
    }
    static private async IAsyncEnumerable<string> GerarMeses()
    {
        yield return "Janeiro";
        yield return "Fevereiro";
        await Task.Delay(2000);
        yield return "Março";
        yield return "Abril";
    }
}
