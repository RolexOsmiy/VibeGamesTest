using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private EnemyFactory enemyFactory;
    
    [SerializeField] private int currentWave = 0;
    [SerializeField] private Transform[] fightPoints;

    // Инициализация игры

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        NextWave(false);
    }

    public Vector3 GetFightPoint()
    {
        return fightPoints[currentWave].position;
    }
    
    public int GetCurrentWave()
    {
        return currentWave;
    }

    public void NextWave(bool withIncrement = true)
    {
        if (withIncrement)
            currentWave++;
        
        enemyFactory.CreateWave();
    }
}
