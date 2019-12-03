using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Uniluebeck.Itm.Tcpip;

namespace TraciConnector.Protocol
{
    public class Command
    {
        private static readonly int HEADER_SIZE = 8 / 8 + 32 / 8 + 8 / 8;
        private readonly int id;
        private readonly Storage content;
        public Command(Storage rawStorage)
        {
            int contentLen = rawStorage.ReadUnsignedByte();
            if (contentLen == 0)
                contentLen = rawStorage.ReadInt() - 6;
            else
                contentLen = contentLen - 2;
            id = rawStorage.ReadUnsignedByte();
            short[] buf = new short[contentLen];
            for (int i = 0; i < contentLen; i++)
            {
                buf[i] = (sbyte)rawStorage.ReadUnsignedByte();
            }

            content = new Storage(buf);
        }

        public Command(int id)
        {
            if (id > 255)
                throw new ArgumentException("id should fit in a byte");
            content = new Storage();
            this.id = id;
        }

        public virtual int Id()
        {
            return id;
        }

        public virtual Storage Content()
        {
            return content;
        }

        public virtual void WriteRawTo(Storage out_renamed)
        {
            out_renamed.WriteByte(0);
            out_renamed.WriteInt(HEADER_SIZE + content.Size());
            out_renamed.WriteUnsignedByte(id);
            foreach (Byte b in content.GetStorageList())
            {
                out_renamed.WriteByte((sbyte)b);
            }
        }

        public virtual int RawSize()
        {
            return HEADER_SIZE + content.Size();
        }
    }
}