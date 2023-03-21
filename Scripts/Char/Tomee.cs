using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Char
{
    public class Tomee : Character
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
                    health -= fastMonster.damage;
                    ChangeState(new OnHitState(this));
                    if (health <= 0)
                    {
                       // Destroy(gameObject);
                    }
                    healthBar.TakeDamage(fastMonster.damage);
                }
                else
                {
                    TankMonster tankMonster = creep as TankMonster;
                    health -= tankMonster.damage;
                    ChangeState(new OnHitState(this));
                    if (health <= 0)
                    {
                        //Destroy(gameObject);
                    }

                    healthBar.TakeDamage(tankMonster.damage);
                }
            }
            if (collision.gameObject.CompareTag("Boss"))
            {
                Boss boss = collision.gameObject.GetComponent<Boss>();
                health -= boss.damage;
                ChangeState(new OnHitState(this));
                if (health <= 0)
                {
                    //Destroy(gameObject);
                }
                healthBar.TakeDamage(boss.damage);
            }
            if (collision.gameObject.CompareTag("CreepBullet"))
            {
                CreepBullet creepBullet = collision.gameObject.GetComponent<CreepBullet>();
                health -= monster.damage;
                ChangeState(new OnHitState(this));
                ChangeState(new OnHitState());
                Debug.Log(currentHealth);
                healthBar.TakeDamage(creepBullet.damage);
            }
        }

        public override void TakeDamage(int damageAmount)
        {
        }
    }
}
