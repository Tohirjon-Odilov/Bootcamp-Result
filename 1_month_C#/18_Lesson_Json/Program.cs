using _18_Lesson_Json.Task;
using System.Text.Json;

BaseModul json = new BaseModul()
{
    Id = 1,
    Name = "Tohirjon",
    UserName = "Coder",
    Email = "tohirjonodilov19@gmail.com",
    Address = new Address()
    {
        Street = "Ko'kcha",
        Suite = "Nimadur",
        City = "Toshkent",
        ZipCode = "100054",
        Geo = new Geo()
        {
            Lang = "387.33434",
            Lat = "-2348887.3434",
            Magic = new Magic()
            {
                Type = "11",
                Section = "My section"
            }
        }
    },
    Phone = "+998 99 873 49 75",
    Website = "tohirjon-odilov.uz",
    Company = new Company()
    {
        Name = "Najot Ta'lim",
        CatchPhrase = "Zamonaviy kasblar markazi",
        BS = "Najot ta'lim'da"
    },
    Location = new Location()
    {
        Adress = "Toshekent",
        Mintaqa = new Mintaqa()
        {
            Hudud = "Chilonzor",
            Manzil = "Qatortol ko'chasi",
            Mahalla = new Mahalla()
            {
                Name = "Qatortol - Mahllasi",
                Kucha = "198 - kucha"
            }
        }
    }
};

string ModulToJson = JsonSerializer.Serialize(json);

Console.WriteLine(ModulToJson);