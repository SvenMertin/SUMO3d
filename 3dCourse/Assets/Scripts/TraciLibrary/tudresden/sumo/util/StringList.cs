using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Uniluebeck.Itm.Tcpip;


namespace TraciConnector.Tudresden.Sumo.Util
{
    class StringList : List<String>
    {
        private readonly List<String> list;
        public StringList()
        {
            list = new List<String>();
        }

        public StringList(List<String> list)
        {
            this.list = list;
        }

        public StringList(Storage storage, bool verifyType)
        {
            if (verifyType)
            {
                if (storage.ReadByte() != Constants.TYPE_STRINGLIST)
                    throw new TraCIException("string list expected");
            }

            int len = storage.ReadInt();
            list = new List<String>(len);
            for (int i = 0; i < len; i++)
            {
                list.Add(storage.ReadStringASCII());
            }
        }

        public virtual void WriteTo(Storage out_renamed, bool writeTypeID)
        {
            if (writeTypeID)
                out_renamed.WriteByte(Constants.TYPE_STRINGLIST);
            out_renamed.WriteInt(list.Count);
            foreach (string str in list)
                out_renamed.WriteStringASCII(str);
        }

        public override string ToString()
        {
            return list.ToString();
        }

        public virtual new void Add(string e)
        {
            list.Add(e);
        }

        public void AddAll(List<String> c)
        {
            foreach(string s in c)
            {
                this.list.Add(s);
            }
        }

        public new void Clear()
        {
            list.Clear();
        }

        public new bool Contains(String o)
        {
            return list.Contains(o);
        }

        public new bool Equals(Object o)
        {
            return list.Equals(o);
        }

        public virtual string Get(int index)
        {
            return list.ElementAt(index);
        }

        public new int GetHashCode()
        {
            return list.GetHashCode();
        }

        public new int IndexOf(String o)
        {
            return list.IndexOf(o);
        }

        public  bool IsEmpty()
        {
            return list.Count == 0 ? true : false;
        }
        

        public new int LastIndexOf(String o)
        {
            return list.LastIndexOf(o);
        }

      


        public virtual void Remove(int index)
        {
            list.RemoveAt(index);
        }

        public new bool Remove(String o)
        {
            return list.Remove(o);
        }

        public virtual void RemoveAll(List<String> c)
        {
            foreach(string s in c)
            {
                list.Remove(s);
            }
        }

        public virtual void Set(int index, string element)
        {
            list[index] = element;
        }

        public virtual int Size()
        {
            return list.Count; ;
        }

        public virtual List<String> SubList(int fromIndex, int toIndex)
        {
            return list.GetRange(fromIndex, toIndex);
        }

        public new Object[] ToArray()
        {
            return list.ToArray();
        }
        
    }
}