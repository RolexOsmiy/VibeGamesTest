using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private WaveData waveData;

        public void CreateWave()
    {
        GameObject item;

        if (waveData.waves.Count < GameManager.Instance.GetCurrentWave())
        {
            for (int i = 0; i < waveData.waves[GameManager.Instance.GetCurrentWave()].enemies.Count; i++)
            {
                item = waveData.waves[0].enemies[i];
                EnemyManager.Instance.AddEnemy(Instantiate(item).GetComponent<Enemy>());
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
