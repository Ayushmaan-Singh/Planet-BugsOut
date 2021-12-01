using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldMapGenerationController : MonoBehaviour
{

    public List<Tilemap> PlanetTilemap;
    public SceneManagerSharedData shareData;

    private void Start()
    {
        ProceduralGenerator.GeneratePlanetBase(shareData.currentPlanetStats, PlanetTilemap[0]);
        GenerateWorldMap();
    }
    private void GenerateWorldMap()
    {
        ProceduralGenerator.GenerateWorld(shareData.currentPlanetStats, PlanetTilemap[1], shareData.currentPlanetStats.map_width,
            shareData.currentPlanetStats.map_height);
    }
}
