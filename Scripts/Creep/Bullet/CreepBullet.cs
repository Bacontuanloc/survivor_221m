using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepBullet : MonoBehaviour
{
    private int damage = 5;
    public Vector3 Destination { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("MC") != null)
        {
            if ( Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("MC").transform.position) <= 0.2f)
            {
                Explode();
            }

            if (Destination != null)
            {
                transform.Translate((Destination - transform.position) * Time.deltaTime * 2);
            }
        }
    }

    private void Explode()
    {
        if (GameObject.FindGameObjectWithTag("MC") != null)
        {
            if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("MC").transform.position) <= 0.2f)
            {
                if (GameObject.FindGameObjectWithTag("MC") != null)
                {
                    GameObject.FindGameObjectWithTag("MC").GetComponent<Character>().TakeDamage(15);
                }
            }
            gameObject.SetActive(false);
        }
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
