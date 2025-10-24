using Common.Utility;

namespace Common.Network;

/// <summary>
/// Represents client packet structure.
/// </summary>
public class Packet
{
     /// <summary>
        /// Overflow value.
        /// </summary>
        private const int DefaultOverflowValue = 256;

        /// <summary>
        /// Buffer.
        /// </summary>
        private byte[] buffer;

        /// <summary>
        /// Reader/writer offset.
        /// </summary>
        private int offset;

        /// <summary>
        /// Was received or created to be sent.
        /// </summary>
        private readonly bool receivedPacket;

        /// <summary>
        /// Initializes new instance of <see cref="Packet"/> (received packet).
        /// </summary>
        /// <param name="headerOffset"> Header offset (for opcodes).</param>
        /// <param name="buffer">Buffer.</param>
        public Packet(int headerOffset, byte[] buffer)
        {
            receivedPacket = true;
            this.buffer = buffer;
            offset = headerOffset;
        }

        /// <summary>
        /// Initializes new instance of <see cref="Packet"/> (packet to send).
        /// </summary>
        /// <param name="opcodes">Packet opcodes.</param>
        public Packet(params byte[] opcodes)
        {
            receivedPacket = false;
            buffer = opcodes;
            offset = opcodes.Length;
        }

        /// <summary>
        /// Writes byte value into packet buffer.
        /// </summary>
        /// <param name="value"><see cref="byte"/> value to write.</param>
        public unsafe void WriteByte(byte value)
        {
            ValidateBufferSize(sizeof(byte));

            fixed (byte* buf = buffer)
                *(buf + offset++) = value;
        }

        /// <summary>
        /// Writes array of <see cref="byte"/> values into packet buffer.
        /// </summary>
        /// <param name="value">Array of <see cref="byte"/> values.</param>
        public void WriteByte(params byte[] value)
        {
            WriteByteArray(value);
        }

        /// <summary>
        /// Writes array of <see cref="byte"/> into packet buffer.
        /// </summary>
        /// <param name="value">Array of <see cref="byte"/> values.</param>
        public void WriteByteArray(byte[] value)
        {
            int length = value.Length;

            ValidateBufferSize(length);

            L2Buffer.Copy(value, 0, buffer, offset, length);
            offset += length;
        }

        /// <summary>
        /// Writes <see cref="short"/> value into packet buffer.
        /// </summary>
        /// <param name="value"><see cref="short"/> value.</param>
        public unsafe void WriteShort(short value)
        {
            ValidateBufferSize(sizeof(short));

            fixed (byte* buf = buffer)
                *(short*)(buf + offset) = value;

            offset += sizeof(short);
        }

        /// <summary>
        /// Writes array of <see cref="short"/> values into packet buffer.
        /// </summary>
        /// <param name="value">Array of <see cref="short"/> values.</param>
        public unsafe void WriteShort(params short[] value)
        {
            int length = value.Length * sizeof(short);

            ValidateBufferSize(length);

            fixed (byte* buf = buffer)
            {
                fixed (short* w = value)
                    L2Buffer.UnsafeCopy(w, length, buf, ref offset);
            }
        }

        /// <summary>
        /// Writes <see cref="int"/> value to packet buffer.
        /// </summary>
        /// <param name="value"><see cref="int"/> value.</param>
        public unsafe void WriteInt(int value)
        {
            ValidateBufferSize(sizeof(int));

            fixed (byte* buf = buffer)
                *(int*)(buf + offset) = value;

            offset += sizeof(int);
        }

        /// <summary>
        /// Writes array of <see cref="int"/> values into packet buffer.
        /// </summary>
        /// <param name="value">Array of <see cref="int"/> values.</param>
        public unsafe void WriteInt(params int[] value)
        {
            int length = value.Length * sizeof(int);

            ValidateBufferSize(Length);

            fixed (byte* buf = buffer)
            {
                fixed (int* w = value)
                    L2Buffer.UnsafeCopy(w, length, buf, ref offset);
            }
        }

        /// <summary>
        /// Writes array of <see cref="int"/> values into packet buffer.
        /// </summary>
        /// <param name="value">Array of <see cref="int"/> values.</param>
        public unsafe void WriteIntArray(int[] value)
        {
            int length = value.Length * sizeof(int);

            ValidateBufferSize(Length);

            fixed (byte* buf = buffer)
            {
                fixed (int* w = value)
                    L2Buffer.UnsafeCopy(w, length, buf, ref offset);
            }
        }

