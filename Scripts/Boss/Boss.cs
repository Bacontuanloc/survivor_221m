using Assets.Scripts.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int level;
    private float health;
    private float damage;
    private float detectionRadius = 10f;

    private float fireRate = 0.1f;
    private float bulletSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private State CurrentState;
    private BossStateManagement stateManagement;
    private Transform target;
    private Timer timer;

    private float timeLeft;
    private float changeSkillStateTime =10f;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = fireRate;
        timer.Run();
        CurrentState = new BossChaseState(this);
        UpdateState();
        timeLeft = changeSkillStateTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState();
        timeLeft -= Time.deltaTime;
        //if (timeLeft < 0)
        //{
        //    ChangeState(new BossSkillState(this));
        //    timeLeft = changeSkillStateTime;
        //}
    }

    public bool IsPlayerInRange()
    {
        if (GameObject.FindGameObjectWithTag("MC") != null)
        {
            GameObject target = GameObject.FindGameObjectWithTag("MC");

            if (Vector2.Distance(transform.position, target.transform.position) <= detectionRadius)
            {
                return true;
            }
        }
        return false;
    }

    public void ChangeState(State newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();
    }

    public void UpdateState()
    {
        CurrentState.UpdateState();
    }

    public void Fire()
    {
        if (timer.Finished)
        {
            GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
            GameObject player = GameObject.FindWithTag("MC");
            if (bullet != null)
            {
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = this.transform.rotation;
                Vector3 direction = (player.transform.position - this.transform.position).normalized;
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
            }
            timer.Duration =fireRate;
            timer.Run();
        }
    }
}
