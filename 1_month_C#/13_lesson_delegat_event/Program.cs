int? a = null;
int? b = 34;

int? z = a == null ? b : b == null ? a : a == null && b == null ? null : a;

Console.WriteLine(z);