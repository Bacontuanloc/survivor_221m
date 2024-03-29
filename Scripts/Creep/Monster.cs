using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Pool;

public class Monster : Creep
{
    private CreepState currentState;
    public float currentHealth;
    public float speed;
    public float health;
    public float damage;
    public float bulletSpeed;
    public float fireRate;
    public GameObject bulletPrefabs;



    // Start is called before the first frame update
    void Start()
    {
        health = (float)(health * Math.Pow(1.25, level));
        damage = (float)(damage * Math.Pow(1.25, level));
        InvokeRepeating("Shoot", 3f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] creepBullet = GameObject.FindGameObjectsWithTag("CreepBullet");
        for (int i = 0; i < creepBullet.Length; i++)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), creepBullet[i].GetComponent<Collider2D>());
        }
        MoveToMC();
    }
    public void Shoot()
    {
        GameObject target = GameObject.FindWithTag("MC");
        //gameObject.transform.position = Vector3.MoveTowards(transform.position, mc.transform.position, speed * Time.deltaTime);
        GameObject cannonball = Instantiate(bulletPrefabs);
            if (cannonball != null)
            {
                cannonball.transform.position = gameObject.transform.position;
                cannonball.GetComponent<CreepBullet>().Destination = target.transform.position;;
            }
    }

    protected void MoveToMC()
    {
        GameObject mc = GameObject.FindWithTag("MC");
        if (mc != null)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, mc.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public override void ChangeState(CreepState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;
        currentState.EnterState(this);
    }

    public override void TakeDamage(int damageAmount)
    {
    }
}
