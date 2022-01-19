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
        public int Unserialise()
        {
            byte[] rawData = { this[currentOffset], this[currentOffset + 1], this[currentOffset + 2], this[currentOffset + 3] };
            currentOffset += 4;
            return BitConverter.ToInt(rawData);
        }
        public string Unserialise()
        {
            byte[] rawDataSize = { this[currentOffset], this[currentOffset + 1], this[currentOffset + 2], this[currentOffset + 3] };
            currentOffset += 4;
            string returnValue = "";
            return returnValue;
        }
        public Vector2 Unserialise()
        {
            byte[] rawDatax = { this[currentOffset], this[currentOffset + 1], this[currentOffset + 2], this[currentOffset + 3] };
            currentOffset += 4;
            byte[] rawDatay = { this[currentOffset], this[currentOffset + 1], this[currentOffset + 2], this[currentOffset + 3] };
            currentOffset += 4;
            byte[] rawDataz = { this[currentOffset], this[currentOffset + 1], this[currentOffset + 2], this[currentOffset + 3] };
            currentOffset += 4;
            return BitConverter.ToSingle(rawData);
        }
        public Vecotr3 Unserialise()
        {
            byte[] rawDatax = { this[currentOffset], this[currentOffset + 1], this[currentOffset + 2], this[currentOffset + 3] };
            currentOffset += 4;
            byte[] rawDatay = { this[currentOffset], this[currentOffset + 1], this[currentOffset + 2], this[currentOffset + 3] };
            currentOffset += 4;
            byte[] rawDataz = { this[currentOffset], this[currentOffset + 1], this[currentOffset + 2], this[currentOffset + 3] };
            currentOffset += 4;
            return BitConverter.ToSingle(rawData);
        }
        public bool Unserialise()
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
        // We extend every primitive type to serialise them
        public static void Serialise(this int data, ref NetworkedDataBuffer buffer)
        {
            //Fixed data should always be 4 byte long
            byte[] fixedData = BitConverter.GetBytes(data);
            buffer.data.AddRange(fixedData);
        }
        // We extend every primitive type to serialise them
        public static void Serialise(this string data, ref NetworkedDataBuffer buffer)
        {
            //Fixed data should always be 4 byte long
            byte[] stringSize = BitConverter.GetBytes(data.Length);
            buffer.data.AddRange(stringSize);
            List<byte> flexibleData = new List<byte>();
            foreach(char c in data)
            {
                flexibleData.AddRange(BitConverter.GetBytes(c));
            }
        }
        // We extend every primitive type to serialise them
        public static void Serialise(this Vector3 data, ref NetworkedDataBuffer buffer)
        {
            //Fixed data should always be 4 byte long
            byte[] fixedDatax = BitConverter.GetBytes(data.x);
            byte[] fixedDatay = BitConverter.GetBytes(data.y);
            byte[] fixedDataz = BitConverter.GetBytes(data.z);
            buffer.data.AddRange(fixedDatax);
            buffer.data.AddRange(fixedDatay);
            buffer.data.AddRange(fixedDataz);
        }
        // We extend every primitive type to serialise them
        public static void Serialise(this Vector2 data, ref NetworkedDataBuffer buffer)
        {
           //Fixed data should always be 4 byte long
            byte[] fixedDatax = BitConverter.GetBytes(data.x);
            byte[] fixedDatay = BitConverter.GetBytes(data.y);
            buffer.data.AddRange(fixedDatax);
            buffer.data.AddRange(fixedDatay);
        }// We extend every primitive type to serialise them
        public static void Serialise(this bool data, ref NetworkedDataBuffer buffer)
        {
            //Fixed data should always be 4 byte long
            byte[] fixedData = BitConverter.GetBytes(data ? 1:0);
            buffer.data.AddRange(fixedData);
        }
    }
}
