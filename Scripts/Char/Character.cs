using Assets.Scripts;
using Assets.Scripts.Char;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Character : MonoBehaviour
{
    private CharacterState currentState;
    private MovementJoystick movementJoystick;
    public float speed;
    public float health;
    public float rotateSpeed;


    private void Start()
    {
        currentState = new NormalState(this);
        movementJoystick = GameObject.FindWithTag("Joystick").GetComponent<MovementJoystick>();
    }
    private void FixedUpdate()
    {
        Move();
        //else
        //{
        //    rb.velocity = Vector2.zero;
        //}
    }

    private void Move()
    {
        if (movementJoystick.joystickVec.x != 0 || movementJoystick.joystickVec.y != 0)
        {
            //rb.velocity = new Vector2(movementJoystick.joystickVec.x * speed, movementJoystick.joystickVec.y * speed);
            Vector2 movementDirection = new Vector2(movementJoystick.joystickVec.x, movementJoystick.joystickVec.y);
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
    }
    public void ChangeState(CharacterState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;
        currentState.EnterState(this);
    }
    public abstract void TakeDamage(int damageAmount);
    public abstract void OnCollisionEnter2D(Collision2D collision);

    // Any other common functionality goes here
}
