using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Creep
{
    public float speed = 1.5f;
    public float health =15f;
    public float damage = 7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToMC();
    }

    protected void MoveToMC()
    {
        GameObject mc = GameObject.FindWithTag("MC");
        gameObject.transform.position = Vector3.MoveTowards(transform.position, mc.transform.position, speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (health < 0)
            {
                Destroy(gameObject);
            }
            health = health - 10;
            
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
           Destroy(gameObject);
        }

    }


}
