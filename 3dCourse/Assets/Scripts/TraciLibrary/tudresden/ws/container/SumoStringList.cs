using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Container
{
    public class SumoStringList
    {
        private readonly LinkedList<String> list;
        public SumoStringList()
        {
            list = new LinkedList<String>();
        }

        public SumoStringList(LinkedList<String> list)
        {
            this.list = list;
        }

        public  void Add(int index, string element)
        {
            LinkedList<string>.Enumerator e=list.GetEnumerator();
            for(int i = 0; i < index; i++)
            {
                e.MoveNext();
            }
            list.AddBefore(new LinkedListNode<string>(e.Current), element);
            //list.Add(index, element);
        }

        public void AddAll(LinkedList<String> elements)
        {
            foreach (string e in elements)
            {
                list.AddLast(e);
            }
            //return list.AddAll(elements);
        }

        public  void AddAll(int index, LinkedList<String> elements)
        {
            LinkedList<string>.Enumerator e = list.GetEnumerator();
            for (int i = 0; i < index; i++)
            {
                e.MoveNext();
            }            
            foreach (string el in elements)
            {
                list.AddBefore(new LinkedListNode<string>(e.Current), el);
            }

            //list.AddAll(index, elements);
        }

        public  void Clear()
        {
            list.Clear();
        }

        public  bool Contains(string element)
        {
            return list.Contains(element);
        }

        public  bool ContainsAll(LinkedList<String> elements)
        {
            foreach(string e in elements)
            {
                if (!list.Contains(e))
                {
                    return false;
                }
            }
            return true;
            //return list.ContainsAll(elements);
        }

        public  string Get(int index)
        {
            return list.ElementAt(index);
        }

        public  int IndexOf(Object element)
        {
            LinkedList<string>.Enumerator e = list.GetEnumerator();
            for (int i = 0; i < list.Count; i++)
            {
                if (element.Equals(list.ElementAt(i)))
                {
                    return i;
                }
                e.MoveNext();
            }
            return -1;
            //return list.IndexOf(element);
        }

        public  bool IsEmpty()
        {
            return list.Count == 0 ? true:false ;
        }

        public  int LastIndexOf(Object element)
        {
            int lastIndex = -1;
            LinkedList<string>.Enumerator e = list.GetEnumerator();
            for (int i = 0; i < list.Count; i++)
            {
                if (element.Equals(list.ElementAt(i)))
                {
                    lastIndex= i;
                }
                e.MoveNext();
            }
            return lastIndex;

            //return list.LastIndexOf(element);
        }

        public  LinkedList<String>.Enumerator ListIterator()
        {
            return list.GetEnumerator();
        }

        public LinkedList<String>.Enumerator ListIterator(int index)
        {
            LinkedList<string>.Enumerator e = list.GetEnumerator();
            for (int i = 0; i < index; i++)
            {
               e.MoveNext();
            }

            return e;
        }

        public  void Remove(string element)
        {
            list.Remove(element);
        }

        public  string Remove(int index)
        {
            LinkedList<string>.Enumerator e = list.GetEnumerator();
            for (int i = 0; i < index; i++)
            {
                e.MoveNext();
            }
            list.Remove(e.Current);

            return e.Current;
        }

        public void RemoveAll(LinkedList<String> elements)
        {
            foreach(string e in elements)
            {
                list.Remove(e);
            }
            // return list.RemoveAll(elements);
        }

        public  void RetainAll(LinkedList<String> elements)
        {
            foreach(string e in list)
            {
                if (!elements.Contains(e))
                {
                    list.Remove(e);
                }
            }
            //return list.RetainAll(elements);
        }

        public  void Set(int index, string element)
        {
            LinkedList<string>.Enumerator e = list.GetEnumerator();
            for (int i = 0; i < index; i++)
            {
                e.MoveNext();
            }

            list.Find(e.Current).Value = element;

            //return list.Set(index, element);
        }

        public  int Size()
        {
            return list.Count();
        }

        public  List<String> SubList(int from, int to)
        {
            return list.ToList().GetRange(from, to);
        }

        public  Object[] ToArray()
        {
            return list.ToArray();
        }

       
        public  void Add(string element)
        {
            list.AddLast(element);
        }

        public  LinkedList<string>.Enumerator Iterator()
        {
            return list.GetEnumerator();
        }

        public LinkedList<string> getList()
        {
            return this.list;
        }
    }
}