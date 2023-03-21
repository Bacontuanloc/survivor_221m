using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        GameObject mc = GameObject.FindWithTag("MC");
        currentHealth = mc.GetComponent<Character>().health;
        healthBar.SetMaxHealth(mc.GetComponent<Character>().health);
    }

    // Update is called once per frame
    void Update()
    {
     //  TakeDamage();
     if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
