using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] EnemySpawner spawner;

    void Start()
    {
        Enemy enemy = spawner.SpawnEnemy();
    }

    void Update()
    {
        
    }
}
