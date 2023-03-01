using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : WorldObject
{
    protected override void OnMouseDown()
    {
        PlayerEvents.moveTo.Invoke(GetVectorClick());
    }
}
