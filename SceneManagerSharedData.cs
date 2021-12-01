using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SceneManagerSharedData",menuName ="Map Generator/Scene Data")]
public class SceneManagerSharedData : ScriptableObject
{
    public MapGenerationStats_SO currentPlanetStats;
}
