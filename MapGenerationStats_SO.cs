using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum planetType
{
    dwarf=0,
    goldilocks=1,
    rockGiant=2,
    gasGiant=3
}
public enum planetBase
{
    water=0,
    ice=1,
    lava=2,
    gas=3,
    plains=4,
    obsidian=5
}
public enum Biomes
{
    plains=0,
    mountains=1,
    swamp=2,
    desert=3,
    lava=4,
    obsidian=5,
    ice=6,
    nullBiome=7
}

[CreateAssetMenu(fileName = "MapGenerationStats", menuName = "Map Generator/Planet Stats")]
public class MapGenerationStats_SO : ScriptableObject
{
    public planetType PlanetType;
    public planetBase PlanetBase;
    public List<Tile> PlanetBaseTiles;

    public bool Habitable = false;
    public bool canBeTerraformed;
    public int map_width, map_height;

    public List<BiomesList> Biomes;
}

[System.Serializable]
public class BiomesList
{
    public Biomes Biome;
    public List<Tile> BiomeTiles;
    public bool canBeTerraformed;
}
