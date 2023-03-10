using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plan", menuName = "ScriptableObjects/Plan", order = 2)]
public class Plan : ScriptableObject
{
    public int width;
    public int depth;
    public int height;
    public List<Block> blocks;
    public List<Vector3Int> positions;
}
