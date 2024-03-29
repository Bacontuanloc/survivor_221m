﻿using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMonster : Creep
{
    private CreepState currentState;
    public float speed;
    public float health;
    public float current_healt;
    public float damage;
    public FastMonster() { 
    }

    // Start is called before the first frame update
    void Start()
    {
        health = (float)(health * Math.Pow(1.25, level));
        damage = (float)(damage * Math.Pow(1.25, level));
        
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
        current_healt = current_healt - damageAmount;
        if (current_healt < 0)
        {
            Destroy(gameObject);
        }

    }
}
