int? a = null;
int? b = 34;
Console.WriteLine(a == null ? b : b == null ? a : a == null && b == null ? null : a);