        /// <summary>
        /// Writes <see cref="double"/> value into packet buffer.
        /// </summary>
        /// <param name="value"><see cref="double"/> value.</param>
        public unsafe void WriteDouble(double value)
        {
            ValidateBufferSize(sizeof(double));

            fixed (byte* buf = buffer)
                *(double*)(buf + offset) = value;

            offset += sizeof(double);
        }

        /// <summary>
        /// Writes array of <see cref="double"/> values into packet buffer.
        /// </summary>
        /// <param name="value">Array of <see cref="double"/> values.</param>
        public unsafe void WriteDouble(params double[] value)
        {
            int length = value.Length * sizeof(double);

            ValidateBufferSize(length);

            fixed (byte* buf = buffer)
            {
                fixed (double* w = value)
                    L2Buffer.UnsafeCopy(w, length, buf, ref offset);
            }
        }

        /// <summary>
        /// Writes <see cref="long"/> value into packet buffer.
        /// </summary>
        /// <param name="value"><see cref="long"/> value.</param>
        public unsafe void WriteLong(long value)
        {
            ValidateBufferSize(sizeof(long));

            fixed (byte* buf = buffer)
                *(long*)(buf + offset) = value;

            offset += sizeof(long);
        }

        /// <summary>
        /// Writes array of <see cref="long"/> values into packet buffer.
        /// </summary>
        /// <param name="value">Array of <see cref="long"/> values.</param>
        public unsafe void WriteLong(params long[] value)
        {
            int length = value.Length * sizeof(long);

            ValidateBufferSize(length);

            fixed (byte* buf = buffer)
            {
                fixed (long* w = value)
                    L2Buffer.UnsafeCopy(w, length, buf, ref offset);
            }
        }

        /// <summary>
        /// Writes <see cref="string"/> object into packet buffer.
        /// </summary>
        /// <param name="s"><see cref="string"/> value.</param>
        public unsafe void WriteString(string s)
        {
            s += '\0';
            int length = s.Length * sizeof(char);

            ValidateBufferSize(length);

            fixed (byte* buf = buffer)
            {
                fixed (char* w = s)
                    L2Buffer.UnsafeCopy(w, length, buf, ref offset);
            }
        }

        /// <summary>
        /// Writes array of <see cref="string"/> values to packet buffer.
        /// </summary>
        /// <param name="s">Array of <see cref="string"/> values.</param>
        public unsafe void WriteString(params string[] s)
        {
            string value = string.Join(string.Empty, s.Select(t => t + '\0').ToArray());

            int length = value.Length * sizeof(char);

            ValidateBufferSize(length);

            fixed (byte* buf = buffer)
            {
                fixed (char* w = value)
                    L2Buffer.UnsafeCopy(w, length, buf, ref offset);
            }
        }

        /// <summary>
        /// Writes <see cref="bool"/> value to packet buffer. (Inner network only)
        /// </summary>
        /// <param name="value"><see cref="bool"/> value.</param>
        public void InternalWriteBool(bool value)
        {
            WriteByte(value ? (byte)0x01 : (byte)0x00);
        }

        /// <summary>
        /// Writes <see cref="DateTime"/> value to packet buffer. (Inner network only)
        /// </summary>
        /// <param name="value"><see cref="DateTime"/> value.</param>
        public void InternalWriteDateTime(DateTime value)
        {
            WriteLong(value.Ticks);
        }

        /// <summary>
        /// Reads value from packet buffer. Также readC() но это не точно
        /// </summary>
        public unsafe byte ReadByte()
        {
            fixed (byte* buf = buffer)
                return *(buf + offset++);
        }

        /// <summary>
        /// Reads array of <see cref="byte"/> values from packet buffer.
        /// </summary>
        /// <param name="length">length of array to read.</param>
        /// <returns>Array of <see cref="byte"/> values.</returns>
        public unsafe byte[] ReadBytesArray(int length)
        {
            byte[] dest = new byte[length];

            fixed (byte* buf = buffer, dst = dest)
                L2Buffer.Copy(buf, length, dst, ref offset);
            return dest;
        }

        /// <summary>
        /// Чтение массива байт из пакета.
        /// //TODO: По какой то причине в RequestAuthLogin этот способ работает в отличии от ReadBytesArray
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public byte[] ReadByteArrayAlt(int length)
        {
            byte[] result = new byte[length];
            Array.Copy(GetBuffer(), offset, result, 0, length);
            offset += length;
            return result;
        }

        /// <summary>
        /// Reads value from packet buffer. Также readH()
        /// </summary>
        public unsafe short ReadShort()
        {
            fixed (byte* buf = buffer)
            {
                short value = *(short*)(buf + offset);
                offset += sizeof(short);
                return value;
            }
        }

