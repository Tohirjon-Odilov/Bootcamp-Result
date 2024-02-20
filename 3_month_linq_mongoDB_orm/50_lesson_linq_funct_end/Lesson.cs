namespace _50_lesson_linq_funct_end;

public static class Lesson
{
    public static void run()
    {
        var list  = new List<int>()
        {
            1,2,3,4,5,6,7,8,9
        };

        Console.WriteLine(list.Skip(3));
    }
}
