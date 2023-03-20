using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManagement
{
    private Boss Boss;
    private State CurrentState;

    public BossStateManagement(Boss boss)
    {
        this.Boss = boss;
        CurrentState = new BossIdleState(boss);
    }

    public void ChangeState(State newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();
    }

    public void Update()
    {
        CurrentState.UpdateState();
    }
}
