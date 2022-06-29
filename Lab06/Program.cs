using System;
using static System.Console;
namespace ConsoleApplication1
{
    class CircularQueue
    {
        private int[] queue;
        private int head;
        private int tail;
        private int max;
        private int count;

        public CircularQueue(int size)
        {
            queue = new int[size];
            head = 0;
            tail = -1;
            max = size;
            count = 0;
        }

        public void push(int item)
        {
            if (count == max)
            {
                WriteLine("Queue Overflow");
                Array.Resize<int>(ref queue, max + 10);
                max += 10;
                
            }
            tail = (tail + 1) % max;
            queue[tail] = item;
            count++;
            printQueue();
        }

        public void pop()
        {
            if (count == 0)
            {
                WriteLine("Queue is Empty");
            }
            else
            {
                head = (head + 1) % max;
                count--;
                printQueue();
            }
        }

        public void printQueue()
        {
            int i = 0;
            int j = 0;

            if (count == 0)
            {
                WriteLine("Queue is Empty");
            }
            else
            {
                Write("Queue: ");
                for (i = head; j < count; j++)
                {
                    Write(queue[i] + ", ");
                    i = (i + 1) % max;

                }
                WriteLine();
            }
        }
        public bool isEmpty()
		{
            return count == 0;
		}
        
    }

    class Program
    {
        static void Main()
        {
            CircularQueue queue = new CircularQueue(10);
            queue.printQueue();
            do
            {
                Write("1. push\n2. pop\n3. exit\nChoice: ");
                string choice = ReadLine();
                if (choice == "1")
				{
                    Write("Item: ");
                    int item = Convert.ToInt32(ReadLine());
                    if (item < 0)
					{
                        WriteLine("Error");
					}
                    else if (item == 0)
					{
                        queue.pop();
                        queue.pop();
                        queue.pop();
					}
                    else
					{
                        queue.push(item);
					}
                }
                else if (choice == "2")
				{
                    queue.pop();
				}
                else if (choice == "3")
				{
                    return;
				}
            }
            while (!queue.isEmpty());
        }
    }
}