using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.WeaponManagement
{
    public class Kunai : MonoBehaviour, IWeapon
    {
        public GameObject bulletPrefab;
        public float bulletSpeed;
        public float fireRate;
        public float damage;
        public Text enemiesDestroyedText;
        public int scoreNum;

        void Start()
        {
            scoreNum = 0;
            enemiesDestroyedText = GameObject.FindWithTag("Mytext").GetComponent<Text>();
            InvokeRepeating("Attack", 0f, fireRate);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Attack()
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
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Creep creep = collision.gameObject.GetComponent<Creep>();
                if (creep is Monster)
                {
                    Monster monster = creep as Monster;
                    monster.health = monster.health - damage;
                    if (monster.health < 0)
                    {
                        scoreNum += 1;
                        Destroy(collision.gameObject);
                        enemiesDestroyedText.text = "Enemy Destroyed" + scoreNum;
                    }
                }
                else if (creep is FastMonster)
                {
                    FastMonster fastMonster = creep as FastMonster;
                    fastMonster.health = fastMonster.health - damage;
                    if (fastMonster.health < 0)
                    {
                        scoreNum += 1;
                        Destroy(collision.gameObject);
                        enemiesDestroyedText.text = "Enemy Destroyed" + scoreNum;
                    }
                }
                else
                {
                    TankMonster tankMonster = creep as TankMonster;
                    tankMonster.health = tankMonster.health - damage;
                    if (tankMonster.health < 0)
                    {
                        scoreNum += 1;
                        Destroy(collision.gameObject);
                        enemiesDestroyedText.text = "Enemy Destroyed" + scoreNum;
                    }
                }
            }
        }
        public void Skill()
        {
            throw new NotImplementedException();
        }
    }
}
