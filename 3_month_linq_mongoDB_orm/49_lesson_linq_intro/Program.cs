var list = new List<int>()
    {
        1,2,3,4,5,6,7,8,9
    };

var result = list.ElementAt(3);
var end = list.ElementAt(6);

var result2 = list.Select(a => a == result);

foreach (var item in result2)
{
    Console.WriteLine(item);
}