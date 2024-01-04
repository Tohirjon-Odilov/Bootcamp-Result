
using _18_Lesson_Json.Task;
using _18_Lesson_Json.Task_2;
using System.Text.Json;

#region Task 1
/*
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
*/
#endregion
#region Task 2
/*
List<UserInfo> Users = new List<UserInfo>();

UserInfo User1 = new UserInfo()
{
    Id = 1,
    Name = "Tohirjon",
    LastName = "Odilov",
    Age = 20
};
UserInfo User2 = new UserInfo()
{
    Id = 2,
    Name = "Akramjon",
    LastName = "Abduvahobov",
    Age = 14
}; 
UserInfo User3 = new UserInfo()
{
    Id = 3,
    Name = "Eldor",
    LastName = "Azizov",
    Age = 17
}; 
UserInfo User4 = new UserInfo()
{
    Id = 4,
    Name = "Hoshim",
    LastName = "Arslonov",
    Age = 18
};

Users.Add(User1);
Users.Add(User2);
Users.Add(User3);
Users.Add(User4);

string Array = JsonSerializer.Serialize(Users);
Console.WriteLine(Array);
*/
#endregion