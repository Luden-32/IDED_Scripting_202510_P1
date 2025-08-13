using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        internal static uint StackFirstPrime(Stack<uint> stack)
        {
            Stack<uint> aux = new Stack<uint> ();
            uint found = 0;

            while (stack.Count > 0)
            {
                uint v = stack.Pop();
                aux.Push(v);
                if (found == 0 && IsPrime(v))
                {
                    found = v;
                }
            }
            
            while (aux.Count > 0)
            {
                stack.Push(aux.Pop());
            }
            return found;
        }

        internal static Stack<uint> RemoveFirstPrime(Stack<uint> stack)
        {
            List<uint> temp = new List<uint>();
            bool removed = false;

            while (stack.Count > 0)
            {
                uint v = stack.Pop();
                if (!removed && IsPrime(v))
                {
                    removed = true; 
                    continue;
                }
                temp.Add(v); 
            }

        
            Stack<uint> result = new Stack<uint>();
            for (int i = temp.Count - 1; i >= 0; i--)
                result.Push(temp[i]);

            return result;
        }

        internal static Queue<uint> CreateQueueFromStack(Stack<uint> stack)
        {
            List<uint> temp = new List<uint>();

            while (stack.Count > 0)
                temp.Add(stack.Pop());

            Queue<uint> q = new Queue<uint>();
            for (int i = 0; i < temp.Count; i++)
                q.Enqueue(temp[i]);

            for (int i = temp.Count - 1; i >= 0; i--)
                stack.Push(temp[i]);

            return q;
        }

        internal static List<uint> StackToList(Stack<uint> stack)
        {
            List<uint> temp = new List<uint>();

            while (stack.Count > 0)
                temp.Add(stack.Pop());

            for (int i = temp.Count - 1; i >= 0; i--)
                stack.Push(temp[i]);

            List<uint> output = new List<uint>();
            for (int i = 0; i < temp.Count; i++)
                output.Add(temp[i]);

            return output;
        }

        internal static bool FoundElementAfterSorted(List<int> list, int value)
        {
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }
                if (minIndex != i)
                {
                    int tmp = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = tmp;
                }
            }

            int left = 0, right = n - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (list[mid] == value) return true;
                if (list[mid] < value) left = mid + 1;
                else right = mid - 1;
            }

            return false;
        }

        private static bool IsPrime(uint num)
        {
            if (num < 2) return false;
            for (uint i = 2; i * i <= num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }
}