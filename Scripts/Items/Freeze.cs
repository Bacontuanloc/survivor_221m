using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Item
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MC"))
        {
            GameObject mainCharacter = GameObject.FindWithTag("MC");

            // Get all GameObjects in the scene
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Enemy");

            // Loop through all GameObjects
            foreach (GameObject obj in allObjects)
            {
                Debug.Log("Freeze");
                    // Freeze the GameObject's rigidbody if it has one
                    Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                        rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    
                
            }
            Destroy(gameObject);

        }
    }
}