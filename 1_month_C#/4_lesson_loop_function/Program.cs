﻿//void Sum(decimal a, decimal b)
//{
//    Console.WriteLine(a + b);
//}

//Sum(15, 12.5m);

decimal Sum(params decimal[] list)
{
    decimal sum = 0;
    for (int i = 0; i < list.Length; i++)
    {
        sum += list[i];
    }
    return sum;
}

Console.WriteLine(Sum(45.5454m, 4545, 454545, 4545.859m));