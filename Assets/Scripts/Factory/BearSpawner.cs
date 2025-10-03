using UnityEngine;

public class BearSpawner : EnemySpawner
{
    [SerializeField] GameObject bearPrefab;

    public override Enemy SpawnEnemy()
    {
        GameObject bear = Instantiate(bearPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        return bear.GetComponent<Enemy>();
    }
}
