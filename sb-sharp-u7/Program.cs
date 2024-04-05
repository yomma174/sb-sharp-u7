namespace sb_sharp_u7
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Worker w = new Worker("Программист", 1000, "Ivan", "Ivanov", new DateTime(1980, 1, 2));
            Console.WriteLine(w.Print());

            w = new Worker("Ivan IV");
            Console.WriteLine(w.Print());

            Cat1 cat1 = new Cat1("brodyaga","nick");
            Console.WriteLine(cat1.Breed);
        }
    }
}
