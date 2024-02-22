using System;

namespace NajotTalim.HR.API.Models
{
    public class Users
    {
        //Agar cproj file ichidagi nullable xossasini o'chirib tashlasak bu yerdagi warning ketadi bu esa dasturimizda xatoliklar kelishi yo'q qo'yadi.
        // shuning uchun biz bularni null kelishi mumkin deb tayinlashimiz kerak.
        //birinchi usul
        public Users()
        {
            Name = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            Username = string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
    // ikkinchi usul
    public class UsersResponse
    {
        public string? Token { get; set; }
    }
    // uchunchi usul
    public class UsersLogin
    {
        public string login { get; set; } = String.Empty;
    }
}
