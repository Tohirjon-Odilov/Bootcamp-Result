namespace _19_lesson_exam_1_1;

public class Overloads
{
    public int Value { get; set; }

    public Overloads(int value)
    {
        Value = value;
    }

    // Overloading the + operator
    public static Overloads operator +(Overloads a, Overloads b)
    {
        return new Overloads(a.Value + b.Value);
    }

    public static Overloads Add(Overloads a, Overloads b)
    {
        return new Overloads(a.Value + b.Value);
    }


    //public static Overloads Add(Out a, Overloads b)
    //{
    //    return new Overloads(a + b.Value);
    //}
}

class Program
{
    static void Main()
    {
        Overloads Overloads1 = new Overloads(5);
        Overloads Overloads2 = new Overloads(3);

        // Using the overloaded + operator
        //Overloads result = new Out() + Overloads2;


        Overloads result = Overloads.Add(Overloads1, Overloads2);

        Console.WriteLine($"Result: {result.Value}"); // Overloadsput: Result: 8
    }
}
