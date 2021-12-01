using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class ProceduralGenerator
{
    public static void GeneratePlanetBase(MapGenerationStats_SO PlanetStat,Tilemap PlanetBase)
    {
        for (int x = 0; x < PlanetStat.map_width; x++)
        {
            for(int y=0;y<PlanetStat.map_height;y++)
            {
                Vector3 basePos = new Vector3(x, y, 0);
                Vector3Int basePosCell = PlanetBase.WorldToCell(basePos);

                int randomChoice = Random.Range(0,PlanetStat.PlanetBaseTiles.Count);

                PlanetBase.SetTile(basePosCell, PlanetStat.PlanetBaseTiles[randomChoice]);
            }
        }
    }

    public static void GenerateWorld(MapGenerationStats_SO planetStats, Tilemap WorldTileMap,int map_width,int map_height)
    {
        Dictionary<int, BiomesList> TileGroup=new Dictionary<int, BiomesList>();
        List<TileObject_SO> tileGenerated=new List<TileObject_SO>();
        List<List<int>> noise_grid = new List<List<int>>();
        List<List<Tile>> worldgrid = new List<List<Tile>>();
        Dictionary<int, BiomesList> TilesUsable = new Dictionary<int, BiomesList>();

        CreateTileset(TilesUsable,planetStats);
        //CreateTileGroups(TileGroup,TilesUsable);

        WorldTileMap.ClearAllTiles();
        int magnification = Random.Range(10,20);
        int x_offset = (int)(Mathf.Round((Random.Range(0, 100000) / 100)));
        int y_offset = (int)(Mathf.Round((Random.Range(0, 100000) / 100)));

        GenerateMap(map_width,map_height,noise_grid,x_offset,y_offset,magnification,TilesUsable,WorldTileMap);
        //RandomlyRemove(calcTilesMaxPercentageAllowed(map_width,map_height),WorldTileMap);
    }

    private static float calcTilesMaxPercentageAllowed(int map_width, int map_height)
    {
        float percentageAllowed = (map_width * map_height * 35) / 100;

        return percentageAllowed;
    }

    private static void CreateTileset(Dictionary<int, BiomesList> TilesUsable, MapGenerationStats_SO planetStats)
    {
        TilesUsable.Clear();
        for (int i = 0; i < planetStats.Biomes.Count; i++)
        {
            TilesUsable.Add(i, planetStats.Biomes[i]);
        }
    }
    //private static void CreateTileGroups(Dictionary<int, BiomesList> TileGroup, Dictionary<int, BiomesList> TilesUsable)
    //{
    //    TileGroup = new Dictionary<int, BiomesList>();
    //    foreach (KeyValuePair<int, BiomesList> prefab_pair in TilesUsable)
    //    {
    //        BiomesList tile_group = prefab_pair.Value;
    //        TileGroup.Add(prefab_pair.Key, tile_group);
    //    }
    //}

    private static void GenerateMap(int map_width,int map_height, List<List<int>> noise_grid, 
        int x_offset, int y_offset, int magnification, Dictionary<int, BiomesList> TilesUsable,Tilemap WorldTileMap)
    {
        for (int x = 0; x < map_width; x++)
        {
            noise_grid.Add(new List<int>());
            for (int y = 0; y < map_height; y++)
            {
                int tile_id = GetIdUsingPerlin((float)x, (float) y,(float)x_offset, (float)y_offset,magnification,TilesUsable);
                noise_grid[x].Add(tile_id);
                CreateTile(tile_id, x, y,TilesUsable,WorldTileMap);
            }
        }
    }

    //private static void RandomlyRemove(float percentageAllowed, Tilemap WorldTileMap, int map_width, int map_height)
    //{
    //    BoundsInt bounds = WorldTileMap.cellBounds;
    //    TileBase[] allTiles = WorldTileMap.GetTilesBlock(bounds);

    //    for (int i = 0; i < percentageAllowed; i++)
    //    {
    //        Vector3Int randomTilePos = new Vector3Int(Random.Range(0, map_width), Random.Range(0, map_height), 0);
    //        if ((((Tile)WorldTileMap.GetTile(randomTilePos)).sprite) != null)
    //        {
    //            WorldTileMap.SetTile(randomTilePos, null);
    //        }
    //    }
    //}//Might delete or modify later

    private static int GetIdUsingPerlin(float x, float y, float x_offset, float y_offset, int magnification, Dictionary<int, BiomesList> TilesUsable)
    {
        float raw_perlin = Mathf.PerlinNoise(
               (x - x_offset) / magnification,
               (y - y_offset) / magnification
           );
        float clamp_perlin = Mathf.Clamp01(raw_perlin);
        float scaled_perlin = clamp_perlin * TilesUsable.Count;

        if (scaled_perlin == TilesUsable.Count)
        {
            scaled_perlin = (TilesUsable.Count - 1);
        }
        return Mathf.FloorToInt(scaled_perlin);
    }

    private static void CreateTile(int tile_id, int x, int y, Dictionary<int, BiomesList> TilesUsable,Tilemap WorldTileMap)
    {
        BiomesList currentBiome = TilesUsable[tile_id];
        Tile currentTile = currentBiome.BiomeTiles[Random.Range(0, currentBiome.BiomeTiles.Count)];

        Vector3Int position = WorldTileMap.WorldToCell(new Vector3(x, y, 0));
        WorldTileMap.SetTile(position, currentTile);
    }
}
