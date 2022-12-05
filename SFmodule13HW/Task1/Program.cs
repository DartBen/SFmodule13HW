using System.Diagnostics;
using static System.Console;
internal class Program
{
    private static void Main(string[] args)
    {

        try
        {
            //подготовка без учёта времени
            string path = "C:\\Users\\Dima\\Google Диск\\Repos\\SF Module 13 HW\\SFmodule13HW\\Task1\\Text1.txt";
            string[] spliters = { " ", "\r", "\n" };
            List<string> ListWords = new List<string>();
            LinkedList<string> LinkedListWords = new LinkedList<string>();

            string text = File.ReadAllText(path);
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            var stringArrBuff = noPunctuationText.Split(spliters, StringSplitOptions.RemoveEmptyEntries);

            Stopwatch stopwatchList = new Stopwatch();
            Stopwatch stopwatchLinkedList = new Stopwatch();

            //проверка времени перекладки из string[] в List<string>
            stopwatchList.Start();
            ListWords = ArrStringShiftToList(stringArrBuff);
            stopwatchList.Stop();
            Console.WriteLine($"Вставка в  List: {stopwatchList.Elapsed.TotalMilliseconds}  мс");

            //проверка времени перекладки из string[] в LinkedList<string>
            stopwatchLinkedList.Start();
            LinkedListWords=ArrStringShiftToLinkedList(stringArrBuff);
            stopwatchLinkedList.Stop();
            Console.WriteLine($"Вставка в  LinkedList: {stopwatchLinkedList.Elapsed.TotalMilliseconds}  мс");
        }
        catch (Exception exception)
        {
            WriteLine(exception.Message);
        }
    }


    private static List<string> ArrStringShiftToList(string[] strings)
    {
        List<string> ListWords = new List<string>();
        foreach (string s in strings)
        {
            ListWords.Add(s);
        }
        return ListWords;
    }

    private static LinkedList<string> ArrStringShiftToLinkedList(string[] strings)
    {
        LinkedList<string> LinkedListWords = new LinkedList<string>();
        foreach (string s in strings)
        {
            LinkedListWords.AddLast(s);
        }
        return LinkedListWords;
    }


}