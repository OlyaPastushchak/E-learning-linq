using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace E_learning_linq
{
    class Program
    {
        static List<string> ReadListFromFile(string filePath)
        {
            FileStream fileData = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(fileData);
            var list = reader.ReadToEnd().Split(' ').ToList();
            reader.Close();

            return list;
        }

        static void WriteListInFile(string filePath, IEnumerable<string> list)
        {
            FileStream fileAnswer = new FileStream(filePath, FileMode.Create);
            StreamWriter writer = new StreamWriter(fileAnswer);
            foreach (var item in list)
            {
                writer.Write($"{item} ");
            }
            writer.Close();
        }

        #region tasks16-20
        //Задана цілочисельна послідовність.
        //Витягнути в іншу послідовність всі додатні числа, зберігаючи початковий порядок елементів.
        static void Task16()
        {
            List<string> numbers = ReadListFromFile("data.txt");

            IEnumerable<string> positiveNumbers = numbers.Where(number => Int32.Parse(number) > 0);

            WriteListInFile("answer.txt", positiveNumbers);
        }

        //Задана цілочисельна послідовність. 
        //Витягнути в іншу послідовність всі непарні числа, зберігаючи початковий порядок елементів і
        //видаливши всі входження (крім першого) елементів, які повторюються. 
        static void Task17()
        {
            List<string> numbers = ReadListFromFile("data17.txt");

            IEnumerable<string> oddNumbersWithoutDuplicates = numbers.Where(number => (Int32.Parse(number) % 2 == 1 || Int32.Parse(number) % 2 == -1)).Distinct();

            WriteListInFile("answer17.txt", oddNumbersWithoutDuplicates);
        }

        //Задана цілочисельна послідовність. 
        //Витягнути в іншу послідовність всі додатні двоцифрові числа, відсортувавши їх за зростанням. 
        static void Task18()
        {
            List<string> numbers = ReadListFromFile("data18.txt");

            IEnumerable<string> posSortedNumbers = numbers.OrderBy(number => Int32.Parse(number)).Where(number => ((number.StartsWith("-") == false) && (number.Length == 2)));

            WriteListInFile("answer18.txt", posSortedNumbers);
        }

        //Задана послідовність слів. Слова містять тільки букви латинського алфавіта. 
        //Відсортувати послідовність за зростанням довжин слів, 
        //а слова одинакової довжини — в лексикографічному порядку за спаданням.  
        static void Task19()
        {
            List<string> words = ReadListFromFile("data19.txt");

            IEnumerable<string> sorted = words.OrderBy(word => word.Length).ThenByDescending(word => word);

            WriteListInFile("answer19.txt", sorted);
        }

        //Задано ціле число D і цілочисельну послідовність A.
        //Починаючи з першого елемента A, більшого за D,
        //витягнути з A в нову послідовність всі непарні додатні числа, змінивши порядок чисел на протилежний.
        static void Task20()
        {
            FileStream fileData = new FileStream("data20.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fileData);
            int d = Int32.Parse(reader.ReadLine());
            List<string> numbers = reader.ReadToEnd().Split(' ').ToList();
            reader.Close();

            IEnumerable<string> newNumbers = numbers.SkipWhile(number => Int32.Parse(number) <= d).Reverse().Where(number => Int32.Parse(number) % 2 == 1);

            FileStream fileAnswer = new FileStream("answer20.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(fileAnswer);
            foreach (var number in newNumbers)
            {
                writer.Write($"{number} ");
            }
            writer.Close();
        }

        #endregion

        #region tasks44-45
        //Дані цілі числа K1 і K2 і цілочислові послідовності A і B.
        //Отримати послідовність, яка містить всі числа з A, більші ніж K1, і всі числа з B, менші ніж K2.
        //Відсортувати отриману послідовність за зростанням.  
        static void Task44()
        {
            FileStream fileData = new FileStream("data44.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fileData);
            int k1 = Int32.Parse(reader.ReadLine());
            int k2 = Int32.Parse(reader.ReadLine());
            List<string> a = reader.ReadLine().Split(' ').ToList();
            List<string> b = reader.ReadLine().Split(' ').ToList();
            reader.Close();

            IEnumerable<string> fromA = a.Where(n => Int32.Parse(n) > k1);
            IEnumerable<string> fromB = b.Where(n => Int32.Parse(n) < k2);

            IEnumerable<string> fromAB = fromA.Concat(fromB).OrderBy(n => Int32.Parse(n));

            FileStream fileAnswer = new FileStream("answer44.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(fileAnswer);
            foreach (var number in fromAB)
            {
                writer.Write($"{number} ");
            }
            writer.Close();
        }

        //Дані цілі додатні числа L1 і L2 і послідовності слів A і B.
        //Слова містять тільки цифри і букви латинського алфавіту.
        //Отримати послідовність, яка містить всі слова з A довжини L1 і всі слова з B довжини L2.
        //Відсортувати отриману послідовність в лексикографічному порядку за спаданням.
        static void Task45()
        {
            FileStream fileData = new FileStream("data45.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fileData);
            int l1 = Int32.Parse(reader.ReadLine());
            int l2 = Int32.Parse(reader.ReadLine());
            List<string> a = reader.ReadLine().Split(' ').ToList();
            List<string> b = reader.ReadLine().Split(' ').ToList();
            reader.Close();

            IEnumerable<string> fromA = a.Where(x => x.Length == l1);
            IEnumerable<string> fromB = b.Where(x => x.Length == l2);

            IEnumerable<string> fromAB = fromA.Concat(fromB).OrderByDescending(n => n);

            FileStream fileAnswer = new FileStream("answer45.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(fileAnswer);
            foreach (var number in fromAB)
            {
                writer.Write($"{number} ");
            }
            writer.Close();
        }

        #endregion

        #region taskClass
        class Client
        {
            public int Code { get; set; }
            public int Year { get; set; }
            public int Mounth { get; set; }
            public int Duration { get; set; }


            public void ReadInfoFromFile(StreamReader reader)
            {
                var list = reader.ReadLine().Split(' ').ToList().Select(Int32.Parse).ToList();
                this.Code = list[0];
                this.Year = list[1];
                this.Mounth = list[2];
                this.Duration = list[3];
            }

        }

        //Знайти елемент послідовності з найшеною  та найбільшою тривалістю занять
        static Client FindLongestDuration(List<Client> clients)
        {
            int maxDuration = clients.Max(x => x.Duration);
            Client clientLongestDur = clients.First(x => x.Duration == maxDuration);

            return clientLongestDur;
        }
        static Client FindShortestDuration(List<Client> clients)
        {
            int minDuration = clients.Min(x => x.Duration);
            Client clientShortestDur = clients.First(x => x.Duration == minDuration);

            return clientShortestDur;
        }

        //Визначити рік, в якому сумарна тривалість занять всіх клієнтів була найбільшою
        //Якщо таких років було декілька, то вивести найменший з них
        static int FindYearWithMaxDuration(List<Client> clients)
        {
            IEnumerable<IGrouping<int, Client>> groupedByYears = clients.GroupBy(x => x.Year);
            IEnumerable<IGrouping<int, Client>> sorted = groupedByYears.OrderByDescending(group => group.Sum(client => client.Duration)).ThenBy(x => x.Min(y => y.Year));

            return sorted.First().Key;
        }

        //Для кажного клієнта визначити сумарну тривалість занятій протігом всіх років.
        //Дані про клієнтів виводити, впорядкувавши їх за спаданням сумарної тривалості 
        static SortedDictionary<int, int> SumDurationForAllYears(List<Client> clients)
        {
            IEnumerable<IGrouping<int, Client>> groupedByCode = clients.GroupBy(x => x.Code);
            SortedDictionary<int, int> durations = new SortedDictionary<int, int>();
            foreach (IGrouping<int, Client> group in groupedByCode)
            {
                int sum = group.Sum(x => x.Duration);
                durations.Add(sum, group.Key);
            }

            return durations;
        }

        //Для кoжного клієнта  визначити загальну кількість місяців протягом яких він відвідував заняття
        static SortedDictionary<int, int> CountMonthsForEachClient(List<Client> clients)
        {
            IEnumerable<IGrouping<int, Client>> groupedByCode = clients.GroupBy(x => x.Code);
            SortedDictionary<int, int> months = new SortedDictionary<int, int>();
            foreach (IGrouping<int, Client> group in groupedByCode)
            {
                int count = group.Count();
                months.Add(count, group.Key);
            }

            return months;
        }

        static List<Client> ReadClientsFromFile(StreamReader reader, int n)
        {
            List<Client> clients = new List<Client>();
            for (int i = 0; i < n; i++)
            {
                Client client = new Client();
                client.ReadInfoFromFile(reader);
                clients.Add(client);
            }

            return clients;
        }

        static void TaskLinqObject()
        {
            FileStream fileData = new FileStream("dataClass.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fileData);
            int n = Int32.Parse(reader.ReadLine());
            List<Client> clients = ReadClientsFromFile(reader, n);
            reader.Close();

            FileStream fileAnswer = new FileStream("answerClass.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(fileAnswer);

            writer.WriteLine($"Client with min duration: {FindShortestDuration(clients).Code}");
            writer.WriteLine($"Client with max duration: {FindLongestDuration(clients).Code}");
            writer.WriteLine($"Year with the biggest sum of durations: {FindYearWithMaxDuration(clients)}");

            SortedDictionary<int, int> durations = SumDurationForAllYears(clients);
            writer.WriteLine("For each client sum of durations:");
            foreach (var item in durations)
            {
                writer.WriteLine($"code - {item.Value}, duration - {item.Key}");
            }
            SortedDictionary<int, int> months = SumDurationForAllYears(clients);
            writer.WriteLine("For each client count of mounths:");
            foreach (var item in months)
            {
                writer.WriteLine($"code - {item.Value}, count - {item.Key}");
            }

            writer.Close();
        }

        #endregion

        static void Main(string[] args)
        {
            Task16();
            Task17();
            Task18();
            Task19();
            Task20();
            Task44();
            Task45();
            TaskLinqObject();
        }
    }
}
