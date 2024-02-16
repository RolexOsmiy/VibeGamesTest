using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private int currentWave = 0;

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
        return EnemyFactory.instance.GetFightPoint();
    }

    public int GetCurrentWave()
    {
        return currentWave;
    }

    public void NextWave(bool withIncrement = true)
    {
        if (withIncrement)
            currentWave++;
        
        EnemyFactory.instance.CreateWave();
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().MoveTo(EnemyFactory.instance.GetFightPoint());
    }
}
