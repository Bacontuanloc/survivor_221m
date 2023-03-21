using Assets.Scripts.Char;
using Assets.Scripts.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

namespace Assets.Scripts.WeaponManagement
{
    public class Bat : MonoBehaviour, IWeapon
    {
        private float rotZ;
        public float rotationSpeed;
        public float damage;
        public int count=1;
        private ItemFactory itemFactory;
        void Start()
        {
            itemFactory=gameObject.AddComponent<ItemFactory>();
        }
        // Update is called once per frame
        void Update()
        {
            Attack();
        }
        public void Attack()
        {
            rotZ += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
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
                        count++;
                        Destroy(collision.gameObject);
                    }
                }
                else if (creep is FastMonster)
                {
                    FastMonster fastMonster = creep as FastMonster;
                    fastMonster.health = fastMonster.health - damage;
                    if (fastMonster.health < 0)
                    {
                        count++;
                        Destroy(collision.gameObject);
                    }
                }
                else
                {
                    TankMonster tankMonster = creep as TankMonster;
                    tankMonster.health = tankMonster.health - damage;
                    if (tankMonster.health < 0)
                    {
                        count++;
                        Destroy(collision.gameObject);
                    }
                }
                Debug.Log("count : "+count);
                if (count % 10 == 0)
                {
                    Debug.Log("Create Bomb");
                    GameObject item =itemFactory.Create("bomb");
                    item.transform.position=collision.gameObject.transform.position;
                }
            }
        }
        public void Skill()
        {
            throw new NotImplementedException();
        }
    }
}
