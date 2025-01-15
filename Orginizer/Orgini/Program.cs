using Orginigger;

Console.WriteLine("Orgnizing Main Folders...");
Console.Write("Paste The Path Of a Directory To Orginize: ");
string path = Console.ReadLine();
DirectManager.OrganizeFolder(path);
