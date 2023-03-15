using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int level;
    private float health;
    private float damage;

    private BossStateManagement stateManagement;

    // Start is called before the first frame update
    void Start()
    {
        stateManagement = new BossStateManagement(this);   
    }

    // Update is called once per frame
    void Update()
    {
        stateManagement.Update();   
    }

    public void ChangeState(State newState)
    {
        stateManagement.ChangeState(newState);
    }
}
