using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    public float damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Fire()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;
        Vector3 localTopRight = new Vector3(size.x / 2, size.y / 2, 0);
        Vector3 worldTopRight = gameObject.transform.TransformPoint(localTopRight);
        Vector3 localTopLeft = new Vector3(-size.x / 2, size.y / 2, 0);
        Vector3 worldTopLeft = gameObject.transform.TransformPoint(localTopLeft);
        GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = (worldTopLeft + worldTopRight) / 2;
            bullet.transform.rotation = gameObject.transform.rotation;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(gameObject.transform.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
