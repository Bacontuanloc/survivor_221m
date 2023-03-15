using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Character : MonoBehaviour
{
    public float speed;
    public float health;
    public float rotateSpeed;

    public abstract void Move();
    public abstract void OnCollisionEnter2D(Collision2D collision);
    public abstract void ChangeState(CharacterState newState);
    public abstract void TakeDamage(int damageAmount);

    // Any other common functionality goes here
}
