using System;
using System.Collections.Generic;
using System.Diagnostics;
class LeaderboardEntry
{
    public string Nickname {get; set;}
    public int Speed {get; set;}
}
class TypingTest
{
    private static List<LeaderboardEntry> Leaderboard = new List<LeaderboardEntry>();
    static void Main()
    {
        bool repeatTest = true;
        while (repeatTest)
        {
            Console.WriteLine("Вам нужно ввести данный текст, запомните его:");
            string etomnenado = "каждый охотник желает знать где сидит фазан";
            Console.WriteLine(etomnenado);
            Console.Write("Нажмите Enter, чтобы начать");
            Console.ReadLine();
            Console.Clear();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Тест начался");
            string typedText = Console.ReadLine();
            timer.Stop();
            TimeSpan typingTime = timer.Elapsed;
            int characterCount = etomnenado.Length;
            int typingSpeed = CalculateSpeed(characterCount, typingTime.TotalMinutes);
            int typingspeed2 = CalculateSpeed(characterCount, typingTime.TotalSeconds);
            int errorCount = CalculateErrors(etomnenado, typedText);
            Console.WriteLine($"Скорость печати (в секундах): {typingTime.TotalSeconds}");
            Console.WriteLine($"Скорость печати символов в минуту: {typingSpeed}");
            Console.WriteLine($"Количество ошибок: {errorCount}");

            SaveToLeaderboard(typingSpeed);
            DisplayLeaderboard();

            Console.WriteLine("\nОтличный результат! Хотите повторить? (да или нет)");
            string userInput = Console.ReadLine().ToLower();
            repeatTest = userInput == "да";
            Console.Clear();
        }
    }
    static int CalculateErrors(string originalText, string typedText)
    {
        int errorCount = 0;

        for (int i = 0; i < Math.Min(originalText.Length, typedText.Length); i++)
        {
            if (originalText[i] != typedText[i])
            {
                errorCount++;
            }
        }
        errorCount += Math.Abs(originalText.Length - typedText.Length);
        return errorCount;
    }
    static int CalculateSpeed(int characterCount, double timeInMinutes)
    {
        return (int)(characterCount / timeInMinutes);
    }
    static void SaveToLeaderboard(int speed)
    {
        Console.Write("Введите имя: ");
        string userName = Console.ReadLine();
        LeaderboardEntry newResult = new LeaderboardEntry
        {
            Nickname = userName,
            Speed = speed
        };
        Leaderboard.Add(newResult);
    }
    static void DisplayLeaderboard()
    {
        Console.WriteLine("\nТаблица лидеров:");
        Leaderboard.Sort((a, b) => b.Speed.CompareTo(a.Speed));
        foreach (var result in Leaderboard)
        {
            Console.WriteLine($"{result.Nickname}: {result.Speed} слов в минуту");
        }
    }
}