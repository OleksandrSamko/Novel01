using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserResponse {
    public string id;

    public override string ToString()
    {
        return UnityEngine.JsonUtility.ToJson(this, true);
    }
}
