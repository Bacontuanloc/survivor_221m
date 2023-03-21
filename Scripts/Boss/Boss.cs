using Assets.Scripts.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Boss : MonoBehaviour
{


    public float level=1;

    public float health;
    public float damage;
    private float detectionRadius = 10f;
    private Bounds screenBounds;

    private float fireRate = 0.8f;
    private float bulletSpeed = 10f;

    public GameObject bulletPrefab;

    private State CurrentState;
    private Timer timer;
    private Timer timerSummonBoss;

    private float timeLeft;
    private float changeSkillStateTime =10f;

    // Start is called before the first frame update
    void Start()
    {
        health = 50 * level;
        damage = 12 * level;
        timer = gameObject.AddComponent<Timer>();
        timerSummonBoss = gameObject.AddComponent<Timer>();
        timer.Duration = fireRate;
        timer.Run();
        CurrentState = new BossChaseState(this);
        UpdateState();
        timeLeft = changeSkillStateTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            timerSummonBoss.Duration = 120f;
            timerSummonBoss.Run();
        }
        if (timerSummonBoss.Finished)
        {
            level += 1;
            SummonBoss();
        }
        CurrentState.UpdateState();
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            ChangeState(new BossSkillState(this));
            timeLeft = changeSkillStateTime;
        }
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

    public void Skill1()
    {
        float radius = 5f;
        float duration = 2f;
        float damage = 10f;
        GameObject mc = GameObject.FindWithTag("MC");
        float timeElapsed = 0.0f;
        for (int i = 0; i < 10; i++)
        {
            var prefab = Resources.Load("Prefabs/bomb") as GameObject;
            GameObject bombArea = Instantiate(prefab);
            Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 0));
            position.z = 0;
            bombArea.transform.position = position;
        }
    }
    public void SummonBoss()
    {
        var prefab = Resources.Load("Prefabs/Boss") as GameObject;
        GameObject boss = Instantiate(prefab);
        Vector3 bossSpawnLocation = Vector3.zero;
        GameObject character = GameObject.FindGameObjectWithTag("MC");
        bossSpawnLocation.x = character.transform.position.x;
        bossSpawnLocation.y = character.transform.position.y + 5;
        boss.transform.position = bossSpawnLocation;
        GameObject[] monster = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject m in monster)
        {
            Destroy(m);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Ammo ammo = collision.gameObject.GetComponent<Ammo>();
            Debug.Log("Before: " + health);
            health -= ammo.damage;
            Debug.Log("After: " + health);
        }
    }
}
