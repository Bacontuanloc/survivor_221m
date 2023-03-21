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

        public Tomee() {
            speed = 8f;
            health = 20f;
            rotateSpeed = 500f;
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Creep creep = collision.gameObject.GetComponent<Creep>();
                if (creep is Monster)
                {
                    Monster monster = creep as Monster;
                    health -= monster.damage;
                    if (health <= 0)
                    {
                        Destroy(gameObject);
                    }
                    healthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
                    healthBar.TakeDamage(monster.damage);
                }
                else if (creep is FastMonster)
                {
                    FastMonster fastMonster = creep as FastMonster;
                    health -= fastMonster.damage;
                    if (health <= 0)
                    {
                        Destroy(gameObject);
                    }
                    healthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
                    healthBar.TakeDamage(fastMonster.damage);
                }
                else
                {
                    TankMonster tankMonster = creep as TankMonster;
                    health -= tankMonster.damage;
                    if (health <= 0)
                    {
                        Destroy(gameObject);
                    }
                    healthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
                    healthBar.TakeDamage(tankMonster.damage);
                }
            }
            if (collision.gameObject.CompareTag("Boss"))
            {
                Boss boss = collision.gameObject.GetComponent<Boss>();
                health -= boss.damage;
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
                healthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
                healthBar.TakeDamage(boss.damage);
            }
            if (collision.gameObject.CompareTag("CreepBullet"))
            {
                //health -= monster.damage;
                //ChangeState(new OnHitState());
                Debug.Log(currentHealth);
                healthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
                healthBar.TakeDamage(5);
            }
        }

        public override void TakeDamage(int damageAmount)
        {
        }
    }
}
