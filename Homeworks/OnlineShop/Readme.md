## Singelton Design Pattern
#### mashxur design patterni hisoblanadi
### `Foydali Tarflari`
#### Interface implement qilsa boladi.
#### Dependencyni berkitishga yordam berad
#### lazy-load bola oladi
### `Zararlari`
#### Unit Test yozish ancha murakkab
### `4-xil usulda ishlatish mumkin`
#### No Thread Safe Singleton orqali.
#### Thread-Safety Singleton orqali.
#### Thread-Safety Singleton using Double-Check Locking orqali.
#### Thread-safe without a lock orqali.
#### Using .NET 4's Lazy<T> type orqali.
#
#
## Sealed nima?
#### `sealed` bu keyword hisoblanib classlarga ishlatiladi.
#### sealed keywordi classni voris bolishiga ruxsat bermaydi.
#### lekn ota bo'la oladi.
#
#
## Constructor Private bo'lsa nima bo;ladi?
#### `private Constructor` method yoki atributlari bolmagan classlarda ishlatilib undan obyekt olishga ruxsat bermaydi
#
#
## CQRS paterni ustunliklari nimada?
#### Asosiy ustunligi boglanishda
#### `Repository Pattern` Birnecta serviceni bitta controllerda ishlatish uchun ularni barchasini chaqirish kerak
#### `CQRS` da esa Barcha metjodlar uchun faqat bitta MediatR ni chaqirish kifoya
#### `Repository Pattenda` bitta methodni ishlatilsa ham chaqirilgan barcha servicelar qauta barpo etiladi
#### `CQRS` da esa unday emas
#### `CQRS desgn Pattern` enterprise (ulkan) loyhalarda ishlatiladi, sababi Performancesi ota kuchli
#
#
## DI Container nima?
#### `Dependency Injection Continer` Constructorda classlarni ozlashtirayotganimizda yangi obyekt ochishga yordam beradi.
#
#
## IOC nima?
#### Dasturda IOC ni amalga oshirishning bir qatori usullari Dependency Injection (DI), Service Locator va Factory Pattern kabi.Bundan tashqari, IOC asosan Dependency Injection (DI) bilan bog'liq. Bu, obyektlarni boshqa obyektlarga beriladigan xizmatlarni injeksiya etishni ta'minlaydi. Bu, dastur tuzilishini oddiyroq va test qilishni osonlashtiradi.
#
#
## Constructor nima
#### `Constructor` bu class nomi bilan bir xil nomga ega bolgan Methoddir! va u obyekt olish uchun ishlatiladi
