using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkModel
{
    public override string ToString()
    {
        return UnityEngine.JsonUtility.ToJson(this);
    }
}
