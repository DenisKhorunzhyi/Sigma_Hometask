using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string toString(IAnimals item) 
            { return "Name: " + item.Name + "\t Age:" + item.Age;
            };
            
            Cats cat1 = new Cats() { Age = "2", Name = "Victor" };
            Cats cat2 = new Cats() { Age = "3", Name = "Busya" };
            Dogs dog1 = new Dogs() { Age = "2", Name = "Sharic" };
            Dogs dog2 = new Dogs() { Age = "2", Name = "Teddy" };
            var ItemToRemove = dog2;
            var MyList = new MyNewList<IAnimals>();
            MyList.Add(cat1);
            MyList.Add(cat2);
            MyList.Add(dog1);
            MyList.Add(dog2);
            
            Console.WriteLine("Your pats:");
            print(MyList);
            Console.WriteLine("Remove:\n{0}", toString(ItemToRemove) + Environment.NewLine) ;
            MyList.Remove(ItemToRemove);
            print(MyList);
        }
         private static void print(MyNewList<IAnimals> MyList)
        {
            foreach (IAnimals item in MyList)
            {
                Console.WriteLine("Name: {0}\t Age:{1}", item.Name, item.Age);
            }
        }

    }
    internal class MyNewList<T> : IEnumerable<T>  // односвязный список
    {
        Node<T> head; 
        Node<T> tail; 
        int count; 

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }
        // удаление элемента
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                   
                    if (previous != null)
                    {
                       
                        previous.Next = current.Next;

                        
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

       
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        
        // добaвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        
    }
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
}

