using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPrototype : MonoBehaviour
{
    public float health;
    public float moveSpeed;

    public abstract EnemyPrototype Clone();

    public abstract void Attack();
}
