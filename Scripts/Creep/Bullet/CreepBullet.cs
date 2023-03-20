using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepBullet : MonoBehaviour
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
        if (collision.gameObject.CompareTag("MC")) 
        {
            Character character = collision.gameObject.GetComponent<Character>(); 
            if (character != null) 
            {
                character.health -= damage; 

                if (character.health <= 0) 
                {
                    //FIXME
                    //Destroy(monster);
                }
            }
            this.gameObject.SetActive(false);
            
        }
    }
}
