using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyPrototype : EnemyPrototype
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 6f;
    public float health = 10f;
    public float moveSpeed = 3f;

    public override void Attack()
    {
        GameObject mc = GameObject.FindWithTag("MC");
        GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
        bullet.transform.position = Vector3.MoveTowards(transform.position, mc.transform.position, bulletSpeed * Time.deltaTime);
    }

    public override EnemyPrototype Clone()
    {
        return Instantiate(this);
    }

}
