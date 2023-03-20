using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : State
{
    private Boss Boss;
    Transform firePoint;
    private float bulletSpeed = 10f;

    public BossAttackState(Boss boss)
    {
        this.Boss = boss;
    }

    public override void EnterState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        Boss.Fire();
        if (!Boss.IsPlayerInRange())
        {
            Boss.ChangeState(new BossChaseState(Boss));
        }
    }

    //public void Fire()
    //{
    //    GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
    //    GameObject player = GameObject.FindWithTag("MC");
    //    if (bullet != null)
    //    {
    //        bullet.transform.position = Boss.transform.position;
    //        bullet.transform.rotation = Boss.transform.rotation;
    //        Vector3 direction = (player.transform.position - Boss.transform.position).normalized;
    //        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    //        Physics2D.IgnoreCollision(Boss.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    //    }
    //}


}
