using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class proce : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] int minheight, maxheight;
    [SerializeField] int RepeatNum;
    [SerializeField] Tilemap dirtTilemap, stoneTilemap, grassTilemap;
    [SerializeField] Tile dirt, stone, grass;


    void Start()
    {
        Generation();
    }

    // Update is called once per frame
    void Generation()
    {
        int repeatValue = 0;
        for (int x = 0; x < width; x++)
        {
            if (repeatValue == 0)
            {
                height = UnityEngine.Random.Range(minheight, maxheight);
                GenerateFlatPlatform(x);
                repeatValue = RepeatNum;
            }
            else
            {
                GenerateFlatPlatform(x);
                repeatValue--;
            }

        }
    }

    void GenerateFlatPlatform(int x)
    {
        int MinStoneSpawnDistance = height - 2;
        int MaxStoneSpawnDistance = height - 6;
        int TotalStoneSpawnDistance = UnityEngine.Random.Range(MinStoneSpawnDistance, MaxStoneSpawnDistance);

        for (int y = 0; y < height; y++)
        {
            if (y < TotalStoneSpawnDistance)
            {
                stoneTilemap.SetTile(new Vector3Int(x, y, 0), stone);
            }
            else
            {
                dirtTilemap.SetTile(new Vector3Int(x, y, 0), dirt);
            }
        }
        grassTilemap.SetTile(new Vector3Int(x, height, 0), grass);
    }
}