using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents
{
    public static UnityEvent<Unit> clickUnit = new UnityEvent<Unit>();
    public static UnityEvent<GameObject> deActivateUnit = new UnityEvent<GameObject>();
    public static UnityEvent<GameObject> clickPlayer = new UnityEvent<GameObject>();
    public static UnityEvent<GameObject> clickFriend = new UnityEvent<GameObject>();
    public static UnityEvent<GameObject> clickEnemy = new UnityEvent<GameObject>();
    public static UnityEvent<GameObject> drop = new UnityEvent<GameObject>();
    public static UnityEvent<Vector3> moveTo = new UnityEvent<Vector3>();
}
