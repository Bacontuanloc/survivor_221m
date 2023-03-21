﻿using System;
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
        public int currentHealth;
        public GameObject healthBar;

        public Luciano()
        {
            speed = 5f;
            health = 30;
            rotateSpeed = 630f;
        }

        private void Start()
        {
            {
                currentHealth = health;
                healthBar = GameObject.FindWithTag("HealthBar");
                healthBar.GetComponent<HealthBar>().SetMaxHealth(health);
                healthBar.GetComponent<HealthBar>().SetHealth(health);
                currentState = new NormalState(this);

            }
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
                Debug.Log(currentHealth);
                healthBar = GameObject.FindWithTag("HealthBar");
                healthBar.GetComponent<HealthBar>().TakeDamage(5);
            }
        }

        public override void TakeDamage()
        {
            throw new NotImplementedException();
        }
    }
}
