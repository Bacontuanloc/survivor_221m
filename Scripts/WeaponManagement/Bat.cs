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
using UnityEngine.UI;

namespace Assets.Scripts.WeaponManagement
{
    public class Bat : Weapon
    {
        private float rotZ;
        public float rotationSpeed;
        public float damage;
        public int count=1;
        private ItemFactory itemFactory;

            

        public Text enemiesDestroyedText;
        public int scoreNum;

        void Start()
        {
            itemFactory=gameObject.AddComponent<ItemFactory>();
            scoreNum = 0;
            enemiesDestroyedText = GameObject.FindWithTag("Mytext").GetComponent<Text>();     

        }
        // Update is called once per frame
        void Update()
        {
            Attack();
        }
        public override void Attack()
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
                    if (monster.health <= 0)
                    {
                        count++;
                        scoreNum+=1;
                        Destroy(collision.gameObject);
                        enemiesDestroyedText.text = "Enemy Destroyed" + scoreNum;
                    }
                }
                else if (creep is FastMonster)
                {
                    FastMonster fastMonster = creep as FastMonster;
                    fastMonster.health = fastMonster.health - damage;
                    if (fastMonster.health <= 0)
                    {
                        count++;
                        scoreNum += 1;
                        Destroy(collision.gameObject);
                        enemiesDestroyedText.text = "Enemy Destroyed" + scoreNum;
                    }
                }
                else
                {
                    TankMonster tankMonster = creep as TankMonster;
                    tankMonster.health = tankMonster.health - damage;
                    if (tankMonster.health <= 0)
                    {
                        count++;
                        scoreNum+= 1;
                        Destroy(collision.gameObject);
                        enemiesDestroyedText.text = "Enemy Destroyed: " + scoreNum;
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
        public override void Skill()
        {
            throw new NotImplementedException();
        }
    }
}
