
#region bu yerda backslash bilan ishlangan

//using System.Runtime.CompilerServices;

//string item = "bu yerda nimadur kelyapti \"nimadur bomi\" nima gap";
//Console.WriteLine(item);


#endregion

#region array
//string []item1 = ["salom", "hello"];

//foreach(string i in item1)
//{
//    Console.WriteLine(i);
//}
//Console.WriteLine(item1);

//int[] arr = {1, 2, 3};
#endregion

//Input: s = "abcde", goal = "cdeab"
//Output: true

//##################################//
// homework
#region koordinata
Console.WriteLine("Nechta kordinata kiritmoqchisiz >> ");
int l = int.Parse(Console.ReadLine()!);
int[] x = new int[l], y = new int[l];
for (int i = 0; i < l; i++)
{
    Console.WriteLine($"{i + 1} chi kordinatalarni kiriting>> ");
    x[i] = int.Parse(Console.ReadLine()!);
    y[i] = int.Parse(Console.ReadLine()!);
}
double masofa = 0;
for (int i = 0; i < l; i++)
{
    if (i == l - 1) { break; }
    masofa += Math.Sqrt(Math.Pow(x[i + 1] - x[i], 2) + Math.Pow(y[i + 1] - y[i], 2));
}

Console.WriteLine(masofa);
#endregion

#region reverse-integer
public class Solution
{
    public int Reverse(int x)
    {
        var result = 0;
        while (x != 0)
        {
            var remainder = x % 10;
            var temp = result * 10 + remainder;
            if ((temp - remainder) / 10 != result) return 0;
            result = temp;
            x /= 10;
        }

        return result;
    }
}
#endregion

#region fibonachi
/*public class Solution
{
    public int Fib(int n)
    {
        if (n <= 1) return n;
        int f0 = 0;
        int F1 = 1;
        for (int i = 2; i <= n; i++)
        {
            int Fn = F1 + f0;
            f0 = F1;
            F1 = Fn;
        }
        return F1;
    }
}*/
#endregion

#region Roman number
/*public class Solution
{
    public int RomanToInt(string s)
    {
        int res = 0;
        int prev = 0;
        Dictionary<char, int> romanNumerals =
            new Dictionary<char, int>
            {
                    {'M', 1000},
                    {'D', 500},
                    {'C', 100},
                    {'L' , 50},
                    {'X' , 10},
                    {'V' , 5},
                    {'I' , 1}
            };

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (prev <= romanNumerals[s[i]])
            {
                res += romanNumerals[s[i]];
            }
            else if (prev > romanNumerals[s[i]])
            {
                res -= romanNumerals[s[i]];
            }
            prev = romanNumerals[s[i]];
        }
        return res;
    }
}*/
#endregion

#region perfect number
/*public class Solution
{
    public bool CheckPerfectNumber(int num)
    {
        int count = 0;
        for (int i = 1; i <= num / 2; i++)
        {
            if (num % i == 0)
            {
                count += i;
            }
        }
        return count == num ? true : false;
    }
}*/
#endregion