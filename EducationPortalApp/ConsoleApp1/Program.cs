//Console.WriteLine("sayı giriniz");
//double sayi=Convert.ToInt32(Console.ReadLine());
//double faktoriyel = 1;

//for (int i=1; i <= sayi;i++)
//    {
//    faktoriyel *= i;
//}
//Console.WriteLine("{0} sayısının faktoriyeli={1}", sayi, faktoriyel);
//Console.ReadKey();


//int num=Convert.ToInt32(Console.ReadLine());
//for(int i=1; i <= 10; i++) { 
//    Console.WriteLine($"{num}x{i}={num*i}");
//}

Console.Write("Bir kelime giriniz: ");
string kelime = Console.ReadLine();
string kelime_ters = "";
for (int i = kelime.Length - 1; i >= 0; i--)
{
    kelime_ters += kelime[i];
}
Console.WriteLine("\nKelimenin tersten yazılısı = " + kelime_ters);
if (kelime_ters == kelime)
{
    Console.WriteLine("\nGirilen kelime Palindromik bir kelimedir.");
}
else
{
    Console.WriteLine("\nGirilen kelime Palindromik bir kelime değildir.");
}
Console.ReadLine();