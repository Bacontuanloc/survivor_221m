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
        MoveToMC();
    }

    protected void MoveToMC()
    {
        GameObject mc = GameObject.FindWithTag("MC");
        gameObject.transform.position = Vector3.MoveTowards(transform.position, mc.transform.position,  Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (health < 0)
            {
                Destroy(gameObject);
            }
            health = health - 10;
            Debug.Log("Hurt");
            ChangeState(new CreepOnHitState(this));

        }
        if (collision.gameObject.CompareTag("MC"))
        {
            //Destroy(gameObject);
            Character character = collision.gameObject.GetComponent<Character>();
            character.health=character.health-health;
        }

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
}
