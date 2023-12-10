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

//int a = 1;
//a++;
//a--;

//int numberOne = 9;
//float numberTwo = 4;
//int result = numberOne / numberTwo;
//float result2 = numberOne / numberTwo;

//Console.WriteLine(nameof(result2));
//Console.WriteLine(sizeof(int));

// dotnet'ga 
//Console.WriteLine(typeof(string));

//string color = "red";
//string result = color switch
//{
//    "red" => "The color is red.",
//    "green" => "The color is green",
//    _ => "Unknown color"
//};

//Console.WriteLine(result);


/////////////// Vazifa
//Boolean 34 ================ Oq =====================

/*Console.Write("x = ");
int x = int.Parse(Console.ReadLine());
Console.Write("y = ");
int y = int.Parse(Console.ReadLine());

if ((x + y) % 2 == 0)
{
    Console.WriteLine("Qora");
}
else
{
    Console.WriteLine("Oq");
}

Console.ReadKey();*/


// Boolean 35 ================== Bir xil rang ========================

/*Console.Write("x1 = ");
int x1 = Convert.ToInt32(Console.ReadLine());
Console.Write("y1 = ");
int y1 = Convert.ToInt32(Console.ReadLine());

Console.Write("x2 = ");
int x2 = Convert.ToInt32(Console.ReadLine());
Console.Write("y2 = ");
int y2 = Convert.ToInt32(Console.ReadLine());


if ((x1 + y1) % 2 == 0 && (x2 + y2) % 2 == 0 || (x1 + y1) % 2 == 0 && (x2 + y2) % 2 == 0)
{
    Console.WriteLine(true);
}
else
{
    Console.WriteLine(false);
}
*/

// Boolean 36 ================ Ruh ===============


/*Console.Write("x1 = ");
int x1 = Convert.ToInt32(Console.ReadLine());
Console.Write("y1 = ");
int y1 = Convert.ToInt32(Console.ReadLine());

Console.Write("x2 = ");
int x2 = Convert.ToInt32(Console.ReadLine());
Console.Write("y2 = ");
int y2 = Convert.ToInt32(Console.ReadLine());


if  (x1 == x2 || y1 == y2)
{
    Console.WriteLine(true);
}
else
{
    Console.WriteLine(false);
}*/


// Boolean 37 ================== Shoh =================

/*Console.Write("x1 = ");
int x1 = Convert.ToInt32(Console.ReadLine());
Console.Write("y1 = ");
int y1 = Convert.ToInt32(Console.ReadLine());

Console.Write("x2 = ");
int x2 = Convert.ToInt32(Console.ReadLine());
Console.Write("y2 = ");
int y2 = Convert.ToInt32(Console.ReadLine());

int res = x1 + y1;
int res2 = x2 + y2;

if (Math.Abs(res - res2) == 1)
{
    Console.WriteLine(true);
}
else
{
    Console.WriteLine(false);
}*/


// Boolean 38 ================ Fil ====================

/*Console.Write("x1 = ");
int x1 = Convert.ToInt32(Console.ReadLine());
Console.Write("y1 = ");
int y1 = Convert.ToInt32(Console.ReadLine());

Console.Write("x2 = ");
int x2 = Convert.ToInt32(Console.ReadLine());
Console.Write("y2 = ");
int y2 = Convert.ToInt32(Console.ReadLine());


if (Math.Abs(x1 - y2) == Math.Abs(x2 - y1)){
    Console.WriteLine(true);
}
else
{
    Console.WriteLine(false);
}*/


// Boolean 39 =================== Farzin ===================

/*Console.Write("x1 = ");
int x1 = Convert.ToInt32(Console.ReadLine());
Console.Write("y1 = ");
int y1 = Convert.ToInt32(Console.ReadLine());

Console.Write("x2 = ");
int x2 = Convert.ToInt32(Console.ReadLine());
Console.Write("y2 = ");
int y2 = Convert.ToInt32(Console.ReadLine());


if (x1 == x2 || y1 == y2 || Math.Abs(x1 - y2) == Math.Abs(x2 - y1))
{
    Console.WriteLine(true);
}
else
{
    Console.WriteLine(false);
}
*/


