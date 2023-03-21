using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.WeaponManagement
{
    public class Kunai : Weapon
    {
        public GameObject bulletPrefab;
        public float bulletSpeed;
        public float fireRate;
        public float damage;
        void Start()
        {
            InvokeRepeating("Attack", 0f, fireRate);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public override void Attack()
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
                GameObject character = GameObject.FindWithTag("MC");
                Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), character.GetComponent<Collider2D>());
                GameObject[] creepBullet = GameObject.FindGameObjectsWithTag("CreepBullet");
                for (int i = 0; i < creepBullet.Length; i++)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), creepBullet[i].GetComponent<Collider2D>());
                }
                bullet.transform.position = (worldTopLeft + worldTopRight) / 2;
                bullet.transform.rotation = gameObject.transform.rotation;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(gameObject.transform.up * bulletSpeed, ForceMode2D.Impulse);
            }
        }
        public override void Skill()
        {
            throw new NotImplementedException();
        }
    }
}
