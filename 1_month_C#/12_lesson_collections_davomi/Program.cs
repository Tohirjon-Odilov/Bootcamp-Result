//List<int> values = new List<int>();
using _12_lesson_collections_davomi.Task;
//using CollectionsPractice.Console;

public class Program
{
    #region Main
    public static void Main(string[] args)
    {
        // Real names for the students
        string[] studentFirstNames =
            [
                "Alice",
                "Bob",
                "Charlie",
                "David",
                "Emma",
                "Frank",
                "Grace",
                "Henry",
                "Isabel",
                "Jack",
                "Katie",
                "Liam",
                "Mia",
                "Nathan",
                "Olivia",
                "Paul",
                "Quinn",
                "Rachel",
                "Samuel",
                "Tara"
                ];

        // Real last names for the students
        string[] studentLastNames =
            [
                "Smith",
                "Johnson",
                "Williams",
                "Jones",
                "Brown",
                "Davis",
                "Miller",
                "Wilson",
                "Moore",
                "Taylor",
                "Anderson",
                "Thomas",
                "Jackson",
                "White",
                "Harris",
                "Martin",
                "Thompson",
                "Young",
                "Clark",
                "Walker"
                ];

        Student[] unsortedStudents = new Student[20];

        for (int i = 1; i <= studentFirstNames.Length; i++)
        {
            var student = new Student
            {
                Id = i,  //20, 19, .. 1
                FirstName = studentFirstNames[i - 1],
                LastName = studentLastNames[studentFirstNames.Length - 1]
            };

            // They are same
            //var student = new Student();
            //student.Id = i;
            //student.FirstName = studentFirstNames[i - 1];
            //student.LastName = studentLastNames[studentFirstNames.Length - i];

            unsortedStudents[i - 1] = student;
        }

        var sortedStudents = new SortedList<int, Student>();
        // TODO Consolega unsortedStudents elementlarini chiqaring (use while loop)
        // TODO unsortedStudents elementlarini birma-bir sortedStudentsga qo'shing
        #region while and unsorted to sorted
        short count = 0;
        while (unsortedStudents.Length != count)
        {
            sortedStudents.Add(unsortedStudents[count].Id, unsortedStudents[count]);
            //Console.WriteLine(
            //    $"{unsortedStudents[count].Id} " +
            //    $"{unsortedStudents[count].FirstName} " +
            //    $"{unsortedStudents[count].LastName}");
            count++;
        }
        #endregion

        #region TODO Consolega unsortedStudents elementlarini chiqaring (use for each loop)
        foreach (Student student in unsortedStudents)
        {
            //Console.WriteLine($"{student.Id} {student.FirstName} {student.LastName}");
        }
        #endregion

        var studentsQueueForFood = new Queue<Student>();
        int[] ls = [3, 4, 8, 17, 1, 6, 12];
        // TODO studentsQueueForFood  queue ga  Id 3, 4, 8, 17, 1, 6, 12 studentlarni qo'shing (Enqueue).

        foreach (var item in ls)
        {
            studentsQueueForFood.Enqueue(sortedStudents[item]);
        }

        // Har bir studentni ketma-ketlikda consolega chiqaring Masalan. Shu Idga ega bo'lgan ovqatga navbatga turdi
        foreach (var item in studentsQueueForFood)
        {
            //Console.WriteLine("ID->"+item.Id + "ga ega bo'lgan ovqatga navbatga turdi");

        }

        // TODO studentsQueueForFood  queue dan 4 ta studentni chiqaring.(Dequeue)
        for (int i = 0; i < 4; i++)
        {
            //Console.WriteLine("ID"+studentsQueueForFood.Dequeue().Id + " ga ega bo'lgan student ovqatni oldi");
        }

        // Har bir studentni ketma-ketlikda consolega chiqaring Masalan. Shu Idga ega bo'lgan student ovqatni oldi.
        var studentsEnrolledMathCourse = new HashSet<Student>();
        int[] mathe = [1, 3, 5, 6, 8, 18, 15, 13, 20];
        foreach (int i in mathe)
        {
            studentsEnrolledMathCourse.Add(sortedStudents[i]);
        }

        // TODO 1, 3, 5, 6, 8, 18, 15, 13, 20 id li studentlarni matematika kursiga qo'shing.
        var studentsEnrolledEnglishCourse = new HashSet<Student>();
        int[] english = [1, 2, 9, 6, 8, 7, 15, 13, 20];
        foreach (int i in english)
        {
            studentsEnrolledEnglishCourse.Add(sortedStudents[i]);
        }

        // TODO 1, 2, 9, 6, 8, 7, 15, 13, 20 id li studentlarni ingliz tili kursiga qo'shing.

        //studentsEnrolledEnglishCourse.IntersectWith(studentsEnrolledMathCourse);
        foreach (var student in studentsEnrolledEnglishCourse)
        {
            //Console.WriteLine(student.Id);
        }

        // TODO matematika va ingliz tiliga bir vaqtda qatnashayotgan studentlarni consolega chiqaring (IntersectWith) 

        //studentsEnrolledMathCourse.ExceptWith(studentsEnrolledEnglishCourse);
        foreach (var student1 in studentsEnrolledMathCourse)
        {
            // Console.WriteLine(student1.Id);
        }

        // TODO faqat matematikaga(ingliz tiliga emas) qatnashayotgan studentlarni consolega chiqaring (ExceptWith)
        studentsEnrolledMathCourse.IntersectWith(studentsEnrolledEnglishCourse);

        // TODO faqat ingliz tiliga(matematikaga emas) qatnashayotgan studentlarni consolega chiqaring (ExceptWith)
        //studentsEnrolledEnglishCourse.ExceptWith(studentsEnrolledMathCourse);

        foreach (var student2 in studentsEnrolledEnglishCourse)
        {
            //Console.WriteLine(student2.Id);
        }


        // TODO istalgan kursga qatnashayotgan studentlarni consolega chiqaring. (UnionWith)
        studentsEnrolledMathCourse.UnionWith(studentsEnrolledEnglishCourse);
        foreach (var i in studentsEnrolledMathCourse)
        {
            //Console.WriteLine(i.FirstName);
        }


        // HashSetlar reference type. UnionWith, ExceptWith va IntersectWith chaqirilgan hashSetlarni o'zgartiradi.

        // studentlarni id isiga ko'ra jurnalda saqlang. ma'lumotlarni sorted Listdan olib keling.

        var classJournal = new Dictionary<int, Student>();
        foreach (var st in sortedStudents)
        {
            classJournal.Add(st.Key, st.Value);
        }

        #region studentlarni jurnalini Consolega chiqaring.
        foreach (var jur in classJournal)
        {
            //Console.WriteLine(jur.Value.Id + " " + jur.Value.FirstName + " " + jur.Value.LastName);
        }
        #endregion
    }
    #endregion
}