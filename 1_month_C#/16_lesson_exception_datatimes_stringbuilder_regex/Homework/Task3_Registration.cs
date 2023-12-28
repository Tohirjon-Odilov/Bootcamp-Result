using System.Text.RegularExpressions;

namespace _16_lesson_exception_datatimes_stringbuilder_regex.Homework
{
    internal class Task3_Registration
    {
        //private string UserSelection {  get; set; }
        public Task3_Registration(string userSelection) 
        {
            Console.Write(">> ");
            string user = Console.ReadLine()!;
            //IsPasswordValidation("Tohirjon#9");

            if (userSelection == "1")
            {
                //    //Console.Write("Enter your email: ");
                //    //string email = Console.ReadLine()!;
                IsEmailValidation(user);
            }
            else if (userSelection == "2")
            {
                //    //Console.Write("Enter your phone number: ");
                //    //string phoneNumber = Console.ReadLine()!;
                IsPhoneNumberValidation(user);
            }
            else if (userSelection == "3")
            {
                //    //Console.Write("Enter your password: ");
                //    //string password = Console.ReadLine()!;
                IsPasswordValidation(user);
            }
            else if (userSelection == "4")
            {
                //    //Console.Write("Enter your birthday: ");
                //    //string birthday = Console.ReadLine()!;
                IsBirthdayValidation(user);
            }
        }

        public bool IsEmailValidation(string email) 
        {
            string pattern = @"^[a-z0-9_-]+@[a-z0-9]+\.[a-z]{2,}$";
            //bool isValidEmail = Regex.IsMatch("tohirjon-odilov@gmail.com", pattern);
            bool isValidEmail = Regex.IsMatch(email, pattern);
            Console.WriteLine(isValidEmail);
            return true; 
        }
        public bool IsPhoneNumberValidation(string phoneNumber) 
        {
            string pattern = @"^[+]998\s(\d{2})\s(\d{3})\s(\d{2})\s(\d{2})$";
            //bool isValidPhoneNumber = Regex.IsMatch("+998 99 873 49 75", pattern);
            bool isValidPhoneNumber = Regex.IsMatch(phoneNumber, pattern);
            Console.WriteLine(isValidPhoneNumber);
            return true;
        }
        public void IsPasswordValidation(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{9,16}$";
            //bool isValidPassword = Regex.IsMatch("Tohirjon_2312", pattern);
            bool isValidPassword = Regex.IsMatch(password, pattern);
            if (isValidPassword ) 
            {
                Console.WriteLine("Success!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Not success!!!");
                Console.ReadKey();
            }
        }
        public bool IsBirthdayValidation(string birthday) 
        {
            string pattern = @"^(\d{2})-(\d{2})-(\d{4})$";
            //bool isValidEmail = Regex.IsMatch("12-11-2211", pattern);
            bool isValidEmail = Regex.IsMatch(birthday, pattern);
            Console.WriteLine(isValidEmail);
            return true; 
        }

    }
}
