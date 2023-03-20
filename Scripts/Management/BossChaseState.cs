using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossChaseState : State
{
    private float speed = 6f;
    private Boss Boss;

    public BossChaseState(Boss boss)
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
        GameObject mc = GameObject.FindWithTag("MC");
        Boss.transform.position = Vector3.MoveTowards(Boss.transform.position, mc.transform.position, speed * Time.deltaTime);
        if (Boss.IsPlayerInRange())
        {
            Boss.ChangeState(new BossAttackState(Boss));
        }
    }
}
