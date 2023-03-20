using Assets.Scripts.Char;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Assets.Scripts.WeaponManagement
{
    public class Bat : MonoBehaviour, IWeapon
    {
        private float rotZ;
        public float rotationSpeed;
        void Start()
        {

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
                //health -= monster.damage;
                //changestate(new onhitstate());
            }
        }
        public void Skill()
        {
            throw new NotImplementedException();
        }
    }
}
