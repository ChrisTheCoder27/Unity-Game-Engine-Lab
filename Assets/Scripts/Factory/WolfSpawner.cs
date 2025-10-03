using UnityEngine;

public class WolfSpawner : EnemySpawner
{
    [SerializeField] GameObject wolfPrefab;

    public override Enemy SpawnEnemy()
    {
        GameObject wolf = Instantiate(wolfPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        return wolf.GetComponent<Enemy>();
    }
}
