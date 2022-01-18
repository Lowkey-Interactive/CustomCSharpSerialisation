using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LowkeyInteractive.Serialisation;

public class NetworkTest : MonoBehaviour
{
    public NetworkedDataBuffer buffer = new NetworkedDataBuffer(new byte[0]);
    public float myFloat = 5f;
    public float myOtherFloat = 50f;

    void Awake()
    {
        if (buffer.data == null) return;
        myFloat.Serialise(ref buffer);
        myOtherFloat.Serialise(ref buffer);
        float myDeserialisedFloat = buffer.Unserialise();
        float myDeserialisedOtherFloat = buffer.Unserialise();
        Debug.Log(myDeserialisedFloat);
        Debug.Log(myDeserialisedOtherFloat);
    }
}
