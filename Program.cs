using TelefonCLI;

List <Phone> phones = new List <Phone>();
using (StreamReader r = new StreamReader("../../../forras/telefonok.txt"))
{
    r.ReadLine(); 
    while (!r.EndOfStream) 
    {
        string line = r.ReadLine(); 
        phones.Add(new Phone(line)); 
    };
}

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"{phones[i].ToString()}");
}

Console.WriteLine("6. feladat");

var f6 = phones.Where(x => x.Sold == "Nem" &&
x.OS.OSName == "Android" &&
x.Warranty == "Igen" &&
x.Condition == "Újszerű" &&
x.Battery.Contains(" to "));

foreach (Phone phone in f6)
{
    Console.WriteLine(phone.ToString());
}

var aksi = f6.Min(x => x.Battery);

Console.WriteLine($"A leszűrt telefonok akkumulátor-kategóriájának legkisebb alsó határa: {aksi.Split(" to ")[0]} mAh");

var ar = f6.Where(x => x.Price !=0).Average(x => x.Price);

Console.WriteLine($"A leszűrt, ismert árú telefonok átlagára: {ar:N0} Ft");

Console.WriteLine("7. feladat");

var f7 = phones.Where(x => x.County == "Pest" &&
x.Sold == "Nem" &&
x.Year >= 2021 &&
x.Year <= 2024).OrderByDescending(x => x.Storage).ThenBy(x => x.Brand.BrandName);

using (StreamWriter w = new StreamWriter("../../../forras/pest.txt"))
{
    foreach (Phone phone in f7)
    {
        w.WriteLine($"{phone.Storage} GB {phone.Brand.BrandName} {phone.Model}");
    }
}