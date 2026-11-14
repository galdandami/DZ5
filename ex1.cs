using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Ошибка: не указано имя файла.");
            Console.WriteLine("Использование: program.exe <путь_к_файлу>");
            return;
        }

        string fileName = args[0];

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Ошибка: файл '{fileName}' не найден.");
            return;
        }

        string text = File.ReadAllText(fileName);
        char[] chars = text.ToCharArray();

        (int vowels, int consonants) = CountLetters(chars);

        Console.WriteLine($"Файл: {fileName}");
        Console.WriteLine($"Количество гласных букв: {vowels}");
        Console.WriteLine($"Количество согласных букв: {consonants}");
        Console.ReadLine();
    }

    static (int vowels, int consonants) CountLetters(char[] chars)
    {
        string vowelsSet = "аеёиоуыэюяaeiouy";
        string consonantsSet = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxz";

        int vowels = 0;
        int consonants = 0;

        foreach (char c in chars)
        {
            char lower = char.ToLower(c);

            if (vowelsSet.IndexOf(lower) >= 0)
            {
                vowels++;
            }
            else if (consonantsSet.IndexOf(lower) >= 0)
            {
                consonants++;
            }
        }

        return (vowels, consonants);
    }
}