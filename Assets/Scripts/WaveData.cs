using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave Data", order = 2)]
public class WaveData : ScriptableObject
{
    public List<Wave> waves;
}

[System.Serializable]
public class Wave
{
    public List<GameObject> enemies;
    public float spawnDelay;
    public float spawnInterval;
}
