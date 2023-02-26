using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents
{
    //create tower or house on Vector2(float, float) with name = "string"
    public static UnityEvent<float, float, string> createBuild = new UnityEvent<float, float, string>();

    
}
