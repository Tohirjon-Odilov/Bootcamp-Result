namespace _19_lesson_exam_1_1
{
    internal class MyValueTuple
    {
        public MyValueTuple()
        {
            // ValueTuple yaratish
            var person = ("John", "Doe", 25);

            // Elementlarga murojaat
            string firstName = person.Item1;
            string lastName = person.Item2;
            int age = person.Item3;

            // Konsolga chiqarish
            Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Age: {age}");

            // Nomlangan tuple
            var namedPerson = (FirstName: "Alice", LastName: "Smith", Age: 30);

            // Elementlarga nom orqali murojaat
            string namedFirstName = namedPerson.FirstName;
            string namedLastName = namedPerson.LastName;
            int namedAge = namedPerson.Age;

            // Konsolga chiqarish
            Console.WriteLine($"First Name: {namedFirstName}, Last Name: {namedLastName}, Age: {namedAge}");
        }
    }
}
