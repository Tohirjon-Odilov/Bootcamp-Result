/*
Array:
oxiriga qo'shish: O(n) => Ma'lumot qo'shish uchun avval to'liq o'rganib chiqadi.
oxiridan olib tashlash: O(n) => oxiridan olib tashlash uchun to'liq o'rganib keyin o'chiradi.
o'rtasiga ma'lumot qo'shish: O(n) => Ma'lumot qo'shish uchun avval to'liq o'rganib chiqadi.
o'rtadan olib tashlash: O(n) => oxiridan olib tashlash uchun to'liq o'rganib keyin o'chiradi.
Muayyan elementni qidirish: O(n) => ma'lumotni qidirish uchun avval to'liq o'rganib chiqadi.
Izoh: Xotiradan samarali foydalanadi; ma'lumotlar hajmi aniqlangan hollarda foydalanamiz.

List:
oxiriga qo'shing: best case O(1); worst case O(n)
oxiridan olib tashlash: O(1) => oxiridan ma'lumotni o'chirish bitta amalgan oshadi.
o'rtasiga ma'lumot qo'shish: O(n) => Ma'lumot qo'shish uchun avval to'liq o'rganib chiqadi.
o'rtadan olib tashlash: O(n) => oxiridan olib tashlash uchun to'liq o'rganib keyin o'chiradi.
Muayyan elementni qidirish: O(n) => 
Izoh: Ko'p hollarda List eng yaxshi tanlov bo'ladi.

LinkedList:
oxiriga qo'shing: O(1)
oxiridan olib tashlash: O(1) => oxiridan ma'lumotni o'chirish bitta amalgan oshadi.
o'rtasiga ma'lumot qo'shish: O(1)
o'rtadan olib tashlash: O(1) => oxiridan ma'lumotni o'chirish bitta amalgan oshadi.
Muayyan elementni qidirish: O(n) => 
Izoh: Ushbu collection juda ham tez ishlaydi ammo xotiradan joy ko'p oladi.

Stack:
oxiriga qo'shing: best case O(1); worst case O(n)
oxiridan olib tashlash: O(1) => oxiridan ma'lumotni o'chirish bitta amalgan oshadi.
o'rtasiga ma'lumot qo'shish: N/A => o'rtasiga ma'lumot qo'sha olmaymiz.
o'rtadan olib tashlash: N/A => O'rtadan ma'lumotni o'chira olmaymiz.
Muayyan elementni qidirish: N/A => ma'lumotlarni ham qidira olmaymiz.
Izoh: uning asosiy xususiyati o'ngdan chiqarilish (LIFO - Last In, First Out) prinsipi bo'yicha ishlashidir.

Queue:
oxiriga qo'shing: best case O(1); worst case O(n)
oxiridan olib tashlash: O(1) => oxiridan ma'lumotni o'chirish bitta amalgan oshadi.
o'rtasiga ma'lumot qo'shish: N/A => o'rtasiga ma'lumot qo'sha olmaymiz.
o'rtadan olib tashlash: N/A => O'rtadan ma'lumotni o'chira olmaymiz.
Muayyan elementni qidirish: N/A => ma'lumotlarni ham qidira olmaymiz.
Izoh:  uning asosiy xususiyati chapdan o'qish (FIFO - First In, First Out) prinsipi bo'yicha ishlashidir.

Dictionary:
oxiriga qo'shing: best case O(1); worst case O(n)
oxiridan olib tashlash: O(1) => oxiridan ma'lumotni o'chirish bitta amalgan oshadi.
o'rtasiga ma'lumot qo'shish: best case O(1); worst case O(n)
o'rtadan olib tashlash: O(1) => oxiridan ma'lumotni o'chirish bitta amalgan oshadi.
Muayyan elementni qidirish: O(1)
Izoh:  kalit (key) va qiymat (value) orqali juftlikdagi ma'lumotlarni saqlash uchun ishlatiladi. Bu to'plam turi, kalitlarni o'z ichiga qabul qilib, ularga tezkor murojaat qilish imkonini beradi..
*/