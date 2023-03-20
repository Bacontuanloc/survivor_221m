using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Monster monster = collision.gameObject.GetComponent<Monster>(); 
            if (monster != null) 
            {
                monster.health -= damage; 

                if (monster.health <= 0) 
                {
                    Destroy(monster);
                }
            }
            this.gameObject.SetActive(false);
            
        }
        if (collision.gameObject.CompareTag("MC"))
        {
            Character player = collision.gameObject.GetComponent<Character>();
            if (player != null)
            {
                //player.health -= damage;

                //if (player.health <= 0)
                //{
                //    Destroy(player);
                //}
            }
            this.gameObject.SetActive(false);
        }
    }
}
