using System;
using static System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "C:\\Users\\Dima\\Google Диск\\Repos\\SF Module 13 HW\\SFmodule13HW\\Task2\\Text1.txt";
        string[] spliters = { " ", "\r", "\n" };

        try
        {
            string text = File.ReadAllText(path);
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            var stringArrBuff = noPunctuationText.Split(spliters, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, long> wordsCount = new Dictionary<string, long>();

            foreach (string str in stringArrBuff)
            {
                //если слово существует до добавит в счётчик 1
                if (wordsCount.ContainsKey(str))
                    wordsCount[str]++;
                //если слово не существует до добавит его в словарь
                else if (!wordsCount.ContainsKey(""))
                    wordsCount.Add(str, 1);
            }

            //найдено в сети
            var sortedWordsCount = from entry in wordsCount orderby entry.Value descending select entry;

            WriteLine("Решение из сети");
            for (int i = 0; i < 10; i++)
                WriteLine(sortedWordsCount.ElementAt(i).Key + " : " + sortedWordsCount.ElementAt(i).Value + " раз");

            WriteLine("\nМоё решение");
            Dictionary<string, long> MaxCountedWords = GetMaxCountedWords(wordsCount, 10);

            foreach (var word in MaxCountedWords)
                WriteLine(word.Key + " : " + word.Value + " раз");



        }
        catch (Exception exception)
        {
            WriteLine(exception.Message);
        }
    }

    private static Dictionary<string, long> GetMaxCountedWords(Dictionary<string, long> inputDict, int arrayLenght)
    {
        Dictionary<string, long> maxCountedWords = new Dictionary<string, long>();

        LinkedList<WordCount> countList = new LinkedList<WordCount>();
        int maxFindedValue = 0;
        long count = 0;

        foreach (var word in inputDict)
        {
            if (countList.Count == 0 || word.Value >= countList.First?.Value?.value)
            {
                count++;

                LinkedListAddWord(ref countList, new WordCount(word.Value, word.Key));

                while (countList.Count > arrayLenght)
                {
                    countList.RemoveFirst();
                }
            }
        }

        int tmpLenght = arrayLenght;
        if (countList.Count < arrayLenght)
            tmpLenght = countList.Count;

        for (int i = 0; i < tmpLenght; i++)
        {
            var tmpWord = countList.ElementAt(i);
            maxCountedWords.Add(tmpWord.key, tmpWord.value);
        }
        return maxCountedWords;
    }

    class WordCount
    {
        public long value { get; }
        public string key { get; }

        public WordCount(long Value, string Key)
        {
            value = Value;
            key = Key;
        }
    }

    static void LinkedListAddWord(ref LinkedList<WordCount> inputList, WordCount newWord)
    {
        var count = inputList.Count;


        switch (count)
        {
            case 0:
                inputList.AddFirst(newWord);
                break;

            default:
                long countInList = 0;

                WordCount place = inputList.First.ValueRef;
                for (int i = 1; i < count; i++)
                {
                    if (newWord.value > inputList.ElementAt(i).value)
                    {
                        place = inputList.ElementAt(i);
                        continue;
                    }
                }

                LinkedListNode<WordCount> current = inputList.Find(place);
                inputList.AddAfter(current, newWord);
                break;
        }
    }

}