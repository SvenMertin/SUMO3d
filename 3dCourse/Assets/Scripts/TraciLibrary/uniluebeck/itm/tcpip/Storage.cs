using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace TraciConnector.Uniluebeck.Itm.Tcpip
{
    public class Storage
    {
        
        private List<sbyte> storageList;
        private int position;
        private List<sbyte>.Enumerator listIt;
        public Storage()
        {
            storageList = new List<sbyte>();
            Init();
        }

        public Storage(sbyte[] packet): this (packet, 0, packet.Length)
        {
        }

        public Storage(sbyte[] packet, int offset, int length)
        {
            if (packet == null)
                throw new Exception("packet can't be null");
            if (length > packet.Length)
                throw new Exception("length exceeds packet length");
            if (offset + length > packet.Length)
                throw new Exception("content is outside the array");
            storageList = new List<sbyte>();
            for (int i = offset; i < length; i++)
            {
                WriteByte(packet[i]);
            }

            Init();
        }

        public Storage(short[] packet): this (packet, 0, packet.Length)
        {
        }

        public Storage(short[] packet, int offset, int length)
        {
            if (packet == null)
                throw new Exception("packet can't be null");
            if (length > packet.Length)
                throw new Exception("length exceeds packet length");
            if (offset + length > packet.Length)
                throw new Exception("content is outside the array");
            storageList = new List<sbyte>();
            for (int i = offset; i < length; i++)
            {
                WriteByte(packet[i]);
            }

            Init();
        }

        
        public virtual bool ValidPos()
        {
            return (position < storageList.Count() && position >= 0 && storageList.Count() != 0);
        }
        

        public virtual int Position()
        {
            return position;
        }

        public virtual void WriteByte(sbyte value)
        {
            WriteByte((int)value);
        }

        public virtual void WriteByte(int value)
        {
            if (value < -128 || value > 127)
                throw new ArgumentException("Error writing byte: byte value may only range from -128 to 127.");
            storageList.Add(Convert.ToSByte(value));
        }
        
        public virtual short ReadByte()
        {
            if (!ValidPos())
                throw new InvalidOperationException("Error reading byte, invalid list position specified for reading: " + position);
            position++;
            listIt.MoveNext();
            return (short)listIt.Current;
        }
        

        public virtual void WriteUnsignedByte(short value)
        {
            WriteUnsignedByte((int)value);
        }

        public virtual void WriteUnsignedByte(int value)
        {
            if (value < 0 || value > 255)
                throw new ArgumentException("Error writing unsigned byte: byte value may only range from 0 to 255.");
            if (value > 127)
            {
                storageList.Add(Convert.ToSByte(value - 256));
            }
            else
                storageList.Add(Convert.ToSByte(value));
        }

        
        public virtual short ReadUnsignedByte()
        {
            if (!ValidPos())
                throw new InvalidOperationException("Error reading unsigned byte, invalid list position specified for reading: " + position);
            position++;
            listIt.MoveNext();
            return (short)((listIt.Current + 256) % 256);                       
        }
        

        public virtual void WriteShort(int value)
        {
            /*
            ByteArrayOutputStream byteOut = new ByteArrayOutputStream(2);
            DataOutputStream dataOut = new DataOutputStream(byteOut);
            byte[] bytes = new byte[2];
            if (value < -32768 || value > 32768)
                throw new ArgumentException("Error writing short: short value may only range from -32768 to 32768.");
            try
            {
                dataOut.WriteShort(value);
                dataOut.Close();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }

            bytes = byteOut.ToSByteArray();*/
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes, 0, bytes.Length);
            for (int i = 0; i < 2; i++)
                WriteByte(bytes[i]);
        }

        
        public virtual int ReadShort()
        {
            /*
             * ByteArrayInputStream byteIn;
            DataInputStream dataIn;
            */
            byte[] content = new byte[2];
            
//            int result = 0;

            for (int i = 0; i < 2; i++)
            {
                content[i] = (byte)ReadByte();
            }
            /*
            byteIn = new ByteArrayInputStream(content);
            dataIn = new DataInputStream(byteIn);
            try
            {
                result = dataIn.ReadShort();
                dataIn.Close();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }

            return result;*/
            Array.Reverse(content, 0, content.Length);
            return BitConverter.ToUInt16(content, 0);
        }
        

        public virtual void WriteInt(int value)
        {
            /*
            ByteArrayOutputStream byteOut = new ByteArrayOutputStream(4);
            DataOutputStream dataOut = new DataOutputStream(byteOut);
            */
            byte[] bytes = new byte[4];
            /*
            try
            {
                dataOut.WriteInt(value);
                dataOut.Close();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }
            
            bytes = byteOut.ToSByteArray();
            */
            bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes, 0, bytes.Length);
            for (int i = 0; i < 4; i++)
                WriteByte(bytes[i]);
        }

        
        public virtual int ReadInt()
        {
            /*
            ByteArrayInputStream byteIn;
            DataInputStream dataIn;
            */
            byte[] content = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                content[i] = (byte)ReadByte();
            }
            /*
            byteIn = new ByteArrayInputStream(content);
            dataIn = new DataInputStream(byteIn);
            try
            {
                result = dataIn.ReadInt();
                dataIn.Close();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }

            return result;
            */
            Array.Reverse(content, 0, content.Length);
            return BitConverter.ToInt32(content, 0);
        }
        
        public virtual void WriteFloat(float value)
        {
            /*
             * ByteArrayOutputStream byteOut = new ByteArrayOutputStream(4);
            DataOutputStream dataOut = new DataOutputStream(byteOut);
            */
            byte[] bytes = new byte[4];
            /*
            try
            {
                dataOut.WriteFloat(value);
                dataOut.Close();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }
            bytes = byteOut.ToSByteArray();
            */
            bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes, 0, bytes.Length);
            for (int i = 0; i < 4; i++)
                WriteByte(bytes[i]);
        }

        public virtual float ReadFloat()
        {
            /*
            ByteArrayInputStream byteIn;
            DataInputStream dataIn;
            */
            byte[] content = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                content[i] = (byte)ReadByte();
            }
            /*
            byteIn = new ByteArrayInputStream(content);
            dataIn = new DataInputStream(byteIn);
            try
            {
                result = dataIn.ReadFloat();
                dataIn.Close();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }

            return result;
            */
            Array.Reverse(content, 0, content.Length);
            return BitConverter.ToSingle(content, 0);
        }

        public virtual void WriteDouble(double value)
        {
            /*
            ByteArrayOutputStream byteOut = new ByteArrayOutputStream(8);
            DataOutputStream dataOut = new DataOutputStream(byteOut);
            */
            byte[] bytes = new byte[8];
            /*
            try
            {
                dataOut.WriteDouble(value);
                dataOut.Close();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }

            bytes = byteOut.ToSByteArray();
            */
            bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes, 0, bytes.Length);
            
            for (int i = 0; i < 8; i++)
                WriteByte((sbyte)bytes[i]);
        }

        public virtual double ReadDouble()
        {
            /*
            ByteArrayInputStream byteIn;
            DataInputStream dataIn;
            */
            byte[] content = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                content[i] = (byte)ReadByte();
            }
            /*
            byteIn = new ByteArrayInputStream(content);
            dataIn = new DataInputStream(byteIn);
            try
            {
                result = dataIn.ReadDouble();
                dataIn.Close();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }

            return result;
            */
            Array.Reverse(content, 0, content.Length);
            return BitConverter.ToDouble(content, 0);
        }
        
        public virtual void WriteStringUTF8(string value)
        {
            WriteString(value, "UTF-8");
        }

        public virtual void WriteStringASCII(string value)
        {
            WriteString(value, "US-ASCII");
        }

        public virtual void WriteStringISOLATIN1(string value)
        {
            WriteString(value, "ISO-8859-1");
        }

        public virtual void WriteStringUTF16BE(string value)
        {
            WriteString(value, "UTF-16BE");
        }

        public virtual void WriteStringUTF16LE(string value)
        {
            WriteString(value, "UTF-16LE");
        }

        
        private void WriteString(string value, string charset)
        {
            byte[] bytes;
            try
            {
                bytes = Encoding.ASCII.GetBytes(value);//value.getBytes(charset);
                
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
                return;
            }

            WriteInt(Encoding.ASCII.GetBytes(value).Length);
            for (int i = 0; i < bytes.Length; i++)
                WriteByte(bytes[i]);
        }
        
        public virtual string ReadStringUTF8()
        {
            return ReadString("UTF-8");
        }

        public virtual string ReadStringASCII()
        {
            return ReadString("US-ASCII");
        }

        public virtual string ReadStringISOLATIN1()
        {
            return ReadString("ISO-8859-1");
        }

        public virtual string ReadStringUTF16BE()
        {
            return ReadString("UTF-16BE");
        }

        public virtual string ReadStringUTF16LE()
        {
            return ReadString("UTF-16LE");
        }
        
        private string ReadString(string charset)
        {
            byte[] content;
            //string result = new string ("");
            string result = "";
            int length;
            length = ReadInt();
            content = new byte[length];
            for (int i = 0; i < length; i++)
            {
                content[i] = (byte)ReadByte();
            }

            try
            {
                //result = new string(content, charset);
                //Array.Reverse(content, 0, content.Length);
                //result = BitConverter.ToString(content);
                return System.Text.Encoding.Default.GetString(content);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return result;
        }

        public virtual void Reset()
        {
            storageList.Clear();
            Init();
        }

        public virtual int Size()
        {
            return storageList.Count();
        }

        public virtual List<sbyte> GetStorageList()
        {
            return storageList;
        }
        
        private void Init()
        {
            position = 0;
            listIt = storageList.GetEnumerator();
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < storageList.Count(); i++)
            {
                if (i == position)
                    sb.Append("[");
                else
                    sb.Append(" ");
                sb.Append(String.Format("%02X", storageList.ElementAt(i)));
            }

            return sb.ToString();
        }
        
    }
    
}