namespace Assignment2ADV
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Select a problem to solve (1-11):");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CountGreaterThanX();
                    break;
                case 2:
                    CheckPalindromeArray();
                    break;
                case 3:
                    ReverseQueue();
                    break;
                case 4:
                    CheckBalancedParentheses();
                    break;
                case 5:
                    RemoveDuplicates();
                    break;
                case 6:
                    RemoveOddNumbers();
                    break;
                case 7:
                    GenericQueue();
                    break;
                case 8:
                    SearchInStack();
                    break;
                case 9:
                    FindIntersection();
                    break;
                case 10:
                    FindContiguousSubList();
                    break;
                case 11:
                    ReverseFirstKElements();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void CountGreaterThanX()
        {
            int[] arr = { 11, 5, 3 };
            int[] queries = { 1, 5, 13 };
            foreach (int x in queries)
            {
                Console.WriteLine(arr.Count(num => num > x));
            }
        }

        static void CheckPalindromeArray()
        {
            int[] arr = { 1, 3, 2, 3, 1 };
            Console.WriteLine(arr.SequenceEqual(arr.Reverse()) ? "YES" : "NO");
        }

        static void ReverseQueue()
        {
            Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
                stack.Push(queue.Dequeue());
            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());
            Console.WriteLine(string.Join(", ", queue));
        }

        static void CheckBalancedParentheses()
        {
            string input = "[()]{ }";
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> pairs = new Dictionary<char, char> { { ')', '(' }, { ']', '[' }, { '}', '{' } };
            foreach (char ch in input)
            {
                if (pairs.ContainsValue(ch)) stack.Push(ch);
                else if (pairs.ContainsKey(ch) && (stack.Count == 0 || stack.Pop() != pairs[ch]))
                {
                    Console.WriteLine("Not Balanced");
                    return;
                }
            }
            Console.WriteLine(stack.Count == 0 ? "Balanced" : "Not Balanced");
        }

        static void RemoveDuplicates()
        {
            int[] arr = { 1, 2, 2, 3, 4, 4, 5 };
            Console.WriteLine(string.Join(", ", arr.Distinct()));
        }

        static void RemoveOddNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            numbers.RemoveAll(n => n % 2 != 0);
            Console.WriteLine(string.Join(", ", numbers));
        }

        static void GenericQueue()
        {
            Queue<object> queue = new Queue<object>();
            queue.Enqueue(1);
            queue.Enqueue("Apple");
            queue.Enqueue(5.28);
            Console.WriteLine(string.Join(", ", queue));
        }

        static void SearchInStack()
        {
            Stack<int> stack = new Stack<int>(new[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("Enter target:");
            int target = int.Parse(Console.ReadLine());
            int count = 0;
            foreach (int num in stack)
            {
                count++;
                if (num == target)
                {
                    Console.WriteLine($"Target was found successfully and the count = {count}");
                    return;
                }
            }
            Console.WriteLine("Target was not found");
        }

        static void FindIntersection()
        {
            int[] arr1 = { 1, 2, 3, 4, 4 };
            int[] arr2 = { 10, 4, 4 };
            var intersection = arr1.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            List<int> result = new List<int>();
            foreach (var num in arr2)
            {
                if (intersection.ContainsKey(num) && intersection[num] > 0)
                {
                    result.Add(num);
                    intersection[num]--;
                }
            }
            Console.WriteLine("[" + string.Join(", ", result) + "]");
        }

        static void FindContiguousSubList()
        {
            List<int> arr = new List<int> { 1, 2, 3, 7, 5 };
            int target = 12;
            for (int i = 0; i < arr.Count; i++)
            {
                int sum = 0;
                for (int j = i; j < arr.Count; j++)
                {
                    sum += arr[j];
                    if (sum == target)
                    {
                        Console.WriteLine("[" + string.Join(", ", arr.GetRange(i, j - i + 1)) + "]");
                        return;
                    }
                }
            }
        }

        static void ReverseFirstKElements()
        {
            Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            int k = 3;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < k; i++)
                stack.Push(queue.Dequeue());
            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());
            for (int i = 0; i < queue.Count - k; i++)
                queue.Enqueue(queue.Dequeue());
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}