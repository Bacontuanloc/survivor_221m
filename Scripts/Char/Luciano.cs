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
        public Luciano()
        {
            speed = 6f;
            health = 30f;
            rotateSpeed = 500;
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Creep monster = collision.gameObject.GetComponent<Monster>();
                //health -= monster.damage;
                //ChangeState(new OnHitState());
            }
        }

        public override void TakeDamage(int damageAmount)
        {
            throw new NotImplementedException();
        }
    }
}
