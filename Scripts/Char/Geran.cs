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

        //public int maxHealth = 100;
        public int currentHealth;

        public GameObject healthBar;
        public Geran() {
            speed = 3f;
            health = 50;
            rotateSpeed = 500f;
        }
        private void Start()
        {    
            currentHealth = health;
            healthBar = GameObject.FindWithTag("HealthBar");
            healthBar.AddComponent<HealthBar>().SetMaxHealth(health);
            // healthBar.SetMaxHealth(health);
            currentState = new NormalState(this);
        }
        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
            float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
            movementDirection.Normalize();
            transform.Translate(movementDirection * speed * Time.deltaTime * inputMagnitude, Space.World);
            if (movementDirection != Vector2.zero)
            {
                Quaternion toRoation = Quaternion.LookRotation(Vector3.forward, movementDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRoation, rotateSpeed * Time.deltaTime);
            }
            currentState.UpdateState(this);
            TakeDamage();
            
        }

        public override void ChangeState(CharacterState newState)
        {
            if (currentState != null)
            {
                currentState.ExitState(this);
            }

            currentState = newState;
            currentState.EnterState(this);
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
               // Creep monster = collision.gameObject.GetComponent<Monster>();
                //health -= monster.damage;
                //ChangeState(new OnHitState());
                currentHealth = currentHealth - 10;
                Debug.Log(currentHealth);
                healthBar.AddComponent<HealthBar>().SetHealth(currentHealth);
            }
        }



        public override void TakeDamage()
        {
            currentHealth = currentHealth - 10;
            Debug.Log(currentHealth);
            healthBar.AddComponent<HealthBar>().SetHealth(currentHealth);
        }
    }
}
