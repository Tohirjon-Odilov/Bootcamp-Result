namespace _20_lesson_exam_1_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            Productname person = new Productname()
            {
                Id = 2,
                Product = "Iphone 19",
                Title = "nimadur"
            };
            user.Add(person);
        }
    }
}