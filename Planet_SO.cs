using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Planet_SO",menuName = "Map Generator/All Planets")]
public class Planet_SO : ScriptableObject
{
    public List<PlanetData> PlanetData;
}

[System.Serializable]
public class PlanetData
{
    public List<GameObject> PlanetGO;
    public List<MapGenerationStats_SO> PlanetStats;
}
