using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Char
{
    public class Geran : Character
    {
        private CharacterState currentState;
       

        public Geran() {
            speed = 5f;
            health = 50f;
            rotateSpeed = 500f;
        }      

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
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
          //  health = health -damageAmount;
        }
    }
}
