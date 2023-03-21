using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MC"))
        {
            GameObject mc = GameObject.FindWithTag("MC");
            GameObject[] creeps = GameObject.FindGameObjectsWithTag("Enemy");
           foreach(GameObject go in creeps)
            {
                Debug.Log("Destroy all");
                Destroy(go);
            }
            Destroy(gameObject);

        }
    }
}