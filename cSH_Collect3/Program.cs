using System;
using System.Collections.Generic;

class Program
{
    //1
    static T[] Swap<T>(T first, T second)
    {
        return new T[]
        {
            second, first
        };
    }
    //2
    class PriorityQueue<T>
    {
        List<T> items = new List<T>();
        List<int> priorities = new List<int>();

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public void Enqueue(T item, int priority)
        {
            items.Add(item);
            priorities.Add(priority);
        }
        public T Dequeue()
        {
            // элемент с наименьшим номером приоритета
            int bestIndex = 0;
            for (int i = 1; i < priorities.Count; i++)
            {
                if (priorities[i] < priorities[bestIndex])
                {
                    bestIndex = i;
                }
            }
            T item = items[bestIndex];
            items.RemoveAt(bestIndex);
            priorities.RemoveAt(bestIndex);

            return item;
        }
    }
    //3
    class CircularQueue<T>
    {
        T[] items;
        int first = 0;
        int count = 0;

        public CircularQueue(int size)
        {
            items = new T[size];
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Enqueue(T item)
        {
            int last = (first + count) % items.Length;
            items[last] = item;
            count++;
        }

        public T Dequeue()
        {
            T item = items[first];
            first = (first + 1) % items.Length;
            count--;
            return item;
        }
    }

    static void Main()
    {
        //1
        int firstNumber = 5;
        int secondNumber = 10;
        int[] numbers = Swap(firstNumber, secondNumber);
        firstNumber = numbers[0];
        secondNumber = numbers[1];
        Console.WriteLine("Task 1 - Swap:");
        Console.WriteLine(firstNumber);
        Console.WriteLine(secondNumber);
        //2
        PriorityQueue<string> priorityQueue =
            new PriorityQueue<string>();
        priorityQueue.Enqueue("Regular task", 3);
        priorityQueue.Enqueue("Urgent task", 1);
        priorityQueue.Enqueue("Important task", 2);
        Console.WriteLine();
        Console.WriteLine("Task 2 - Priority queue:");
        while (priorityQueue.Count > 0)
        {
            Console.WriteLine(priorityQueue.Dequeue());
        }
        //3
        CircularQueue<string> circularQueue =
            new CircularQueue<string>(3);
        circularQueue.Enqueue("First");
        circularQueue.Enqueue("Second");
        circularQueue.Enqueue("Third");
        Console.WriteLine();
        Console.WriteLine("Task 3 - Circular queue:");
        while (circularQueue.Count > 0)
        {
            Console.WriteLine(circularQueue.Dequeue());
        }
    }
}