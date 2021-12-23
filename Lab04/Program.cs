using System;
using static System.Console;
namespace Lab04
{
    class SLNode
    {
        public int data;
        public SLNode next { get; set; }
        public SLNode(int data)
        {
            this.data = data;
        }
    }
    class List
    {
        public SLNode tail;
        public List()
        {
            this.tail = null;
        }
        public bool AddLast(int data)
        {
            if (tail == null)
            {
                tail = new SLNode(data);
                tail.next = tail;
            }
            else
            {
                SLNode newNode = new SLNode(data);
                newNode.next = tail.next;
                tail.next = newNode;
                tail = newNode;
            }
            return true;
        }
        public bool AddFirst(int data)
        {
            if (tail == null)
            {
                tail = new SLNode(data);
                tail.next = tail;
            }
            else
            {
                SLNode newNode = new SLNode(data);
                newNode.next = tail.next;
                tail.next = newNode;
            }
            return true;
        }
        public bool AddAtPosition(int data, int pos) // position 0 ... Count
        {
            int Count = GetCount();
            if (tail == null || pos <= 0 || pos > Count) 
            // if list is empty or pos = first element or position of element is out of list
            {
                return AddFirst(data);
            }
            else if (pos == Count) // last element
			{
                return AddLast(data);
			}
            else // somewhere in middle
            {
                SLNode current = tail;
                for (int i = 0; i < pos; i++)
                {
                    current = current.next;
                }
                SLNode newNode = new SLNode(data);
                newNode.next = current.next;
                current.next = newNode;
                
            }
            return true;
        }
        public bool DeleteFirst()
        {
            if (tail == null)
            {
                WriteLine("List is empty");
                return false;
            }
            else if(tail.next == tail)
			{
                tail = null;
			}
            else
            {
                tail.next = tail.next.next;
            }
            return true;
        }
        public bool DeleteLast()
        {
            if (tail == null)
            {
                WriteLine("List is empty");
                return false;
            }
            else if (tail.next == tail)
            {
                tail = null;
            }
            else
            {
                SLNode current = tail.next;
                while (current.next != tail)
                {
                    current = current.next;
                }
                current.next = tail.next;
                tail = current;
                
            }
            return true;
        }
        public bool DeleteAtPosition(int pos) // position 0 ... Count - 1
        {
            int Count = GetCount();
            if (tail == null || pos >= Count || pos < 0)
                return false;
            else if (tail.next == tail)
            {
                tail = null;
            }
            else if (pos == 0)
			{
                return DeleteFirst();
			}
            else if (pos == Count - 1)
			{
                return DeleteLast();
			}
            else
            {
                SLNode current = tail;
                for (int i = 0; i < pos; i++)
                {
                    if (current.next == tail && i != pos - 1)
                    {
                        return false;
                    }
                    current = current.next;
                }
                current.next = current.next.next;
            }
            return true;
        }
        public bool AddBeforeMid(int data)
        {
            // Коментар:
            // Count - кількість вузлів в списку
            // першим вузлом другої половини я вважаю вузол на позиції:
            // Count/2 при Count парному або
            // Count/2 + 1 при Count непарному
            // тобто, якщо в мене непарна кількість вузлів, то друга "половина" списку буде на 1 вузол менша за першу
            int Count = GetCount();
            int pos = Count / 2;
            if (Count % 2 == 1)
			{
                pos ++;
			}
            return AddAtPosition(data, pos);
        }
        public void GenerateList(int num)
        {
            Random rand = new Random();
            tail = null;
            for (int i = 0; i < num; i++)
            {
                AddFirst(rand.Next(-99, 100));
            }
        }
        public void Print()
        {
            if(tail == null)
			{
                WriteLine("List is empty");
                return;
			}
            SLNode current = tail.next;
			while (current != tail)
			{
				Write(current.data + ", ");
				current = current.next;
			}
            WriteLine(tail.data);
		}
        public int GetCount()
		{
            if(tail == null)
                return 0;
            int count = 1;
            SLNode current = tail.next;
            while (current != tail)
            {
                count++;
                current = current.next;
            }
            return count;
        }

	}
    class Program
    {
        static void Main(string[] args)
        { 
            List list = new List();
            while (true)
			{
                WriteLine("Help:\n1.  AddLast\n2.  AddFirst\n3.  AddAtPosition\n4.  DeleteFirst\n5.  DeleteLast\n6.  DeleteAtPosition\n7.  AddBeforeMid - add node before first from second half\n8.  GenerateList - generate list of N nodes with random data\n9.  Print\n10. Exit");
                int request = 9;
                Write("Command number: ");
                try
                {
                    request = Int32.Parse(ReadLine());

                }
                catch
                {
                    WriteLine("Error");
                    break;
				}

                int data = 0, pos = 0;
                if (request == 1)
				{
                    try { Write("Data: "); data = Int32.Parse(ReadLine()); }
                    catch
                    {
                        WriteLine("Error");
                        break;
                    }
                    list.AddLast(data);
                }
                else if(request == 2)
				{
                    try { Write("Data: "); data = Int32.Parse(ReadLine()); }
                    catch
                    {
                        WriteLine("Error");
                        break;
                    }
                    list.AddFirst(data);
                    
                }
                else if (request == 3)
                {
                    try { Write("Data: "); data = Int32.Parse(ReadLine()); Write("Position: "); pos = Int32.Parse(ReadLine()); }
                    catch
                    {
                        WriteLine("Error");
                        break;
                    }
                    list.AddAtPosition(data, pos);
                }
                else if (request == 4)
                {
                    list.DeleteFirst();
                }
                else if (request == 5)
                {
                    list.DeleteLast();
                }
                else if (request == 6)
                {
                    try { Write("Position: "); pos = Int32.Parse(ReadLine()); }
                    catch
                    {
                        WriteLine("Error");
                        break;
                    }
                    list.DeleteAtPosition(pos);
                }
                else if (request == 7)
                {
                    try { Write("Data: "); data = Int32.Parse(ReadLine()); }
                    catch
                    {
                        WriteLine("Error");
                        break;
                    }
                    list.AddBeforeMid(data);
                }
                else if (request == 8)
                {
                    try { Write("Number of nodes: "); data = Int32.Parse(ReadLine()); }
                    catch
                    {
                        WriteLine("Error");
                        break;
                    }
                    list.GenerateList(data);
                }
                else if (request == 9)
                {
                    list.Print();
                }
                else if (request == 10)
				{
                    break;
				}
                Clear();
                WriteLine("List:");
                list.Print();


            }

		}
    }
}
