using System;

namespace Task
{
    class Program
    {
        public static bool InStack<T>(Stack<T> s, T value) // 1.A
        {
            Stack<T> temp = new Stack<T>();
            bool output = false;
            while (!s.IsEmpty())
            {
                temp.Push(s.Pop());
                if (temp.Top().Equals(value)) { output = true; break; }
            }
            while (!temp.IsEmpty()) { s.Push(temp.Pop()); }
            return output;
        }
        public static bool IsSimilar<T>(Stack<T> s1, Stack<T> s2) // 1.B
        {
            Stack<T> temp1, temp2;
            temp1 = new Stack<T>();
            temp2 = new Stack<T>();
            int length1, length2;
            length1 = length2 = 0;
            while (!s1.IsEmpty()) { ++length1; temp1.Push(s1.Pop()); }
            while (!s2.IsEmpty()) { ++length2; temp2.Push(s2.Pop()); }
            if (length1 != length2)
            {
                while (!temp1.IsEmpty()) { s1.Push(temp1.Pop()); }
                while (!temp2.IsEmpty()) { s2.Push(temp2.Pop()); }
                return false;
            }
            while (!temp1.IsEmpty())
            {
                if (!InStack(temp2, temp1.Top()))
                {
                    while (!temp1.IsEmpty()) { s1.Push(temp1.Pop()); }
                    while (!temp2.IsEmpty()) { s2.Push(temp2.Pop()); }
                    return false;
                }
                s1.Push(temp1.Pop());
            }
            while (!temp2.IsEmpty()) { s2.Push(temp2.Pop()); }
            return true;
        }
        public static Stack<int> BuildIntStack() // 1.C
        {
            Stack<int> output = new Stack<int>();
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input == -999) { return output; }
                output.Push(input);
            }
        }
        public static Couple MaxForCouple(Couple c1, Couple c2) // Max function that return the max couple
        {
            Couple output = (c1.GetNum() == Math.Max(c1.GetNum(), c2.GetNum())) ? c1 : c2;
            return output;
        }
        public static Couple MinForCouple(Couple c1, Couple c2) // Min function that return the min couple
        {
            Couple output = (c1.GetNum() == Math.Min(c1.GetNum(), c2.GetNum())) ? c1 : c2;
            return output;
        }
        public static Stack<int> BuildStackFromCouple(Stack<Couple> stack) // 2.A
        {
            Stack<int> output = new Stack<int>();
            if (stack == null) { return output; }
            Stack<Couple> newStack = new Stack<Couple>();
            Couple max, min, temp;
            max = stack.Pop();
            while (!stack.IsEmpty())
            {
                temp = stack.Pop();
                min = MinForCouple(max, temp);
                max = MaxForCouple(max, temp);
                newStack.Push(min);
            }
            newStack.Push(max);
            while (!newStack.IsEmpty())
            {
                int num, appears;
                Couple c = newStack.Pop();
                num = c.GetNum();
                appears = c.GetAppears();
                for (int i = 0; i < appears; i++)
                {
                    output.Push(num);
                }
            }
            return output;
        }
        public static Stack<Couple> BuildCoupleStack() // 2.B
        {
            Stack<Couple> output = new Stack<Couple>();
            while (true)
            {
                Console.Write("Enter num: ");
                int num = int.Parse(Console.ReadLine());
                if (num == -999) { return output; }
                Console.Write("Enter appears: ");
                int appears = int.Parse(Console.ReadLine());
                output.Push(new Couple(num, appears));
            }
        }
        public static bool HidingInStack(Stack<int> stack, int num) // 3.A
        {
            string strNum = num.ToString();
            int[] digitsArr = new int[strNum.Length];
            for (int i = 0; i < digitsArr.Length; i++) { digitsArr[i] = (strNum[i] - '0'); }
            Stack<int> temp = new Stack<int>();
            while (!stack.IsEmpty())
            {
                int number = stack.Pop();
                temp.Push(number);
                if (number == digitsArr[0])
                {
                    bool vaild = true;
                    for (int i = 1; i < digitsArr.Length; i++)
                    {
                        number = stack.Pop();
                        if (number != digitsArr[i]) { vaild = false; }
                        temp.Push(number);
                    }
                    if (vaild)
                    {
                        while (!temp.IsEmpty()) { stack.Push(temp.Pop()); }
                        return true;
                    }
                }
                else if (number == digitsArr[digitsArr.Length - 1])
                {
                    bool vaild = true;
                    for (int i = digitsArr.Length - 2; i >= 0; i--)
                    {
                        number = stack.Pop();
                        if (number != digitsArr[i]) { vaild = false; }
                        temp.Push(number);
                    }
                    if (vaild)
                    {
                        while (!temp.IsEmpty()) { stack.Push(temp.Pop()); }
                        return true;
                    }
                }
            }
            while (!temp.IsEmpty()) { stack.Push(temp.Pop()); }
            return false;
        }
        static void Main(string[] args)
        {
            // // 1.D
            Stack<int> stack1, stack2, stack4;
            Console.WriteLine("Enter numbers to push into the first stack:");
            stack1 = BuildIntStack();
            Console.WriteLine("Enter numbers to push into the second stack:");
            stack2 = BuildIntStack();
            Console.WriteLine($"Stack 1: {stack1}\tStack 2: {stack2}");
            string answer = IsSimilar(stack1, stack2) ? "The stacks are similar." : "The stacks are not similar.";
            Console.WriteLine(answer);
            Console.WriteLine("After the function:");
            Console.WriteLine($"Stack 1: {stack1}\tStack 2: {stack2}\n\n");

            // 2.C
            Console.WriteLine("Enter couples (Do not enter null): ");
            Stack<Couple> stack3 = BuildCoupleStack();
            Console.WriteLine($"Couple stack - {stack3}");
            Console.WriteLine($"New stack: {BuildStackFromCouple(stack3)}");

            //3.B
            Console.WriteLine("Enter numbers to push into the stack:");
            stack4 = BuildIntStack();
            Console.WriteLine($"Stack - {stack4}");
            Console.Write("Enter a number to check: ");
            Console.WriteLine(HidingInStack(stack4, int.Parse(Console.ReadLine())));
            Console.WriteLine($"Stack after function - {stack4}");
        }
    }
}
