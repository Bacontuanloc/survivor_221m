using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Char
{
    public class Luciano : Character
    {
        private CharacterState currentState;
  

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Creep creep = collision.gameObject.GetComponent<Creep>();
                healthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
                if (creep is Monster)
                {
                    Monster monster = creep as Monster;

                    //health -= monster.damage;
                    ChangeState(new OnHitState(this));                
                    health -= monster.damage;
                    ChangeState(new OnHitState(this));
                    if (health <= 0)
                    {
                        //Destroy(gameObject);
                    }
                   
                    healthBar.TakeDamage(monster.damage);
                }
                else if (creep is FastMonster)
                {
                    FastMonster fastMonster = creep as FastMonster;
                    //health -= fastMonster.damage;
                    ChangeState(new OnHitState(this));                  
                    health -= fastMonster.damage;
                    ChangeState(new OnHitState(this));
                    if (health <= 0)
                    {
                        //Destroy(gameObject);
                    }
                    
                    healthBar.TakeDamage(fastMonster.damage);
                }
                else
                {
                    TankMonster tankMonster = creep as TankMonster;

                    //health -= tankMonster.damage;
                    ChangeState(new OnHitState(this));                 

                    health -= tankMonster.damage;
                    ChangeState(new OnHitState(this));
                    if (health <= 0)
                    {
                       // Destroy(gameObject);
                    }

                    healthBar.TakeDamage(tankMonster.damage);
                }
            }
            if (collision.gameObject.CompareTag("Boss"))
            {
                Boss boss = collision.gameObject.GetComponent<Boss>();
                health -= boss.damage;
                ChangeState(new OnHitState(this));
                healthBar.TakeDamage(boss.damage);
            }
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Creep monster = collision.gameObject.GetComponent<Monster>();
                ChangeState(new OnHitState(this));
                Debug.Log(currentHealth);
                healthBar.TakeDamage(5);
            }
            if (collision.gameObject.CompareTag("CreepBullet"))
            {
                CreepBullet creepBullet = collision.gameObject.GetComponent<CreepBullet>();
                ChangeState(new OnHitState(this));
                Debug.Log(currentHealth);
                healthBar.TakeDamage(creepBullet.damage);
            }
            if (health <= 0)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                //gameObject.GetComponent<CreepBulletPool>().poolBullet = new List<GameObject>();
                // Destroy(gameObject);
            }
        }

        public override void TakeDamage(int damageAmount)
        {
        }
    }
}
