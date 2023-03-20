using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMonsterDistence : MonoBehaviour
{

        public float distanceThreshold = 2f;
        public float force = 1f;

        private void FixedUpdate()
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (gameObjects.Length > 0)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                for (int j = i + 1; j < gameObjects.Length; j++)
                {
                    Rigidbody rigidbodyI = gameObjects[i].GetComponent<Rigidbody>();
                    Rigidbody rigidbodyJ = gameObjects[j].GetComponent<Rigidbody>();

                    if (rigidbodyI == null || rigidbodyJ == null)
                    {
                        continue;
                    }

                    Vector3 direction = gameObjects[i].transform.position - gameObjects[j].transform.position;
                    float distance = direction.magnitude;

                    if (distance < distanceThreshold)
                    {
                        Vector3 forceDirection = direction.normalized * force;
                        rigidbodyI.AddForce(forceDirection);
                        rigidbodyJ.AddForce(-forceDirection);
                    }
                }
            }
        }
        }
    
}
