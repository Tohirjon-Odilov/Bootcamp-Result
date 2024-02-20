using _50_lesson_linq_funct_end.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace _50_lesson_linq_funct_end
{
    //Model bo'sin aytaylik ProgrammingLanguage Id, Name Buxgalters degan
    //Id, BName, ProgrammingLanguageId sizlar Dasturlash tilini biladigan
    //Buxgalternarni chiqarib berishingiz kerak. C# ni biladigan Bugalterlar
    //kerak bizga Qaysi programmingLanguagelarni => qaysi bugalterlar biladi yana qo'shaman
    public class Homework
    {
        public Homework()
        {
            var programmingLanguages = new List<ProgrammingLanguage>()
            {
                new ProgrammingLanguage(){Id = 1, Name = "C#"},
                new ProgrammingLanguage(){Id = 2, Name = "Java"},
                new ProgrammingLanguage(){Id = 3, Name = "Python"},
                new ProgrammingLanguage(){Id = 4, Name = "JavaScript"},
                new ProgrammingLanguage(){Id = 5, Name = "C++"},
            };

            var bugalters = new List<Bugalters>()
            {
                new Bugalters(){ Id = 1, BName = "Tohirjon", ProgrammingLanguageId = 1},
                new Bugalters(){ Id = 2, BName = "Javlon"},
                new Bugalters(){ Id = 3, BName = "Sevara", ProgrammingLanguageId = 2},
                new Bugalters(){ Id = 4, BName = "Bekzod"},
                new Bugalters(){ Id = 5, BName = "Jamshid"},
                new Bugalters(){ Id = 6, BName = "Murtozbek", ProgrammingLanguageId= 2},
                new Bugalters(){ Id = 7, BName = "Javohir", ProgrammingLanguageId=5}
            };

            // Dasturlashni biladigan bugalterlar            
            //var result = 
            //    bugalters.Join(programmingLanguages, bugalter => 
            //    bugalter.ProgrammingLanguageId, programmingLanguage => 
            //    programmingLanguage.Id, (bugalter, programmingLanguage) => 
            //    new { bugalter, programmingLanguage });

            // C# ni biladigan bugalterlar
            //var result = 
            //    bugalters.Join(programmingLanguages, bugalter => 
            //    bugalter.ProgrammingLanguageId, programmingLanguage => 
            //    programmingLanguage.Id, (bugalter, programmingLanguage) => 
            //    new { bugalter, programmingLanguage }).Where(bugalter => bugalter.programmingLanguage.Name == "C#");

            // Qaysi tillarini kimlar biladi
            var result = programmingLanguages.GroupJoin(bugalters, programmingLanguage => programmingLanguage.Id, bugalter => bugalter.ProgrammingLanguageId, (programmingLanguage, bugalter) => new { programmingLanguage, bugalter });
            foreach (var bugalter in result)
            {
                Console.WriteLine(bugalter.programmingLanguage.Name + " " + JsonConvert.SerializeObject(bugalter.bugalter, Formatting.Indented));
            }
        }
    }
}
