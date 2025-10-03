using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] EnemySpawner wolfSpawner;
    [SerializeField] EnemySpawner bearSpawner;

    void Start()
    {
        Enemy wolf = wolfSpawner.SpawnEnemy();
        Enemy bear = bearSpawner.SpawnEnemy();
    }

}
