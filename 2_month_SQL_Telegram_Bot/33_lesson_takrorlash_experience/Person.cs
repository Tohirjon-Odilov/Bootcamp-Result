namespace _33_lesson_takrorlash_experience
{
    public class Person
    {
        string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Person otherPerson = (Person)obj;
            return Name == otherPerson.Name;
        }
    }
}
