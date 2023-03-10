using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Map : MonoBehaviour
{
    public const int width = 50;
    public const int height = 10;
    public const int textureWidth = 768;
    public const int textureBlockWidth = 48;
    public Plan plan;
    private BlockType[,,] map = new BlockType[width, height, width];

    private List<Vector3> vertices = new List<Vector3>();
    private List<Vector2>  uvs = new List<Vector2>();
    private List<int> triangles = new List<int>();
    private Mesh mapMesh;
    private BlockDictionary dictionary;
    private Camera m_camera;


    private float textWidthF = (float)textureBlockWidth / textureWidth;

    private void Start()
    {
        dictionary = FindObjectOfType<BlockDictionary>();
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                for (int z = 0; z < width; z++)
                {
                    map[x, y, z] = BlockType.GRASS;
                    if (y > 0) map[x, y, z] = BlockType.AIR;
                }
        DrawPlan(plan, new Vector3Int(5, 1, 5));
        mapMesh = new Mesh();
        RegenerateMesh();
        GetComponent<MeshFilter>().mesh = mapMesh;
        GetComponent<MeshCollider>().sharedMesh = mapMesh;
        m_camera = Camera.main;
    }

    private void GenerateBlock(int x, int y, int z)
    {
        var blockPosition = new Vector3Int(x, y, z);
        if (GetBlockAtPosition(blockPosition) == BlockType.AIR) return;

        if (GetBlockAtPosition(blockPosition + Vector3Int.right) == BlockType.AIR) GenerateRightSide(blockPosition);
        if (GetBlockAtPosition(blockPosition + Vector3Int.left) == BlockType.AIR) GenerateLeftSide(blockPosition);
        if (GetBlockAtPosition(blockPosition + Vector3Int.down) == BlockType.AIR) GenerateDownSide(blockPosition);
        if (GetBlockAtPosition(blockPosition + Vector3Int.up) == BlockType.AIR) GenerateTopSide(blockPosition);
        if (GetBlockAtPosition(blockPosition + Vector3Int.forward) == BlockType.AIR) GenerateBackSide(blockPosition);
        if (GetBlockAtPosition(blockPosition + Vector3Int.back) == BlockType.AIR) GenerateForwardSide(blockPosition);
    }

    private void GenerateRightSide(Vector3Int blockPosition)
    {
        var block = dictionary.blocks[map[blockPosition.x, blockPosition.y, blockPosition.z]];
        print(block);
        var textCoord = block.rightTextureCoord;
        vertices.Add(new Vector3(1, 0, 0) + blockPosition);
        vertices.Add(new Vector3(1, 0, 1) + blockPosition);
        vertices.Add(new Vector3(1, 1, 0) + blockPosition);
        vertices.Add(new Vector3(1, 1, 1) + blockPosition);
        uvs.Add(new Vector2(textCoord.x * textWidthF, textCoord.y * textWidthF));
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, textCoord.y * textWidthF));
        uvs.Add(new Vector2(textCoord.x * textWidthF, (textCoord.y + 1) * textWidthF));
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, (textCoord.y + 1) * textWidthF));

        AddLastVerticesSquare();
    }
    private void GenerateLeftSide(Vector3Int blockPosition)
    {
        var block = dictionary.blocks[map[blockPosition.x, blockPosition.y, blockPosition.z]];
        var textCoord = block.leftTextureCoord;
        vertices.Add(new Vector3(0, 0, 0) + blockPosition);
        vertices.Add(new Vector3(0, 1, 0) + blockPosition);
        vertices.Add(new Vector3(0, 0, 1) + blockPosition);
        vertices.Add(new Vector3(0, 1, 1) + blockPosition);
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, textCoord.y * textWidthF));
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, (textCoord.y + 1) * textWidthF));
        uvs.Add(new Vector2(textCoord.x * textWidthF, textCoord.y * textWidthF));
        uvs.Add(new Vector2(textCoord.x * textWidthF, (textCoord.y + 1) * textWidthF));
        AddLastVerticesSquare();
    }
    private void GenerateDownSide(Vector3Int blockPosition)
    {
        var block = dictionary.blocks[map[blockPosition.x, blockPosition.y, blockPosition.z]];
        var textCoord = block.downTextureCoord;
        vertices.Add(new Vector3(0, 0, 0) + blockPosition);
        vertices.Add(new Vector3(0, 0, 1) + blockPosition);
        vertices.Add(new Vector3(1, 0, 0) + blockPosition);
        vertices.Add(new Vector3(1, 0, 1) + blockPosition);
        uvs.Add(new Vector2(textCoord.x * textWidthF, (textCoord.y + 1) * textWidthF));
        uvs.Add(new Vector2(textCoord.x * textWidthF, textCoord.y * textWidthF));
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, (textCoord.y + 1) * textWidthF));
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, textCoord.y * textWidthF));

        AddLastVerticesSquare();
    }
    private void GenerateTopSide(Vector3Int blockPosition)
    {
        var block = dictionary.blocks[map[blockPosition.x, blockPosition.y, blockPosition.z]];
        var textCoord = block.topTextureCoord;
        vertices.Add(new Vector3(0, 1, 0) + blockPosition);
        vertices.Add(new Vector3(1, 1, 0) + blockPosition);
        vertices.Add(new Vector3(0, 1, 1) + blockPosition);
        vertices.Add(new Vector3(1, 1, 1) + blockPosition);
        uvs.Add(new Vector2(textCoord.x * textWidthF, textCoord.y * textWidthF));
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, textCoord.y * textWidthF));
        uvs.Add(new Vector2(textCoord.x * textWidthF, (textCoord.y + 1) * textWidthF));
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, (textCoord.y + 1) * textWidthF));

        AddLastVerticesSquare();
    }
    private void GenerateForwardSide(Vector3Int blockPosition)
    {
        var block = dictionary.blocks[map[blockPosition.x, blockPosition.y, blockPosition.z]];
        var textCoord = block.forwardTextureCoord;
        vertices.Add(new Vector3(0, 0, 0) + blockPosition);
        vertices.Add(new Vector3(1, 0, 0) + blockPosition);
        vertices.Add(new Vector3(0, 1, 0) + blockPosition);
        vertices.Add(new Vector3(1, 1, 0) + blockPosition);
        uvs.Add(new Vector2(textCoord.x * textWidthF, textCoord.y * textWidthF));
        uvs.Add(new Vector2((textCoord.x + 1) * 16 / 256f, textCoord.y * textWidthF));
        uvs.Add(new Vector2(textCoord.x * textWidthF, (textCoord.y + 1) * textWidthF));
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, (textCoord.y + 1) * textWidthF));

        AddLastVerticesSquare();
    }
    private void GenerateBackSide(Vector3Int blockPosition)
    {
        var block = dictionary.blocks[map[blockPosition.x, blockPosition.y, blockPosition.z]];
        var textCoord = block.backTextureCoord;
        vertices.Add(new Vector3(0, 0, 1) + blockPosition);
        vertices.Add(new Vector3(0, 1, 1) + blockPosition);
        vertices.Add(new Vector3(1, 0, 1) + blockPosition);
        vertices.Add(new Vector3(1, 1, 1) + blockPosition);
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, textCoord.y * textWidthF));
        uvs.Add(new Vector2((textCoord.x + 1) * textWidthF, (textCoord.y + 1) * textWidthF));
        uvs.Add(new Vector2(textCoord.x * textWidthF, textCoord.y * textWidthF));
        uvs.Add(new Vector2(textCoord.x * textWidthF, (textCoord.y + 1) * textWidthF));

        AddLastVerticesSquare();
    }
    private void AddLastVerticesSquare()
    {
        triangles.Add(vertices.Count - 3);
        triangles.Add(vertices.Count - 4);
        triangles.Add(vertices.Count - 2);

        triangles.Add(vertices.Count - 1);
        triangles.Add(vertices.Count - 3);
        triangles.Add(vertices.Count - 2);
    }
    private BlockType GetBlockAtPosition(Vector3Int position)
    {
        if (position.x >= 0 && position.x < width
            && position.z >=0 && position.z < width
            && position.y >=0 && position.y < height)
        {
            return map[position.x, position.y, position.z];
        }
        return BlockType.AIR;
    }

    private void RegenerateMesh()
    {
        vertices.Clear();
        triangles.Clear();
        uvs.Clear();

        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                for (int z = 0; z < width; z++)
                {
                    GenerateBlock(x, y, z);
                }

        mapMesh.triangles = Array.Empty<int>();
        mapMesh.vertices = vertices.ToArray();
        mapMesh.uv = uvs.ToArray();
        mapMesh.triangles = triangles.ToArray();
        
        mapMesh.Optimize();
        mapMesh.RecalculateNormals();
        mapMesh.RecalculateBounds();

    }

    private void OnMouseDown()
    {
        PlayerEvents.moveTo.Invoke(GetVectorClick());
    }
    public Vector3 GetVectorClick()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_camera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            print(hit.point);
            return hit.point;
        }
        return Vector3.zero;
    }

    public void DrawPlan(Plan plan, Vector3Int position)
    {
        for (int i = 0; i< plan.blocks.Count; i++)
        {
            map[position.x + plan.positions[i].x, position.y + plan.positions[i].y, position.z + plan.positions[i].z] = plan.blocks[i].blockType;
        }
    }
}