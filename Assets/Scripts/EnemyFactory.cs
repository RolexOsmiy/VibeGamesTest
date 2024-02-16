using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory instance;
    
    [SerializeField] private WaveData waveData;

    private void Awake()
    {
        instance = this;
    }

    public Vector3 GetFightPoint()
    {
        return waveData.waves[GameManager.Instance.GetCurrentWave()].fightPoint;
    }

    public void CreateWave()
    {
        GameObject item;

        if (waveData.waves.Count > GameManager.Instance.GetCurrentWave())
        {
            for (int i = 0; i < waveData.waves[GameManager.Instance.GetCurrentWave()].enemies.Count; i++)
            {
                item = waveData.waves[0].enemies[i];
                EnemyManager.Instance.AddEnemy(Instantiate(item).GetComponent<Enemy>());
            }
        }
    }
}

public enum EnemyType
{
    gMan,
    ToiletMan,
    SpeakerMan,
    tvMan
}
