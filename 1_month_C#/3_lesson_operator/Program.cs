// binary to decimal

//int number = 0b10101100;
//Console.WriteLine(number);

// binary to hex decimal

//int number = 0b10101100;
//Console.WriteLine(number);

//string binary = Convert.ToString(number, 16);
//Console.WriteLine(binary);

//Console.WriteLine(9 | 3);
//Console.WriteLine(9 & 3);

//int a = 0b100100;

//string bin = Convert.ToString(42, 10);
//Console.Write(42 << 2);
// right shift 9 << 2, 9 * (2*2) ya'ni 2 ni darajasiga ko'paytiriladi
// 

// left shift 9 >> 2, 9 / (2*2) ya'ni 2 ni darajasiga ko'paytirib 9 bo'lish orqali taqriban hisob lashimiz mumkin
// 9 / (2*2) = 9 / 4 = 2

int a = 1;
a++;
a--;

int numberOne = 9;
float numberTwo = 4;
//int result = numberOne / numberTwo;
float result2 = numberOne / numberTwo;

//Console.WriteLine(nameof(result2));
//Console.WriteLine(sizeof(int));

// dotnet'ga 
//Console.WriteLine(typeof(string));

string color = "red";
string result = color switch
{
    "red" => "The color is red.",
    "green" => "The color is green",
    _ => "Unknown color"
};

Console.WriteLine(result);
