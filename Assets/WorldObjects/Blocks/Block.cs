using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block", menuName = "ScriptableObjects/Block", order = 1)]
public class Block : ScriptableObject
{
    public BlockType blockType;
    public Vector2Int leftTextureCoord;
    public Vector2Int rightTextureCoord;
    public Vector2Int backTextureCoord;
    public Vector2Int forwardTextureCoord;
    public Vector2Int topTextureCoord;
    public Vector2Int downTextureCoord;
    //For Plan
    public Vector3Int position;
}
