using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int cols = 9;
    public int rows = 15;
    public List<GameObject> cells = new List<GameObject>();

    public Vector2 GetCursor(Vector3 WorldCursor)
    {
        return Vector2.zero;
    }
}
