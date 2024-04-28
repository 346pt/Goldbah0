using System;
using System.Collections.Generic;

class Goldbach
{
    static bool IsPrime(int num)
    {
        if (num <= 1) return false;
        if (num <= 3) return true;
        if (num % 2 == 0 || num % 3 == 0) return false;

        for (int i = 5; i * i <= num; i += 6)
        {
            if (num % i == 0 || num % (i + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }

    static void FindAllGoldbachPairs(int num)
    {
        if (num <= 2 || num % 2 != 0)
        {
            Console.WriteLine("Некорректное число. Введите четное число больше 2.");
            return;
        }

        List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();

        for (int i = 2; i <= num / 2; i++)
        {
            if (IsPrime(i) && IsPrime(num - i))
            {
                pairs.Add(Tuple.Create(i, num - i));
            }
        }

        if (pairs.Count > 0)
        {
            Console.WriteLine($"Возможные суммы для {num}:");
            foreach (var pair in pairs)
            {
                Console.WriteLine($"{num} = {pair.Item1} + {pair.Item2}");
            }
        }
        else
        {
            Console.WriteLine($"Для числа {num} не найдено пар простых чисел.");
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Введите четное число больше 2: ");
        int number = int.Parse(Console.ReadLine());

        FindAllGoldbachPairs(number);
    }
}