        /// <summary>
        /// Reads value from packet buffer. Также readD()
        /// </summary>
        public unsafe int ReadInt()
        {
            fixed (byte* buf = buffer)
            {
                int value = *(int*)(buf + offset);
                offset += sizeof(int);
                return value;
            }
        }

        /// <summary>
        /// Reads value from packet buffer. Также readF()
        /// </summary>
        public unsafe double ReadDouble()
        {
            fixed (byte* buf = buffer)
            {
                double value = *(double*)(buf + offset);
                offset += sizeof(double);
                return value;
            }
        }

        /// <summary>
        /// Reads value from packet buffer. Также readQ()
        /// </summary>
        public unsafe long ReadLong()
        {
            fixed (byte* buf = buffer)
            {
                long value = *(long*)(buf + offset);
                offset += sizeof(long);
                return value;
            }
        }

        /// <summary>
        /// Reads value from packet buffer. Также readS()
        /// </summary>
        public unsafe string ReadString()
        {
            fixed (byte* buf = buffer)
                return L2Buffer.GetTrimmedString(buf, ref offset, buffer.Length);
        }

        /// <summary>
        /// Reads <see cref="bool"/> value from packet buffer. (Inner network only)
        /// </summary>
        /// <returns><see cref="bool"/> value.</returns>
        public bool InternalReadBool()
        {
            return ReadByte() == 0x01;
        }

        /// <summary>
        /// Reads <see cref="DateTime"/> value from packet buffer. (Inner network only)
        /// </summary>
        /// <returns><see cref="DateTime"/> value.</returns>
        public DateTime InternalReadDateTime()
        {
            return new DateTime(ReadLong());
        }

        /// <summary>
        /// Validates buffer capacity before writing into it.
        /// </summary>
        /// <param name="nextValueLength">length of next bytes sequence to write into buffer.</param>
        private void ValidateBufferSize(int nextValueLength)
        {
            if ((offset + nextValueLength) > buffer.Length)
                L2Buffer.Extend(ref buffer, nextValueLength + DefaultOverflowValue);
        }

        /// <summary>
        /// Resizes <see cref="Packet"/> buffer to it's actual capacity and appends buffer length to the beginning of <see cref="Packet"/> buffer.
        /// </summary>
        /// <param name="headerSize"><see cref="Packet"/> header (opcodes) capacity.</param>
        public unsafe void Prepare(int headerSize)
        {
            offset += headerSize;

            L2Buffer.Extend(ref buffer, headerSize, offset);

            fixed (byte* buf = buffer)
            {
                if (headerSize == sizeof(short))
                    *(short*)buf = (short)offset;
                else
                    *(int*)buf = offset;
            }
        }

        /// <summary>
        /// Returns packet buffer.
        /// </summary>
        /// <returns>Packet buffer.</returns>
        public byte[] GetBuffer()
        {
            return buffer;
        }

        /// <summary>
        /// Returns packet buffer.
        /// </summary>
        /// <param name="skipFirstBytesCount">Amount of first bytes to skip.</param>
        /// <returns>Buffer without provided amount of first bytes.</returns>
        public byte[] GetBuffer(int skipFirstBytesCount)
        {
            return L2Buffer.Copy(buffer, skipFirstBytesCount, new byte[buffer.Length - skipFirstBytesCount], 0, buffer.Length - skipFirstBytesCount);
        }

        /// <summary>
        /// Moves <see cref="Packet"/> offset position.
        /// </summary>
        /// <param name="size">Additional offset length.</param>
        public void MoveOffset(int size)
        {
            offset += size;
        }

        /// <summary>
        /// Gets first packet opcode.
        /// </summary>
        public unsafe byte FirstOpcode
        {
            get
            {
                fixed (byte* buf = buffer)
                    return *buf;
            }
        }

        /// <summary>
        /// Gets second packet opcode.
        /// </summary>
        public unsafe int SecondOpcode
        {
            get
            {
                fixed (byte* buf = buffer)
                    return *(buf + 1);
            }
        }

        /// <summary>
        /// Gets packet capacity.
        /// </summary>
        public int Length => receivedPacket ? buffer.Length : offset;

        /// <summary>
        /// Returns string representation of current packet.
        /// </summary>
        /// <returns>String representation of current packet.</returns>
        public override string ToString()
        {
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.AppendLine("Packet dump:");
            //sb.AppendFormat("1s op: {0}{2}2d op: {1}{2}", FirstOpcode, SecondOpcode, Environment.NewLine);
            //sb.Append(L2Buffer.ToString(m_Buffer));
            //return sb.ToString();
            return L2Buffer.ToString(buffer);
        }
}