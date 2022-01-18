using System.Runtime.InteropServices;
using System.ComponentModel;
using System;
using System.Collections.Generic;
namespace LowkeyInteractive.Serialisation
{
    public struct NetworkedDataBuffer
    {
        public List<byte> data;
        public int currentOffset;
        public byte this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }
        public NetworkedDataBuffer(byte[] inputData)
        {
            data = new List<byte>(inputData);
            currentOffset = 0;
        }
        //We define how to deserialize primitive types here
        public float Unserialise()
        {
            byte[] rawData = { this[currentOffset], this[currentOffset + 1], this[currentOffset + 2], this[currentOffset + 3] };
            currentOffset += 4;
            return BitConverter.ToSingle(rawData);
        }
    }
    public static class SerialiseMethods
    {
        // We extend every primitive type to serialise them
        public static void Serialise(this float data, ref NetworkedDataBuffer buffer)
        {
            //Fixed data should always be 4 byte long
            byte[] fixedData = BitConverter.GetBytes(data);
            buffer.data.AddRange(fixedData);
        }
    }
}
