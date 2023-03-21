using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 5f;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("MC")){
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision.collider);
        }
        else
        {
            Character player = collision.gameObject.GetComponent<Character>();
            Boss boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
            if (player != null)
            {
                player.health -= boss.damage * 1.5f;
            }
            Destroy(gameObject);
        }
    }
}
