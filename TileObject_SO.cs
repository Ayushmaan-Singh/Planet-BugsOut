using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName ="TileObject",menuName ="Tiles/Create WorlMap Tile")]
public class TileObject_SO : Tile
{
    public Biomes BiomeOfTile;

    int maxCost = 10;

    public void calcCost()
    {

    }
}
