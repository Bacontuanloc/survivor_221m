using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerState currentState;
    public GameObject bulletPrefab;
    public float speed = 5f;
    public float health = 30;
    public float roateSpeed = 630f;

    private void Start()
    {
        currentState = new NormalState(this);
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * Time.deltaTime*inputMagnitude,Space.World);
        if(movementDirection != Vector2.zero)
        {
            Quaternion toRoation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRoation, roateSpeed * Time.deltaTime);
        }
        currentState.UpdateState(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>();
            health -= monster.damage;
            Debug.Log(health);
            ChangeState(new OnHitState(this));
        }
    }

    public void ChangeState(PlayerState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;
        currentState.EnterState(this);
    }

}
