using System;
namespace LowkeyInteractive.Serialisation
{
    public interface ISerialisable
    {
        public void Serialise<T>(ref NetworkedDataBuffer buffer);
        public T Unserialise<T>(ref NetworkedDataBuffer buffer);
    }
}
