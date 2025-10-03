using UnityEngine;

public class Bear : Enemy
{
    Transform playerLocation;

    void Awake()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        LookAtPlayer();

        Vector3 direction = playerLocation.position - transform.position;
        transform.position += direction * 0.25f * Time.deltaTime;
    }

    public override void LookAtPlayer()
    {
        transform.LookAt(playerLocation);
    }

    public override void Attack()
    {
        Debug.Log("Bear slashes!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }
}
