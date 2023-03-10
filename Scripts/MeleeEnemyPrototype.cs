using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyPrototype : EnemyPrototype
{
    public float health = 20f;
    public float moveSpeed = 5f;

    public override void Attack()
    {
        GameObject mc = GameObject.FindWithTag("MC");
        gameObject.transform.position = Vector3.MoveTowards(transform.position, mc.transform.position, moveSpeed * Time.deltaTime);
    }

    public override EnemyPrototype Clone()
    {
        return Instantiate(this);
    }

}
