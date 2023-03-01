using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GlobalEvents
{
    public static UnityEvent gameStart = new UnityEvent();
    public static UnityEvent gamePause = new UnityEvent();

    public static UnityEvent levelStart = new UnityEvent();
    public static UnityEvent levelWin = new UnityEvent();
    public static UnityEvent levelLose = new UnityEvent();
    public static UnityEvent levelLeave = new UnityEvent();
}
