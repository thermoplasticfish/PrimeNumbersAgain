using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PrimeNumbersAgain;

class Program
{
    private const int MaxAllowableTime = 3_000;

    /// <summary>
    /// Prompts for a prime's position, times the search, and displays the result and time check.
    /// </summary>
    /// <param name="args">Command-line arguments; these are not used.</param>
    static void Main(string[] args)
    {
        int n, prime;
        Stopwatch timer = new Stopwatch();

        PrintBanner();
        n = GetNumber();

        timer.Start();
        prime = FindNthPrime(n);
        timer.Stop();
        
        
        Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.TotalMilliseconds:F3} milliseconds.");

        EvaluatePassingTime(timer.Elapsed.TotalMilliseconds);
    }

    /// <summary>
    /// Finds the prime at the specified one-based position. Students must implement this method.
    /// </summary>
    /// <param name="n">The requested position, from 1 through 1,999,999, where 1 represents the prime 2.</param>
    /// <returns>The prime at position <paramref name="n"/> once implemented; currently returns 0 as a placeholder.</returns>
    static int FindNthPrime(int n)
    {
        List<int> primes = new List<int>();
        primes.Add(2);
        
        if (n == 1)
            return primes[0];

        primes.Add(3);
        int nextNum = 3;
        while (primes.Count < n)
        {
            nextNum += 2;

            bool isPrime = true;

            for (int i = 0; i < primes.Count; i++)
            {
                if (primes[i] > Math.Sqrt(nextNum))
                {
                    break;
                }

                if (nextNum % primes[i] == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                primes.Add(nextNum);
            }
        }
        return primes[primes.Count - 1];
    }

    /// <summary>
    /// Prompts until the user enters a valid 32-bit integer.
    /// </summary>
    /// <returns>The entered integer; its range is not validated against the assignment requirements.</returns>
    static int GetNumber()
    {
        int n = 0;
        while (true)
        {
            Console.Write("Which nth prime should I find?: ");
            
            string num = Console.ReadLine();
            if (Int32.TryParse(num, out n))
            {
                return n;
            }

            Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
        }
    }

    /// <summary>
    /// Displays the application banner and configured time limit.
    /// </summary>
    static void PrintBanner()
    {
        Console.WriteLine(".................................................");
        Console.WriteLine(".#####...#####...######..##...##..######...####..");
        Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
        Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
        Console.WriteLine(".##......##..##....##....##...##..##..........##.");
        Console.WriteLine(".##......##..##..######..##...##..######...####..");
        Console.WriteLine(".................................................\n\n");
        Console.WriteLine($"Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under {MaxAllowableTime} milliseconds!\n\n");
        
    }

    /// <summary>
    /// Displays a colored pass or fail result by comparing the supplied time with the configured limit.
    /// </summary>
    /// <param name="time">The elapsed time in milliseconds to compare with <see cref="MaxAllowableTime"/>.</param>
    static void EvaluatePassingTime(double time)
    {
        Console.WriteLine("\n");
        Console.Write("Time Check: ");

        if (time <= MaxAllowableTime)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pass");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fail");
        }

        Console.ForegroundColor = ConsoleColor.Gray;
        
    }
}

