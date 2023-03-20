﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMonster : Creep
{
    public float speed = 2f;
    public float health = 50f;
    public float damage = 7f;

    // Start is called before the first frame update
    void Start()
    {
        health = (float)(health * Math.Pow(1.25,level));
        damage = (float)(health * Math.Pow(1.25, level));
    }

    // Update is called once per frame
    void Update()
    {
        MoveToMC();
    }

    protected void MoveToMC()
    {
        GameObject mc = GameObject.FindWithTag("MC");
        gameObject.transform.position = Vector3.MoveTowards(transform.position, mc.transform.position, speed * Time.deltaTime);

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

        }
        if (collision.gameObject.CompareTag("MC"))
        {
            Destroy(gameObject);
        }

    }


}
