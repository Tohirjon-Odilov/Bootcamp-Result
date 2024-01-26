using _33_lesson_takrorlash_experience;

// shu qatordan keyingi codelar main functionni ichida 
var a = new Person("John");
var b = new Person("John");
Console.WriteLine(a.Equals(b));


// natija: False (chunki default reference bilan tekshiradi)
// Vazifa. a.Equals(b) -> true bo'ladigan qiling ya'ni ismlari bir xil bo'lgan Person lar teng.