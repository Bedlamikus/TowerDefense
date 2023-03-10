using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDictionary : MonoBehaviour
{
    public List<Block> blockByType;
    public Dictionary<BlockType, Block> blocks = new Dictionary<BlockType, Block>();
    private void Awake()
    {
        foreach (var value in blockByType)
        {
            blocks.Add(value.blockType, value);
        }
    }
}