// Boolean 40 =================  Ot  ================

/*
Console.Write("x1 = ");
int x1 = Convert.ToInt32(Console.ReadLine());
Console.Write("y1 = ");
int y1 = Convert.ToInt32(Console.ReadLine());

Console.Write("x2 = ");
int x2 = Convert.ToInt32(Console.ReadLine());
Console.Write("y2 = ");
int y2 = Convert.ToInt32(Console.ReadLine());

if ((Math.Abs(x1 - x2) == 2) && (Math.Abs(y1 - y2) == 1) || (Math.Abs(y1 - y2) == 1) && (Math.Abs(y1 - y2) == 2))
{
    Console.WriteLine(true);
}
else
{
    Console.WriteLine(false);
}*/


// 3 - masala
/*
Console.Write("Son kiriting: ");
int x1 = 8;
    //Convert.ToInt32(Console.ReadLine());

Console.Write("Son kiriting: ");
int x2 = 5;
    //Convert.ToInt32(Console.ReadLine());

Console.Write("Son kiriting: ");
int x3 = 7;
//Convert.ToInt32(Console.ReadLine());

Console.Write("Son kiriting: ");
int x4 = 5;
    //Convert.ToInt32(Console.ReadLine());

Console.Write("Son kiriting: ");
int x5 = 8;*/
//Convert.ToInt32(Console.ReadLine());
/*
Console.Write("Son kiriting: ");
int x6 = Convert.ToInt32(Console.ReadLine());

Console.Write("Son kiriting: ");
int x7 = Convert.ToInt32(Console.ReadLine());
*/

// 4 - masala

/*Console.Write("a ni kiriting: ");
double a = Convert.ToDouble(Console.ReadLine());

Console.Write("b ni kiriting: ");
double b = Convert.ToDouble(Console.ReadLine());

Console.Write("c ni kiriting: ");
double c = Convert.ToDouble(Console.ReadLine());

double discriminant = b * b - 4 * a * c;

if (discriminant >= 0)
{
    double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
    double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

    Console.WriteLine($"x1 = {x1}");
    Console.WriteLine($"x2 = {x2}");
}
else
{
    Console.WriteLine("Tenglama haqiqiy ildizlarga ega emas. Yechim yo'q.");
}

*/

// 5 - masala

Console.Write("Kun = ");
int day = Convert.ToInt16(Console.ReadLine());
Console.Write("Oy = ");
int month = Convert.ToInt16(Console.ReadLine());

if (month <= 1 || month >= 12 || day <= 1 || day >= 31)
{
    if (month == 1 && day >= 20 || month == 2 && day <= 18) Console.WriteLine("Qovg'a");
    else if (month == 2 && day >= 19 || month == 3 && day <= 20) Console.WriteLine("Baliq");
    else if (month == 3 && day >= 21 || month == 4 && day <= 19) Console.WriteLine("Qo'y");
    else if (month == 4 && day >= 20 || month == 5 && day <= 20) Console.WriteLine("Buzoq");
    else if (month == 5 && day >= 21 || month == 6 && day <= 21) Console.WriteLine("Egizak");
    else if (month == 6 && day >= 22 || month == 7 && day <= 22) Console.WriteLine("Qisqichbaqa");
    else if (month == 7 && day >= 23 || month == 8 && day <= 22) Console.WriteLine("Arslon");
    else if (month == 8 && day >= 23 || month == 9 && day <= 22) Console.WriteLine("Parizod");
    else if (month == 9 && day >= 23 || month == 10 && day <= 22) Console.WriteLine("Tarozi");
    else if (month == 10 && day >= 23 || month == 11 && day <= 22) Console.WriteLine("Chayon");
    else if (month == 11 && day >= 23 || month == 12 && day <= 21) Console.WriteLine("O'q otar");
    else if (month == 12 && day >= 22 || month == 1 && day <= 19) Console.WriteLine("Echki");
    else Console.WriteLine("Error! ");
}
else
{
    Console.WriteLine("Noto'g'ri kiritilgan sanalar. Iltimos, qayta kiriting.");
}

