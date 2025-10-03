using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void LookAtPlayer();

    public abstract void Attack();
}
