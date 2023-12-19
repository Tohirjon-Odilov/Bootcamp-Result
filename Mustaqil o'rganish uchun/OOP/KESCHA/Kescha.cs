namespace OOP.KESCHA
{
    internal class Kescha
    {
        public Kescha()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine()!;
            string greeting = $"Hello, {name}!";
            Console.WriteLine(greeting);
            Console.Write("Enter your age: ");
            string ageAsString = Console.ReadLine()!;
            Console.WriteLine("Converting...");
            int age = Convert.ToInt32(ageAsString);
            Console.WriteLine($"Successfully converted! {age}");
            
            Animal kescha = new Animal();
            kescha.Age = 3;

            int keschasAge = 3;
            int ageDifference = age - keschasAge;

            Console.WriteLine($"The difference between your and Kescha's age is {age} year old.");

            if(age > keschasAge)
            {
                Console.WriteLine("You are older than Kescha!");
            }
            else if(age == kescha.Age)
            {
                Console.WriteLine("You are the same age as Kescha!");
            }
            else 
            {
                Console.WriteLine("You are younger!");
            }

            Console.WriteLine("Let me tell you about my friends.");

            string[] friendsName = new string[3];
            friendsName[0] = "Kasee";
            friendsName[1] = "Kasim";
            friendsName[2] = name;
            int[] friendsAge = { 1, 2, age };

            for(int i = 0; i < friendsAge.Length; i++) { friendsAge[i] = ageDifference; }
                
        }
    }
}

