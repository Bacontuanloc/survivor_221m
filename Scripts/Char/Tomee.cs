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
