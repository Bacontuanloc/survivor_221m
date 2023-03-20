using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int damage = 5;
    private Bounds screenBounds;
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
        screenBounds = OrthographicBounds(Camera.main);
        Vector3 DownLeft = new Vector3(screenBounds.min.x, screenBounds.min.y, 0);
        Vector3 UpLeft = new Vector3(screenBounds.min.x, screenBounds.max.y, 0);
        Vector3 DownRight = new Vector3(screenBounds.max.x, screenBounds.min.y, 0);
        Vector3 UpRight = new Vector3(screenBounds.max.x, screenBounds.max.y, 0);
        if(this.transform.position.y<DownLeft.y||this.transform.position.x>DownRight.x
            || this.transform.position.x < DownLeft.x || this.transform.position.y > UpRight.y)
        {
            this.gameObject.SetActive(false);
        }

    }
    private Bounds OrthographicBounds(Camera camera)
    {

        float screenAspect = (float)Screen.width / (float)Screen.height;

        float cameraHeight = camera.orthographicSize * 2;

        Bounds bounds = new Bounds(

            camera.transform.position,

            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));

        return bounds;
    }
}
