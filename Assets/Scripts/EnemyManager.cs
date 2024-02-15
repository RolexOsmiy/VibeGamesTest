using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    
    private Dictionary<int, Enemy> enemies = new Dictionary<int, Enemy>();

    private void Start()
    {
        Instance = this;
    }

    public void AddEnemy(Enemy enemy)
    {
        int id = enemy.GetInstanceID();
        enemies.Add(id, enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        int id = GetEnemyID(enemy);
        enemies.Remove(id);
        
        // Проверяем наличие оставшихся врагов
        if (enemies.Count == 0)
            GameManager.Instance.NextWave();
    }

    private int GetEnemyID(Enemy enemy)
    {
        return enemy.GetInstanceID();
    }
}
