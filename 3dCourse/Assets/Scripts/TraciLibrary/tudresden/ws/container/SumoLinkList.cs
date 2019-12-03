using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using traciConnector.tudresden.ws.container;

namespace TraciConnector.Tudresden.Ws.Container
{
    public class SumoLinkList : List<SumoLink>
    {
        private readonly LinkedList<SumoLink> list;
        public SumoLinkList()
        {
            list = new LinkedList<SumoLink>();
        }

        public SumoLinkList(LinkedList<SumoLink> list)
        {
            this.list = list;
        }

        public virtual void Add(int index, SumoLink element)
        {
            list.AddBefore(new LinkedListNode<SumoLink>(list.ElementAt(index)), element);
            //list.Add(index, element);
        }

        public virtual void AddAll(LinkedList<SumoLink> elements)
        {
            foreach(SumoLink s in elements)
            {
                list.AddLast(s);
            }
            //return list.AddAll(elements);
        }

        public virtual void AddAll(int index, LinkedList<SumoLink> elements)
        {
            int i = index;
            foreach (SumoLink s in elements)
            {
                list.AddBefore(new LinkedListNode<SumoLink>(list.ElementAt(i++)), s);
            }
            //return list.AddAll(index, elements);
        }

        public new void Clear()
        {
            list.Clear();
        }

        public virtual bool Contains(Object element)
        {
            return list.Contains((SumoLink) element);
        }

        public virtual bool ContainsAll(LinkedList<SumoLink> elements)
        {
            foreach(SumoLink s in elements)
            {
                if (!list.Contains(s))
                {
                    return false;
                }
            }
            return true;
            //return list.ContainsAll(elements);
        }

        public virtual SumoLink Get(int index)
        {
            return list.ElementAt(index);
            //return list.Get(index);
        }

        public virtual int IndexOf(Object element)
        {
            var count = 0;
            for (var node = list.First; node != null; node = node.Next, count++)
            {
                if (element.Equals(node.Value))
                    return count;
            }
            return -1;
        }

        public virtual bool IsEmpty()
        {
            return list.Count == 0 ? true:false;
//            return list.IsEmpty();
        }

        public virtual int LastIndexOf(Object element)
        {
            var count = 0;
            var lastPos = 0;
            for (var node = list.First; node != null; node = node.Next, count++)
            {
                if (element.Equals(node.Value))
                    lastPos = count;
            }
            return lastPos;

            //return list.LastIndexOf(element);
        }

        public virtual LinkedList<SumoLink>.Enumerator ListIterator()
        {
            return list.GetEnumerator();
            //return list.ListIterator();
        }

        public virtual LinkedList<SumoLink>.Enumerator ListEnumerator(int index)
        {
            LinkedList<SumoLink>.Enumerator e = list.GetEnumerator();
            for(int i = 0; i < index; i++)
            {
                e.MoveNext();
            }
            return list.GetEnumerator();
            //return list.ListIterator(index);
        }

        public virtual void Remove(Object element)
        {
            list.Remove((SumoLink)element);
            //return list.Remove(element);
        }

        public virtual SumoLink Remove(int index)
        {
            SumoLink s = list.ElementAt(index);
            list.Remove(s);
            return s;
            // return list.Remove(index);
        }

        public virtual void RemoveAll(List<SumoLink> elements)
        {
            foreach(SumoLink s in elements)
            {
                list.Remove(s);
            }

            //return list.RemoveAll(elements);
        }

        public virtual void RetainAll(List<SumoLink> elements)
        {
            foreach (SumoLink s in list)
            {
                if (!elements.Contains(s))
                {
                    list.Remove(s);
                }                    
            }
            //return list.RetainAll(elements);
        }

        public virtual SumoLink Set(int index, SumoLink element)
        {
            SumoLink s = list.ElementAt(index);
            list.Find(s).Value=element;
            return s;
            //return list.Set(index, element);
        }

        public virtual int Size()
        {
            return list.Count();
        }

        public virtual List<SumoLink> SubList(int from, int to)
        {
            return list.ToList().GetRange(from, to);
            //return list.SubList(from, to);
        }

        public new Object[] ToArray()
        {
            return list.ToArray();
        }

        

        public new void Add(SumoLink element)
        {
            list.AddLast(element);
        }

        public virtual LinkedList<SumoLink>.Enumerator Iterator()
        {
            return list.GetEnumerator();
        }

        public new string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (SumoLink sl in this.list)
            {
                sb.Append(sl.ToString() + "#");
            }

            return sb.ToString();
        }
    }
}