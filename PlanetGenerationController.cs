using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlanetGenerationController : MonoBehaviour
{
    public PlanetControl planetGeneration;
    public List<MapGenerationStats_SO> availableMapStats;
    public MapGenerationStats_SO currentMapStats;

    private planetType currentPlanetType;
    private planetBase currentPlanetBase;

    private bool planetIsInitialized=false;
    public GameObject planetGO;

    public SceneManagerSharedData shareData;

    public void GenerateRandomPlanet()
    {
            for (int i = 0; i < 8; i++)
            {
                planetIsInitialized = planetGO.transform.GetChild(i).gameObject.activeSelf;
                if (planetIsInitialized)
                    break;
            }
            planetGeneration.GeneratePlanet();
            setPlanetType();
            shareData.currentPlanetStats = currentMapStats;
        //SavePlanet storePlanet = ScriptableObject.CreateInstance<SavePlanet>();
        //storePlanet.planetId = planetGeneration.selected_planet;
        //PlanetScriptableObjectUtility.SavePlanetFile(storePlanet);
    }

    private void setPlanetType()
    {
        int randomChance = Random.Range(0, 8);

        if (randomChance > 3)
            randomChance = 0;
        else
            randomChance = 1;

        switch (planetGeneration.selected_planet)
        {
            case 0:
                currentPlanetType = planetType.goldilocks;
                currentMapStats = availableMapStats[5];
                break;

            case 1:
                if (randomChance == 0)
                {
                    currentPlanetType = planetType.dwarf;
                    currentPlanetBase = planetBase.obsidian;
                    currentMapStats = availableMapStats[2];
                }
                else
                {
                    currentPlanetType = planetType.rockGiant;
                    currentMapStats = availableMapStats[6];
                }
                break;

            case 2:
                if (randomChance == 0)
                {
                    currentPlanetType = planetType.dwarf;
                    currentPlanetBase = planetBase.water;
                    currentMapStats = availableMapStats[3];
                }
                else
                {
                    currentPlanetType = planetType.goldilocks;
                    currentMapStats = availableMapStats[5];
                }
                break;

            case 3:
                if (randomChance == 0)
                {
                    currentPlanetType = planetType.dwarf;
                    currentPlanetBase = planetBase.obsidian;
                    currentMapStats = availableMapStats[2];
                }
                else
                {
                    currentPlanetType = planetType.rockGiant;
                    currentMapStats = availableMapStats[6];
                }
                break;

            case 4:
                currentPlanetType = planetType.gasGiant;
                currentMapStats = availableMapStats[4];
                break;

            case 5:
                currentPlanetType = planetType.gasGiant;
                currentMapStats = availableMapStats[4];
                break;

            case 6:
                currentPlanetType = planetType.dwarf;
                currentPlanetBase = planetBase.ice;
                currentMapStats = availableMapStats[0];
                break;

            case 7:
                if (randomChance == 0)
                {
                    currentPlanetType = planetType.dwarf;
                    currentPlanetBase = planetBase.lava;
                    currentMapStats = availableMapStats[1];
                }
                else
                {
                    int randomizer = Random.Range(0, 2);
                    if (randomizer == 0)
                    {
                        currentPlanetType = planetType.gasGiant;
                        currentMapStats = availableMapStats[4];
                    }
                    else
                    {
                        currentPlanetType = planetType.rockGiant;
                        currentMapStats = availableMapStats[6];
                    }
                }
                break;

        }
    }
}
//public static class PlanetScriptableObjectUtility
//{
//    public static void SavePlanetFile(SavePlanet Map)
//    {
//        AssetDatabase.CreateAsset(Map, $"Assets/Resources/Planet.asset");

//        AssetDatabase.SaveAssets();
//        AssetDatabase.Refresh();
//    }
//}
